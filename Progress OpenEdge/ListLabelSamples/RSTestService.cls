 
 /*------------------------------------------------------------------------
    File        : RSTestService
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Tom
    Created     : Mon Jan 07 07:48:33 CET 2019
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeFileCache FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeClientEvent FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.RSTestService INHERITS OpenEdgeDatasetService: 

    DEFINE STREAM sLog.

    DEFINE TEMP-TABLE ttMaster NO-UNDO 
        FIELD MasterId     AS INTEGER 
        FIELD MasterName   AS CHARACTER
        FIELD MasterTypeId AS INTEGER
        FIELD FilterId     AS CHARACTER  
        INDEX pk IS PRIMARY UNIQUE MasterId
        INDEX ie MasterTypeId
        INDEX ieFilter FilterId.
        
    DEFINE TEMP-TABLE ttDetail NO-UNDO 
        FIELD DetailId     AS INTEGER 
        FIELD DetailName   AS CHARACTER
        FIELD MasterId     AS INTEGER
        FIELD DetailTypeId AS INTEGER    
        INDEX pk IS PRIMARY UNIQUE DetailId
        INDEX ak IS UNIQUE MasterId DetailName
        INDEX ie DetailTypeId.

    DEFINE TEMP-TABLE ttMasterType NO-UNDO
        FIELD MasterTypeId   AS INTEGER
        FIELD MasterTypeName AS CHARACTER 
        INDEX pk IS PRIMARY UNIQUE MasterTypeId.
        
    DEFINE TEMP-TABLE ttDetailType NO-UNDO
        FIELD DetailTypeId   AS INTEGER
        FIELD DetailTypeName AS CHARACTER 
        INDEX pk IS PRIMARY UNIQUE DetailTypeId.

    DEFINE TEMP-TABLE ttFilter NO-UNDO
        FIELD FilterId   AS CHARACTER
        FIELD FilterName AS CHARACTER 
        INDEX pk IS PRIMARY UNIQUE FilterId.

        
    DEFINE DATASET dsRSTest FOR ttMaster, ttDetail, ttMasterType, ttDetailType, ttFilter
        DATA-RELATION MasterType FOR ttMaster, ttMasterType 
            RELATION-FIELDS (MasterTypeId, MasterTypeId)
        DATA-RELATION MasterDetail FOR ttMaster, ttDetail
            RELATION-FIELDS (MasterId, MasterId)
        DATA-RELATION DetailType FOR ttDetail, ttDetailType 
            RELATION-FIELDS (DetailTypeId, DetailTypeId)
        DATA-RELATION Filter FOR ttFilter, ttMaster 
            RELATION-FIELDS (FilterId, FilterId)
            
        .

    DEFINE PRIVATE VARIABLE mcCurrentClientId AS CHARACTER NO-UNDO.

    CONSTRUCTOR PUBLIC RSTestService (  ):
        SUPER (DATASET dsRSTest:HANDLE ).
    END CONSTRUCTOR.

    METHOD OVERRIDE PUBLIC LONGCHAR ClientEvent( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        DEFINE VARIABLE oClientEvent AS OpenEdgeClientEvent NO-UNDO.
        DEFINE VARIABLE oCache       AS OpenEdgeFileCache   NO-UNDO.
        DEFINE VARIABLE cClientId    AS CHARACTER           NO-UNDO.
        DEFINE VARIABLE cEvent       AS CHARACTER           NO-UNDO.
        DEFINE VARIABLE lOK          AS LOGICAL             NO-UNDO.
        oClientEvent = NEW OpenEdgeClientEvent(plcRequestJson).
        cClientId = oClientEvent:ClientId.
        cEvent    = oClientEvent:EventName.
        
        mcCurrentClientId = cClientId.
        
        writeLog(SUBSTITUTE("ClientEvent: &1 from ClientId: &2",cEvent,cClientId)).
        
        /* When the DP gets disposed we cleanup the local cache */
        IF oClientEvent:EventName = "ClientDisposed" AND oClientEvent:ClientId > "" THEN 
        DO:
            oCache = NEW OpenEdgeFileCache(THIS-OBJECT:ServiceName,cClientId).
            lok = oCache:DeleteCache().
        END.
        RETURN "".        
    END METHOD.

    METHOD OVERRIDE PUBLIC LONGCHAR getData( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        DEFINE VARIABLE oServiceParameter AS OpenEdgeServiceParameter NO-UNDO.
        DEFINE VARIABLE oCache            AS OpenEdgeFileCache        NO-UNDO.
        DEFINE VARIABLE cClientId         AS CHARACTER                NO-UNDO.
        DEFINE VARIABLE lcJson            AS LONGCHAR                 NO-UNDO.
        oServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
        cClientId = oServiceParameter:ClientId.
        mcCurrentClientId = cClientId.
        
        DATASET dsRSTest:EMPTY-DATASET ().

        writeLog( SUBSTITUTE ("getData Request:~n&1", SUBSTRING(plcRequestJson,1,10000))).
       
        oCache = NEW OpenEdgeFileCache(THIS-OBJECT:ServiceName,cClientId).
        IF oCache:CacheExists() = TRUE THEN 
        DO:
            lcJson = oCache:ReadCache().
            DATASET dsRSTest:READ-JSON  ("LONGCHAR",lcJson).
            writeLog("getData -> Use cache").
        END.
        ELSE 
        DO:
            fillDataset().
            writeLog("getData -> fill dataset").
            DATASET dsRSTest:WRITE-JSON ("LONGCHAR", lcJson, TRUE).
            oCache:WriteCache(lcJson).
        END.    
        
        /* Execute the request with data inside our dataset. */ 
        lcJson = SUPER:getData(INPUT plcServiceParameterJson, INPUT plcRequestJson).
        writeLog( SUBSTITUTE("getData returns &1 bytes.", LENGTH(lcJson))).
        
        RETURN lcJson.
        
    END METHOD.
    
    METHOD PRIVATE VOID fillDataset(  ):
        
        CREATE ttMasterType.
        ASSIGN ttMasterType.MasterTypeId = 1
               ttMasterType.MasterTypeName = "Master Type 1".
               
        CREATE ttMasterType.
        ASSIGN ttMasterType.MasterTypeId   = 2
               ttMasterType.MasterTypeName = "Master Type 2".
        
        CREATE ttDetailType.
        ASSIGN ttDetailType.DetailTypeId   = 1
               ttDetailType.DetailTypeName = "Detail Type 1".
               
        CREATE ttDetailType.
        ASSIGN ttDetailType.DetailTypeId   = 2
               ttDetailType.DetailTypeName = "Detail Type 2".
        
        CREATE ttFilter.
        ASSIGN ttFilter.FilterId   = "A"
               ttFilter.FilterName = "Filter A".
               
        CREATE ttFilter.
        ASSIGN ttFilter.FilterId   = "B"
               ttFilter.FilterName = "Filter B".
        
        CREATE ttMaster.
        ASSIGN ttMaster.MasterId     = 1
               ttMaster.MasterName   = "Master 1"
               ttMaster.MasterTypeId = 1
               ttMaster.FilterId     = "A".
               
        CREATE ttDetail.
        ASSIGN ttDetail.MasterId     = 1
               ttDetail.DetailId     = 1
               ttDetail.DetailTypeId = 1
               ttDetail.DetailName   = "Detail 1.1".
                      
        CREATE ttDetail.
        ASSIGN ttDetail.MasterId     = 1
               ttDetail.DetailId     = 2
               ttDetail.DetailTypeId = 2
               ttDetail.DetailName   = "Detail 1.2".
        
        CREATE ttMaster.
        ASSIGN ttMaster.MasterId     = 2
               ttMaster.MasterName   = "Master 2"
               ttMaster.MasterTypeId = 0 /* None */
               ttMaster.FilterId     = "A".
               
        CREATE ttDetail.
        ASSIGN 
            ttDetail.MasterId     = 2
            ttDetail.DetailId     = 3
            ttDetail.DetailTypeId = 1
            ttDetail.DetailName   = "Detail 2.1".
                      
        CREATE ttDetail.
        ASSIGN 
            ttDetail.MasterId     = 2
            ttDetail.DetailId     = 4
            ttDetail.DetailTypeId = 0 /* None */
            ttDetail.DetailName   = "Detail 2.2".
        
        CREATE ttMaster.
        ASSIGN ttMaster.MasterId     = 3
               ttMaster.MasterName   = "Master 3"
               ttMaster.MasterTypeId = 2
               ttMaster.FilterId     = "B". 
        
        RETURN.

    END METHOD.

    METHOD PUBLIC VOID writeLog( pcMessage AS CHARACTER ):
        DEFINE VARIABLE cFile AS CHARACTER NO-UNDO.
        cFile = SESSION:TEMP-DIRECTORY + "\" + SUBSTITUTE("RSTestService_&1.log",mcCurrentClientId).
        OUTPUT STREAM sLog TO VALUE (cFile) APPEND.
        PUT STREAM sLog UNFORMATTED pcMessage SKIP.        
        OUTPUT STREAM sLog CLOSE.
        
        RETURN.
    END METHOD.    

END CLASS.