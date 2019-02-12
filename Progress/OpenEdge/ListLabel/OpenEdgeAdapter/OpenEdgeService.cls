 /**********************************************************************
  * Copyright (C) 2016 by Taste IT Consulting ("TIC") -                *
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
    File        : OpenEdgeService
    Purpose     : Abstract Generic Database or Dataset service. 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sat Dec 19 08:27:31 CET 2015
    Notes       : 
  ----------------------------------------------------------------------*/
  
USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeSchema FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDataRequest FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.IOpenEdgeService FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeNativeFunction FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeCalculatedTableArgs FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeService USE-WIDGET-POOL ABSTRACT IMPLEMENTS IOpenEdgeService: 
    
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeDataRequest.i}
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeSchema.i}
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeFunctionResponse.i}

	DEFINE PUBLIC  PROPERTY ServiceName         AS CHARACTER NO-UNDO 
	GET.
	PRIVATE SET. 
	
    DEFINE  PUBLIC PROPERTY ServiceSchema       AS OpenEdgeSchema NO-UNDO 
    GET.
    PRIVATE SET. 
    
    DEFINE PUBLIC PROPERTY  SourceDatasetHandle AS HANDLE  NO-UNDO 
    GET.
    SET. 
    
    DEFINE PUBLIC PROPERTY ServiceParameter AS OpenEdgeServiceParameter NO-UNDO
    GET.
    PRIVATE SET.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeService (  ):
		SUPER ().
		
		ServiceName   = THIS-OBJECT:GetClass():TypeName.
		ServiceSchema = NEW OpenEdgeSchema(ServiceName).

	END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose: Needs to be implemented by the Service.
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD ABSTRACT VOID registerSchema(  ).

	/*------------------------------------------------------------------------------
	 Purpose: We build the schema only once when requested.
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC LONGCHAR getSchema( plcServiceParameterJson AS LONGCHAR ):
	    ServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
	    registerSchema().
		RETURN ServiceSchema:getSchemaJSON().
	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose: Get the data for a request
     Notes:   This version doesn't need to access it's own schema.
              All needed information is passed through the request itself 
              including OEDbTableName and RelationFields.
              This makes it faster to handle requests, without the need to build
              the own schema for each request. 
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR getData( plcServiceParameterJson AS LONGCHAR, 
                                    plcRequestJson          AS LONGCHAR):

        DEFINE VARIABLE oRequest       AS OpenEdgeDataRequest NO-UNDO.
        DEFINE VARIABLE lcResponseJson AS LONGCHAR            NO-UNDO.
        
        DEFINE VARIABLE hSourceBuffer  AS HANDLE    NO-UNDO EXTENT.
        DEFINE VARIABLE hDataSource    AS HANDLE    NO-UNDO EXTENT.
        DEFINE VARIABLE hSourceQuery   AS HANDLE    NO-UNDO EXTENT.
        
        DEFINE VARIABLE hTempTable     AS HANDLE    NO-UNDO EXTENT.
        DEFINE VARIABLE hExportDataset AS HANDLE  NO-UNDO.
        DEFINE VARIABLE cFields        AS CHARACTER NO-UNDO EXTENT.
        DEFINE VARIABLE cQuery         AS CHARACTER NO-UNDO EXTENT.
        DEFINE VARIABLE cWhereClause   AS CHARACTER NO-UNDO EXTENT.
        DEFINE VARIABLE cSortBy        AS CHARACTER NO-UNDO EXTENT.
       
        DEFINE VARIABLE hQuery         AS HANDLE  NO-UNDO.
        DEFINE VARIABLE hDataset       AS HANDLE  NO-UNDO .
        DEFINE VARIABLE iExtent        AS INTEGER NO-UNDO.
        DEFINE VARIABLE iBuffer        AS INTEGER NO-UNDO.
        DEFINE VARIABLE cRelationFieldsReverse AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iPair          AS INTEGER NO-UNDO.
        DEFINE VARIABLE hRelation      AS HANDLE NO-UNDO.
        DEFINE VARIABLE cPrepare       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cWhere         AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSort          AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cPrimary       AS CHARACTER NO-UNDO.
        
        DEFINE VARIABLE iField         AS INTEGER   NO-UNDO.
        DEFINE VARIABLE hField         AS HANDLE    NO-UNDO.
        DEFINE VARIABLE hBuffer        AS HANDLE    NO-UNDO.
        DEFINE VARIABLE hChildBuffer   AS HANDLE    NO-UNDO. 
        DEFINE VARIABLE cField         AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iMaxRows       AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cLimit         AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cMethod        AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cColumns       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iColumn        AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cColumnNameAndType AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSourceSortBy  AS CHARACTER NO-UNDO.
        
        DEFINE VARIABLE oCalculatedTableArgs AS OpenEdgeCalculatedTableArgs NO-UNDO.

        DEFINE BUFFER OEChildDataTable   FOR OEDataTable.
        DEFINE BUFFER OpenEdgeChildTable FOR OpenEdgeTable.

        /* Parse request and return data in dataset */
        ServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
        /*iMaxRows = INTEGER(ServiceParameter:ParameterValue("MaxRows")) NO-ERROR.*/
        iMaxRows = ServiceParameter:MaxRows.
        IF iMaxRows > 0 THEN 
            cLimit = SUBSTITUTE (" MAX-ROWS &1",iMaxRows).
        /*
        MESSAGE STRING (plcRequestJson)
        VIEW-AS ALERT-BOX.
        */
        oRequest = NEW OpenEdgeDataRequest(plcRequestJson).
        oRequest:getDataset(OUTPUT DATASET dsOpenEdgeDataRequest).
                
        /* Data Request */
        FOR EACH OEDataTable:
            iExtent = iExtent + 1.
        END.    

        ASSIGN EXTENT (hSourceBuffer) = iExtent
               EXTENT (hSourceQuery)  = iExtent
               EXTENT (hDataSource)   = iExtent
               EXTENT (hTempTable)    = iExtent
               EXTENT (cFields)       = iExtent
               EXTENT (cQuery)        = iExtent
               EXTENT (cWhereClause)  = iExtent
               EXTENT (cSortBy)       = iExtent
               .

        /* Create the dataset */
        CREATE DATASET hDataset.
        
        /* Create temp-tables, source buffers and where clauses */
        iBuffer = 0.
        FOR EACH OEDataTable:
             
            iBuffer = iBuffer + 1.

            /* Since LL24 - Support for calculated temp-tables */
            IF OEDataTable.OECalculatedTable = TRUE THEN 
            DO:
                oCalculatedTableArgs = NEW OpenEdgeCalculatedTableArgs().
                ASSIGN oCalculatedTableArgs:OETableName        = OEDataTable.OETableName
                       oCalculatedTableArgs:OETableWhere       = OEDataTable.OETableWhere
                       oCalculatedTableArgs:OEParentTableName  = OEDataTable.OEParentTableName
                       oCalculatedTableArgs:OEParentTableWhere = OEDataTable.OEParentTableWhere.
                
                CalculateTable(oCalculatedTableArgs).
                IF VALID-HANDLE(oCalculatedTableArgs:OETableBufferHandle) THEN 
                DO:
                    CREATE BUFFER hSourceBuffer[iBuffer] FOR TABLE oCalculatedTableArgs:OETableBufferHandle.
                END.
            END.
            /* Buffer for a dataset temp-table */
            ELSE IF VALID-HANDLE(SourceDatasetHandle) THEN 
                CREATE BUFFER hSourceBuffer[iBuffer] FOR TABLE SourceDatasetHandle:GET-BUFFER-HANDLE(OEDataTable.OETableName).
            /* Buffer for an OpenEdge table */
            ELSE 
                CREATE BUFFER hSourceBuffer[iBuffer] FOR TABLE SUBSTITUTE (OEDataTable.OEDbTableName).
            
            /* Temp-Table like buffer. Use primary index only */
            CREATE TEMP-TABLE hTempTable[iBuffer].
            cPrimary = ENTRY(1,PrimaryIndexPattern(hSourceBuffer[iBuffer])) NO-ERROR.
            IF cPrimary > "" THEN 
                hTempTable[iBuffer]:CREATE-LIKE (hSourceBuffer[iBuffer],cPrimary).
            ELSE 
                hTempTable[iBuffer]:CREATE-LIKE (hSourceBuffer[iBuffer]).
            
            IF OEDataTable.OECalculatedColumns > "" THEN 
            DO iColumn = 1 TO NUM-ENTRIES(OEDataTable.OECalculatedColumns):
                cColumnNameAndType = ENTRY(iColumn,OEDataTable.OECalculatedColumns).
                hTempTable[iBuffer]:ADD-NEW-FIELD (ENTRY(1,cColumnNameAndType,"|"),ENTRY(2,cColumnNameAndType,"|")).
            END.
            
            hTempTable[iBuffer]:TEMP-TABLE-PREPARE(OEDataTable.OETableName).
            
            /* Add the temp-table's default buffer to the dataset. */
            hDataset:ADD-BUFFER (hTempTable[iBuffer]:DEFAULT-BUFFER-HANDLE).
            
            /* The list of fields to put into json later */
            cFields[iBuffer] = OEDataTable.OETableColumns.
            IF cFields[iBuffer] = "" THEN 
                ASSIGN cFields[iBuffer] = "*".

            cWhere = TRIM (OEDataTable.OETableWhere).
            IF cWhere > "" THEN 
            DO:
                IF cWhere BEGINS "WHERE " THEN 
                    cWhere = SUBSTRING(cWhere,7).
                cWhereClause[iBuffer] = cWhere.    
            END. 
            
            /* Replace Advanced Filter placeholders by expressions 
               The problem is that OpenEdge doesn't support SQL's "IN".
               So we have to translate the filter either to LOOKUP which is not type save i.e. for decimal keys
               (like Dynamics uses) or to an OR expression that may cause the query to exceed 32K.
               Unfortunally a query prepare string is a string not a longchar.
               Multi-Value filters on a long list don't make sense and may cause problems here.
               Another problem is that LL uses an Excel like "All". It sends all keys instead of not filtering
               when the value of a parameter is "All". But I asked combit to do something here.
            */
            DEFINE VARIABLE cExpression AS CHARACTER NO-UNDO.
            FOR EACH OEAdvancedFilter OF OEDataTable BY LENGTH(OEAdvancedFilter.OEFilterValues) DESCENDING :
                IF LENGTH(cWhereClause[iBuffer]) > 15000 THEN 
                   cExpression = AdvancedFilterExpressionUsingLookup().
                ELSE 
                   cExpression = AdvancedFilterExpressionUsingOR().
                cWhereClause[iBuffer] = REPLACE (cWhereClause[iBuffer],OEAdvancedFilter.OEFilterName,cExpression).
            END.
            
            /* Add Sort order for Json later */
            IF TRIM (OEDataTable.OETableSortBy) BEGINS "BY " THEN 
            DO:
                cSortBy[iBuffer] = OEDataTable.OETableSortBy.
            END.   
        END.    
        
        /* Create data relations for the dataset */
        FOR EACH OEDataRelation:
            hBuffer      = hDataset:GET-BUFFER-HANDLE (OEDataRelation.OETableName)      NO-ERROR.
            hChildBuffer = hDataset:GET-BUFFER-HANDLE (OEDataRelation.OEChildTableName) NO-ERROR.
            IF VALID-HANDLE(hBuffer) AND VALID-HANDLE(hChildBuffer) THEN 
            DO:
               hRelation = hDataset:ADD-RELATION (hBuffer,hChildBuffer,OEDataRelation.OERelationFields) NO-ERROR.
               /* We don't care about the name - maybe just for debugging */
               /*IF OEDataRelation.OERelationName > "" THEN 
                   hRelation:NAME = OEDataRelation.OERelationName NO-ERROR.*/
            END.
        END.    

        /* Create data-sources:
           - Queries for the TopLevel Tables 
           - Buffers for Child Tables */
        DO iBuffer = 1 TO hDataset:NUM-BUFFERS:
            hBuffer = hDataset:GET-BUFFER-HANDLE(iBuffer).
            CREATE DATA-SOURCE hDataSource[iBuffer].
            IF hBuffer:PARENT-RELATION = ? THEN 
            DO:
               CREATE QUERY hSourceQuery[iBuffer].
               hSourceQuery[iBuffer]:SET-BUFFERS (hSourceBuffer[iBuffer]).
               hDataSource[iBuffer]:QUERY = hSourceQuery[iBuffer].
               hBuffer:ATTACH-DATA-SOURCE (hDataSource[iBuffer]).
               cWhere = "".
               IF cWhereClause[iBuffer] > "" THEN cWhere = "WHERE " + cWhereClause[iBuffer].
               /* If we have a limit then we have to sort the data source query to get the right records 
                  But this doesn't help because the max rows are applied to the query and the result will be
                  sorted later.              
               cSourceSortBy = "".
               IF iMaxRows > 0 THEN
               DO: 
                   IF cSortBy[iBuffer] > "" THEN 
                      ASSIGN cSourceSortBy = cSortBy[iBuffer].
                   ELSE 
                      ASSIGN cSourceSortBy = PrimeIndexSortBy(hSourceBuffer[iBuffer]).
               END.     
               hSourceQuery[iBuffer]:QUERY-PREPARE(SUBSTITUTE("FOR EACH &1 &2 NO-LOCK &3 &4",hSourceBuffer[iBuffer]:NAME,cWhere,cSourceSortBy,cLimit)).
               */
               hSourceQuery[iBuffer]:QUERY-PREPARE(SUBSTITUTE("FOR EACH &1 &2 NO-LOCK &3",hSourceBuffer[iBuffer]:NAME,cWhere,cLimit)).
            END.
            ELSE DO:
               hDataSource[iBuffer]:ADD-SOURCE-BUFFER(hSourceBuffer[iBuffer],?).
               hBuffer:ATTACH-DATA-SOURCE (hDataSource[iBuffer]).
               IF cWhereClause[iBuffer] > "" THEN
               DO: 
                 ASSIGN hDataSource[iBuffer]:FILL-WHERE-STRING = hDataSource[iBuffer]:FILL-WHERE-STRING + " AND " + cWhereClause[iBuffer].
               END.
            END.    
        END.    
          
        hDataset:FILL().
         
        /* Detach the data sources */
        DO iBuffer = 1 TO hDataset:NUM-BUFFERS:
            hDataset:GET-BUFFER-HANDLE (iBuffer):DETACH-DATA-SOURCE ().
        END.    
        
        /* build calculated fields */
        IF NOT VALID-HANDLE (SourceDatasetHandle) THEN 
        DO:
            iBuffer  = 0.
            FOR EACH OEDataTable:
                iBuffer = iBuffer + 1.
                IF OEDataTable.OECalculatedColumns = "" THEN 
                    NEXT.
                IF NOT VALID-HANDLE(hQuery) THEN 
                    CREATE QUERY hQuery.
                hBuffer = hDataset:GET-BUFFER-HANDLE (iBuffer).
                hQuery:SET-BUFFERS(hBuffer).
                hQuery:QUERY-PREPARE (SUBSTITUTE("FOR EACH &1",hBuffer:NAME)).
                hQuery:QUERY-OPEN ().
                cMethod = "Calculate" + ENTRY(2,OEDataTable.OEDbTableName,".").
                cColumns = "".
                DO iColumn = 1 TO NUM-ENTRIES(OEDataTable.OECalculatedColumns):
                    cColumns = cColumns + (IF iColumn = 1 THEN "" ELSE ",")
                             + ENTRY(1, ENTRY(iColumn,OEDataTable.OECalculatedColumns),"|").
                END.
                DO WHILE hQuery:GET-NEXT():
                    DYNAMIC-INVOKE (THIS-OBJECT,cMethod,hBuffer,cColumns) NO-ERROR.        
                END.
            END.
        END.
        
        /* Function call */
        IF TEMP-TABLE OEFunctionCall:HAS-RECORDS THEN 
        DO:
            lcResponseJson = ExecuteFunctionCall(hDataset:GET-BUFFER-HANDLE (1)).
            RETURN lcResponseJson.
        END.
        
        /* Create a dynamic export dataset with the colunms we want and 
           with primary indexes in sortby order */
        hExportDataset = createResponseDataset(hDataset,cFields,cSortBy).
        
        /* We always return a dataset with name "OpenEdgeDataResponse". 
           Note: The provider checks the name !! 
        */
        hExportDataset:SERIALIZE-NAME = "OpenEdgeDataResponse".
        hExportDataset:WRITE-JSON ("LONGCHAR",lcResponseJson,TRUE).
        RETURN lcResponseJson.
        
        /* Destroy 
           TODO: Can we do this with a widget pool automatically ?
        */
        FINALLY:
            DO iBuffer = 1 TO iExtent:
               DELETE OBJECT hSourceBuffer[iBuffer] NO-ERROR.
               DELETE OBJECT hSourceQuery[iBuffer]  NO-ERROR.
               DELETE OBJECT hDataSource[iBuffer]   NO-ERROR.
               DELETE OBJECT hTempTable[iBuffer]    NO-ERROR.
            END.   
            DELETE OBJECT hQuery   NO-ERROR.
            DELETE OBJECT hDataset NO-ERROR.
            IF VALID-HANDLE(hExportDataset) THEN 
            DO:
                DO iBuffer = 1 TO hExportDataset:NUM-BUFFERS:
                    DELETE OBJECT hExportDataset:GET-BUFFER-HANDLE(iBuffer):TABLE-HANDLE NO-ERROR.
                END.    
                DELETE OBJECT hExportDataset NO-ERROR.
            END.
        END FINALLY.

    END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE LONGCHAR ExecuteFunctionCall( phBuffer AS HANDLE ):
		
		DEFINE VARIABLE lcJson    AS LONGCHAR NO-UNDO.
		DEFINE VARIABLE oFunction AS OpenEdgeNativeFunction NO-UNDO.
		
		DEFINE VARIABLE hBuffer AS HANDLE  NO-UNDO.
		DEFINE VARIABLE dResult AS DECIMAL NO-UNDO.
		
		oFunction = NEW OpenEdgeNativeFunction().
		
		DATASET dsOpenEdgeFunctionResponse:EMPTY-DATASET ().
		
        FOR EACH OEFunctionCall:
            
            /*
            IF VALID-HANDLE(hBuffer) THEN 
                DELETE OBJECT hBuffer.
            */    
            
            CREATE BUFFER hBuffer FOR TABLE OEFunctionCall.OETableName.

            CASE OEFunctionCall.OEFunctionName:
                WHEN "AVERAGE" THEN 
                DO:
                    dResult = oFunction:NativeAverage(phBuffer,OEFunctionCall.OETableWhere,OEFunctionCall.OEExpression).
                END.
                WHEN "COUNT" THEN 
                DO:
                    dResult = oFunction:NativeCount(phBuffer,OEFunctionCall.OETableWhere).
                END.
                WHEN "MAXIMUM" THEN 
                DO:
                    dResult = oFunction:NativeMaximum(phBuffer,OEFunctionCall.OETableWhere,OEFunctionCall.OEExpression).
                END.
                WHEN "MINIMUM" THEN 
                DO:
                    dResult = oFunction:NativeMinimum(phBuffer,OEFunctionCall.OETableWhere,OEFunctionCall.OEExpression).
                END.
                WHEN "TOTAL" THEN 
                DO:
                    dResult = oFunction:NativeTotal(phBuffer,OEFunctionCall.OETableWhere,OEFunctionCall.OEExpression).
                END.
            END.
            
            IF dResult = ? THEN 
                dResult = 0.
            
            CREATE OEFunctionResponse.
            ASSIGN OEFunctionResponse.OEFunctionCallGuid = OEFunctionCall.OEFunctionCallGuid
                   OEFunctionResponse.OEFunctionResult   = dResult.
                         
            /*                   
            DELETE OBJECT hBuffer NO-ERROR.
            */
        END.
        
        DATASET dsOpenEdgeFunctionResponse:WRITE-JSON("LONGCHAR",lcJson,TRUE).
		
		RETURN lcJson.
		
		FINALLY:
            	DELETE OBJECT hBuffer NO-ERROR.	
        END FINALLY.

	END METHOD.

    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:  
	------------------------------------------------------------------------------*/
	METHOD PRIVATE CHARACTER AdvancedFilterExpressionUsingLookup(  ):
		DEFINE VARIABLE cFilter    AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cValues    AS LONGCHAR  NO-UNDO.   
        DEFINE VARIABLE cField     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cOp        AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSep       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iASC       AS INTEGER   NO-UNDO.
        
        cValues = OEAdvancedFilter.OEFilterValues.
        cSep    = OEAdvancedFilter.OEValueDelimiter.
        iASC    = ASC(cSep).
        /*cValues = REPLACE (cValues,"'","").*/
        IF OEAdvancedFilter.OEDataType = "character" THEN 
            cField = OEAdvancedFilter.OEColumnName.
        ELSE 
            cField = SUBSTITUTE("STRING(&1)",OEAdvancedFilter.OEColumnName).
        IF OEAdvancedFilter.OEFilterOperator = "IN" THEN 
            cOp = "> 0".
         ELSE 
            cOp = "= 0".
        
        cFilter = SUBSTITUTE ("LOOKUP (&1,'&2',CHR(&3)) &4",cField,cValues,iASC,cOp).

		RETURN cFilter.
	END METHOD.

    METHOD PRIVATE CHARACTER AdvancedFilterExpressionUsingOR(  ):
        DEFINE VARIABLE cFilter    AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cValues    AS LONGCHAR  NO-UNDO.   
        DEFINE VARIABLE iNumValues AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cField     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cOp        AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSep       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iValue     AS INTEGER   NO-UNDO.
        
        cValues    = OEAdvancedFilter.OEFilterValues.
        cSep       = OEAdvancedFilter.OEValueDelimiter.
        iNumValues = NUM-ENTRIES(cValues,cSep).

        DO iValue = 1 TO iNumValues:
            cFilter = cFilter + (IF iValue = 1 THEN "" ELSE " OR ")
                    + SUBSTITUTE ("&1 = '&2'",OEAdvancedFilter.OEColumnName, ENTRY(iValue,cValues,cSep)).
        END.

        IF OEAdvancedFilter.OEFilterOperator <> "IN" THEN 
          cFilter = SUBSTITUTE("NOT (&1)",cFilter).

        RETURN cFilter.
    END METHOD.
	
	
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE HANDLE createResponseDataset( phDataset AS HANDLE, 
	                                             pcFields  AS CHARACTER EXTENT,
	                                             pcSortBy  AS CHARACTER EXTENT):
		
		DEFINE VARIABLE hDataset    AS HANDLE    NO-UNDO.
        DEFINE VARIABLE iBuffer     AS INTEGER   NO-UNDO.
        DEFINE VARIABLE hTempTable  AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cPrimeIndex AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iField      AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cField      AS CHARACTER NO-UNDO.
        DEFINE VARIABLE hBuffer     AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cIndexInfo  AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iEntry      AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cIndex      AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cIndexFields AS CHARACTER NO-UNDO.
        
        CREATE DATASET hDataset.
                
        DO iBuffer = 1 TO phDataset:NUM-BUFFERS:

            hBuffer = phDataset:GET-BUFFER-HANDLE(iBuffer).
            CREATE TEMP-TABLE hTempTable.
            
            /* Create the index fields first. If we have to sort different from the 
               primary index order, we create a new primary index in sort order */
            cIndexInfo   = "".
            cIndexFields = "".
            IF pcSortBy[iBuffer] > "" THEN 
                cIndexInfo = SortIndexPattern(pcSortBy[iBuffer]).
            ELSE 
                cIndexInfo = PrimaryIndexPattern(hBuffer).

            IF cIndexInfo > "" THEN 
            DO:
                cIndex = ENTRY(1,cIndexInfo).
                hTempTable:ADD-NEW-INDEX (cIndex,
                                          FALSE,
                                          TRUE,
                                          FALSE).
                DO iEntry = 5 TO NUM-ENTRIES(cIndexInfo) BY 2:
                   cField = ENTRY(iEntry,cIndexInfo).
                   cIndexFields = cIndexFields + (IF cIndexFields > "" THEN "," ELSE "") + cField.
                   hTempTable:ADD-LIKE-FIELD(cField,hBuffer:BUFFER-FIELD(cField)).
                   hTempTable:ADD-INDEX-FIELD(cIndex,cField,
                        IF ENTRY(iEntry + 1,cIndexInfo) = "1" THEN "DESC" ELSE "ASC" ).                   
                END.                              
            END.
            /* If we want all fields ... */
            IF pcFields[iBuffer] = "*" OR pcFields[iBuffer] = "" THEN 
                hTempTable:ADD-FIELDS-FROM(hBuffer).
            /* .. else if we want only some fields. */
            ELSE DO:
                DO iField = 1 TO NUM-ENTRIES(pcFields[iBuffer]):
                    cField = TRIM(ENTRY(iField,pcFields[iBuffer])).
                    IF LOOKUP(cField,cIndexFields) = 0 THEN 
                        hTempTable:ADD-LIKE-FIELD(cField,hBuffer:BUFFER-FIELD(cField)).
                END.     
            END.

            hTempTable:TEMP-TABLE-PREPARE ("cpy" + hBuffer:NAME).
            
            hTempTable:SERIALIZE-NAME = hBuffer:NAME.
            hTempTable:COPY-TEMP-TABLE (hBuffer:TABLE-HANDLE,?,?,TRUE,"cpy").
            hDataset:ADD-BUFFER (hTempTable:DEFAULT-BUFFER-HANDLE).
        END.

		RETURN hDataset.

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC CHARACTER PrimeIndexSortBy( phBuffer AS HANDLE ):
		
		DEFINE VARIABLE cPattern AS CHARACTER NO-UNDO.
		DEFINE VARIABLE cField   AS CHARACTER NO-UNDO.
		DEFINE VARIABLE iEntry   AS INTEGER   NO-UNDO.
		DEFINE VARIABLE cSortBy  AS CHARACTER NO-UNDO.
		cPattern = PrimaryIndexPattern (phBuffer).
		IF cPattern > "" THEN 
		DO:
		    DO iEntry = 5 TO NUM-ENTRIES(cPattern) BY 2:
              cField = ENTRY(iEntry,cPattern).
              cSortBy = cSortBy 
                      + " BY " + cField 
                      + (IF ENTRY(iEntry + 1,cPattern) = "1" THEN " DESC" ELSE "").                   
            END.                              
        END.
		RETURN cSortBy.

	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
     ------------------------------------------------------------------------------*/
    METHOD PRIVATE CHARACTER PrimaryIndexPattern ( phBuffer AS HANDLE ):
        DEFINE VARIABLE cFields  AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iIndex   AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cInfo    AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iEntry   AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cPattern AS CHARACTER NO-UNDO.
        /* Name,unique,primary,word,... */
        iIndex = 1.
        cInfo = phBuffer:INDEX-INFORMATION(iIndex).
        DO WHILE cInfo <> ?:
           IF ENTRY(3,cInfo) = "1" THEN
           DO:
               cPattern = cInfo.
               LEAVE.
           END. 
           iIndex = iIndex + 1.
           cInfo = phBuffer:INDEX-INFORMATION(iIndex).
        END.
        RETURN cPattern.
    END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE CHARACTER SortIndexPattern( pcSortBy AS CHARACTER ):
		
        DEFINE VARIABLE iEntry      AS INTEGER    NO-UNDO.
        DEFINE VARIABLE cEntry      AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE cField      AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE lDescending AS LOGICAL    NO-UNDO.
        DEFINE VARIABLE iNumEntries AS INTEGER    NO-UNDO.
        DEFINE VARIABLE cPattern    AS CHARACTER NO-UNDO.

        pcSortBy    = TRIM(pcSortBy).
        iNumEntries = NUM-ENTRIES(pcSortBy," ").

        DO iEntry = 1 TO iNumEntries:
            cEntry = ENTRY(iEntry,pcSortBy," ").
            IF cEntry = "" THEN 
                NEXT.
            IF cEntry = "BY" THEN 
            DO:
                IF cField > "" THEN 
                DO:
                    cPattern = cPattern + (IF cPattern > "" THEN "," ELSE "")
                               + cField + "," + STRING(lDescending,"1/0").
                END. 
                cField = "".
                lDescending = FALSE.   
            END.
            ELSE IF cField = "" THEN 
               ASSIGN cField      = cEntry
                      lDescending = FALSE.
                      
            ELSE IF cEntry BEGINS "DESC" THEN 
               ASSIGN lDescending = TRUE.  
            
            IF iEntry = iNumEntries AND cField > "" THEN 
            DO:
               cPattern = cPattern + (IF cPattern > "" THEN "," ELSE "")
                          + cField + "," + STRING(lDescending,"1/0").
            END.  
        END.  
        IF cPattern > "" THEN 
          cPattern = "TempSortIdx,0,1,0," + cPattern.  
          
		RETURN cPattern.

	END METHOD.
	
    /*------------------------------------------------------------------------------
     Purpose: ClientEvent - notification from DataProvider
     Notes:   Since LL24 
              The handling of client events must be implemented in a service.
              To do this overwrite ClientEvent in your service.
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR ClientEvent( plcServiceParameterJson AS LONGCHAR, 
                                        plcRequestJson          AS LONGCHAR):
        RETURN "".
    END METHOD.



    /*------------------------------------------------------------------------------
     Purpose: Needs to be overwritten by the Service.
     Notes:   Since LL24
              The handle of the calculated temp-table buffer must be returned 
              in OpenEdgeCalculatedTableArgs:OETableBufferHandle.
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID CalculateTable(poArgs AS OpenEdgeCalculatedTableArgs):
        RETURN.

    END METHOD.

END CLASS.