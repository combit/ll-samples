 /**********************************************************************
 * Copyright (C) 2018 by Taste IT Consulting ("TIC") -                *
 * www.taste-consulting.de and other contributors as listed           *
 * below.  All Rights Reserved.                                       *
 *                                                                    *
 *  Software is distributed on an "AS IS", WITHOUT WARRANTY OF ANY    *
 *   KIND, either express or implied.                                 *
 *                                                                    *
 *  Contributors:                                                     *
 *                                                                    *
 **********************************************************************/  
 /*------------------------------------------------------------------------
    File        : CachedDatasetService
    Purpose     : Sample Service with a cache.
    Syntax      : 
    Description : The cache helps to build data when an event occurs.
                  - First getDataRequest (used in this sample)
                  - Client Event "ReportParametersCollected".
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Thu Nov 08 07:24:14 CET 2018
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeFileCache FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeClientEvent FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.CachedDatasetService INHERITS OpenEdgeDatasetService: 

    DEFINE STREAM sLog.

    DEFINE TEMP-TABLE ttSalesrep NO-UNDO LIKE Salesrep.
    DEFINE TEMP-TABLE ttState    NO-UNDO LIKE State.
    DEFINE TEMP-TABLE ttRegion   NO-UNDO
        FIELD Region      AS CHARACTER 
        INDEX pix IS PRIMARY UNIQUE Region.
    DEFINE TEMP-TABLE ttSalesYear NO-UNDO 
        FIELD SalesYear   AS INTEGER
        INDEX pix IS PRIMARY UNIQUE SalesYear     
        .     
        
    /* We don't really need indexes here to build relations properly.
       They are just there for performance reasons in case of many records.
    */       
    DEFINE TEMP-TABLE ttSales NO-UNDO 
        FIELD SalesRep    AS CHARACTER 
        FIELD State       AS CHARACTER 
        FIELD Region      AS CHARACTER 
        FIELD SalesYear   AS INTEGER 
        FIELD SalesAmount AS DECIMAL
        INDEX ixSalesrep  Salesrep State Region SalesYear
        INDEX ixState     State
        INDEX ixRegion    Region
        INDEX ixSalesYear SalesYear
        .
    
    /* A dataset must only have one active relation for a child table at a time.*/
    DEFINE DATASET dsSales FOR ttSalesrep, ttState, ttRegion, ttSalesYear, ttSales
        DATA-RELATION SalesrepRegion FOR ttSalesrep, ttRegion 
            RELATION-FIELDS(Region,Region)
        DATA-RELATION StateRegion FOR ttState, ttRegion NOT-ACTIVE 
            RELATION-FIELDS(Region,Region)
        DATA-RELATION SalesRepSales FOR ttSalesRep, ttSales NOT-ACTIVE 
            RELATION-FIELDS(SalesRep,SalesRep)
        DATA-RELATION StateSales FOR ttState, ttSales NOT-ACTIVE 
            RELATION-FIELDS(State,State)
        DATA-RELATION RegionSales FOR ttRegion, ttSales NOT-ACTIVE 
            RELATION-FIELDS(Region,Region)
        DATA-RELATION SalesYearSales FOR ttSalesYear, ttSales NOT-ACTIVE 
            RELATION-FIELDS(SalesYear,SalesYear)
       .

    /*------------------------------------------------------------------------------
     Purpose: Passes the dataset to the generic abstract super OpenEdgeService.
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC CachedDatasetService (  ):
        SUPER (DATASET dsSales:HANDLE).
        TablePrefixToRemove = "tt".
    END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose: React on Client Events from the DataProvider.
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD OVERRIDE PUBLIC LONGCHAR ClientEvent( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        DEFINE VARIABLE oClientEvent      AS OpenEdgeClientEvent      NO-UNDO.
        DEFINE VARIABLE oCache            AS OpenEdgeFileCache        NO-UNDO.
        DEFINE VARIABLE cClientId         AS CHARACTER                NO-UNDO.
        DEFINE VARIABLE cEvent            AS CHARACTER                NO-UNDO.
        DEFINE VARIABLE lOK               AS LOGICAL                  NO-UNDO.
        oClientEvent = NEW OpenEdgeClientEvent(plcRequestJson).
        cClientId = oClientEvent:ClientId.
        cEvent    = oClientEvent:EventName.
        
        writeLog(SUBSTITUTE("ClientEvent: &1 from ClientId: &2",cEvent,cClientId)).
        
        /* When the DP gets disposed we cleanup the local cache */
        IF oClientEvent:EventName = "ClientDisposed" AND oClientEvent:ClientId > "" THEN 
        DO:
            oCache = NEW OpenEdgeFileCache(THIS-OBJECT:ServiceName,cClientId).
            lok = oCache:DeleteCache().
        END.
        RETURN "".        

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose: A data provider (instance) asks for data.
     Notes:   The instance id = "ClientId" is a guid build in the data provider.
              If this service is running on an appserver agent then it's most
              likely to get different agents for each getData request from a client.
              So, the cache must be uniquely identified.
              In this sample we use a file cache in the session temp directory. 
    ------------------------------------------------------------------------------*/
    METHOD OVERRIDE PUBLIC LONGCHAR getData( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        DEFINE VARIABLE oServiceParameter AS OpenEdgeServiceParameter NO-UNDO.
        DEFINE VARIABLE oCache    AS OpenEdgeFileCache NO-UNDO.
        DEFINE VARIABLE cClientId AS CHARACTER NO-UNDO.
        DEFINE VARIABLE lcJson    AS LONGCHAR NO-UNDO.
        oServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
        cClientId = oServiceParameter:ClientId.
        DATASET dsSales:EMPTY-DATASET ().
        
        oCache = NEW OpenEdgeFileCache(THIS-OBJECT:ServiceName,cClientId).
        IF oCache:CacheExists() = TRUE THEN 
        DO:
            lcJson = oCache:ReadCache().
            DATASET dsSales:READ-JSON  ("LONGCHAR",lcJson).
            writeLog("Use cache").
        END.
        ELSE DO:
            fillDataset().
            writeLog("fill dataset").
            DATASET dsSales:WRITE-JSON ("LONGCHAR", lcJson, TRUE).
            oCache:WriteCache(lcJson).
        END.    
        
        /* Execute the request with data inside our dataset. */ 
        RETURN SUPER:getData(INPUT plcServiceParameterJson, INPUT plcRequestJson).

    END METHOD.

    METHOD PRIVATE VOID fillDataset(  ):

        CREATE ttRegion.
        ASSIGN ttRegion.Region = "Foreign".
        
        FOR EACH Salesrep NO-LOCK:
            CREATE ttSalesrep.
            BUFFER-COPY SalesRep TO ttSalesRep.
            FIND ttRegion WHERE ttRegion.Region = ttSalesrep.Region NO-ERROR.
            IF NOT AVAILABLE ttRegion THEN 
            DO:
                CREATE ttRegion.
                ASSIGN ttRegion.Region = ttSalesrep.Region.
            END.
        END.    

        FOR EACH State NO-LOCK:
            CREATE ttState.
            BUFFER-COPY State TO ttState.
            IF ttState.Region > "" THEN 
            DO:
                FIND ttRegion WHERE ttRegion.Region = ttState.Region NO-ERROR.
                IF NOT AVAILABLE ttRegion THEN 
                DO:
                    CREATE ttRegion.
                    ASSIGN ttRegion.Region = ttState.Region.
                END.
            END.
            ELSE 
               ASSIGN ttState.Region = "Foreign".
        END.    

        DEFINE VARIABLE iYear        AS INTEGER NO-UNDO.
        DEFINE VARIABLE dOrderAmount AS DECIMAL NO-UNDO.
        
        FOR EACH Order NO-LOCK, FIRST Customer OF Order NO-LOCK:
            
            dOrderAmount = 0.
            FOR EACH OrderLine OF Order NO-LOCK:
                dOrderAmount = dOrderAmount + OrderLine.ExtendedPrice.
            END.    
            
            FIND ttState WHERE ttState.State = Customer.State NO-ERROR.
            IF NOT AVAILABLE ttState THEN
            DO:
                CREATE ttState.
                ASSIGN ttState.State     = Customer.State
                       ttState.StateName = ttState.State
                       ttState.Region    = "Foreign".
            END.
            iYear = YEAR(Order.OrderDate).
            
            FIND ttSales WHERE ttSales.SalesRep  = Order.SalesRep
                         AND   ttSales.State     = ttState.State
                         AND   ttSales.Region    = ttState.Region
                         AND   ttSales.SalesYear = iYear NO-ERROR.
            IF NOT AVAILABLE ttSales THEN 
            DO:
                CREATE ttSales.
                ASSIGN ttSales.SalesRep  = Order.SalesRep
                       ttSales.State     = ttState.State
                       ttSales.Region    = ttState.Region
                       ttSales.SalesYear = iYear.
            END.
            ASSIGN ttSales.SalesAmount = ttSales.SalesAmount + dOrderAmount.
        END.
        RETURN.

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID writeLog( pcMessage AS CHARACTER ):
        /*
        DEFINE VARIABLE cFile AS CHARACTER NO-UNDO.
        cFile = SESSION:TEMP-DIRECTORY + "\" + "CachedDatasetService.log".
        
        OUTPUT STREAM sLog TO VALUE (cFile) APPEND.
        
        PUT STREAM sLog UNFORMATTED pcMessage SKIP.        
        
        OUTPUT STREAM sLog CLOSE.
        */
        RETURN.

    END METHOD.    
    

END CLASS.