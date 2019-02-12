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
    File        : OpenEdgeSchema
    Purpose     : Object to describe the schema.
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sat Dec 19 07:51:54 CET 2015
    Notes       : 
  ----------------------------------------------------------------------*/
USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeSchema: 
    
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeSchema.i}
    
    DEFINE TEMP-TABLE ttViewTable NO-UNDO 
       FIELD TableId     AS CHARACTER
       FIELD MasterTable AS LOGICAL 
       INDEX pix IS PRIMARY UNIQUE TableId.

    DEFINE TEMP-TABLE ttViewRelation NO-UNDO 
       FIELD RelationId AS CHARACTER
       INDEX pix IS PRIMARY UNIQUE RelationId.
    
	DEFINE PUBLIC PROPERTY SchemaDatasetHandle AS HANDLE NO-UNDO 
	GET:
	    RETURN DATASET dsOpenEdgeSchema:HANDLE.
	END GET.    

    DEFINE PUBLIC PROPERTY ServiceName AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 

    DEFINE PUBLIC PROPERTY DatabaseName AS CHARACTER NO-UNDO 
    GET.
    SET. 

    DEFINE PUBLIC PROPERTY DatasetHandle AS HANDLE   NO-UNDO 
    GET.
    PRIVATE SET. 

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC OpenEdgeSchema ():
        SUPER ().
    END CONSTRUCTOR.
	
    CONSTRUCTOR PUBLIC OpenEdgeSchema (pcServiceName AS CHARACTER ):
        SUPER ().
        ServiceName   = pcServiceName.
        registerService(ServiceName).
    END CONSTRUCTOR.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC LONGCHAR getSchemaJSON(  ):
		
		DEFINE VARIABLE lcData AS LONGCHAR NO-UNDO.

        DATASET dsOpenEdgeSchema:WRITE-JSON("LONGCHAR",lcData,TRUE /*,?,?,TRUE*/).

		RETURN lcData.

	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID setSchemaJSON( plcJsonSchema AS LONGCHAR ):
        
        DATASET dsOpenEdgeSchema:READ-JSON("LONGCHAR",plcJsonSchema,"EMPTY").

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR getRegisteredTables():
        
        DEFINE VARIABLE lcTables AS LONGCHAR NO-UNDO.
        
        FIND OpenEdgeService WHERE OpenEdgeService.ServiceName = ServiceName NO-ERROR.
        IF NOT AVAILABLE OpenEdgeService THEN 
            RETURN "".
        
        FOR EACH OpenEdgeTable OF OpenEdgeService BY OpenEdgeTable.TableName:
            lcTables = lcTables + (IF lcTables > "" THEN "," ELSE "")
                    + OpenEdgeTable.TableName.
        END.    

        RETURN lcTables.

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC CHARACTER getSchemaJSON( plcJsonSchema AS LONGCHAR ):
        
        DATASET dsOpenEdgeSchema:READ-JSON("LONGCHAR",plcJsonSchema,"EMPTY").

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID getSchemaDataset (OUTPUT DATASET dsOpenEdgeschema):
        
    END METHOD.    

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerDataset( phDataset             AS HANDLE ):
        registerDataset(phDataset,"").
        RETURN.
	END.
	METHOD PUBLIC VOID registerDataset( phDataset             AS HANDLE,
	                                    pcTablePrefixToRemove AS CHARACTER ):
	    
        DEFINE VARIABLE iBuffer         AS INTEGER   NO-UNDO.
        DEFINE VARIABLE hBuffer         AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cLLTableName    AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iStart          AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cRelationType   AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iRelation       AS INTEGER   NO-UNDO.
        DEFINE VARIABLE hRelation       AS HANDLE    NO-UNDO.
        DEFINE VARIABLE hChildBuffer    AS HANDLE    NO-UNDO.
        DEFINE VARIABLE iPair           AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cRelationFields        AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cRelationFieldsReverse AS CHARACTER NO-UNDO.
        
        iStart = LENGTH (pcTablePrefixToRemove) + 1.
        
        DO iBuffer = 1 TO phDataset:NUM-BUFFERS:
            hBuffer = phDataset:GET-BUFFER-HANDLE (iBuffer).
            IF pcTablePrefixToRemove > "" AND hBuffer:NAME BEGINS (pcTablePrefixToRemove) THEN 
                ASSIGN cLLTableName = SUBSTRING(hBuffer:NAME,iStart).
            ELSE 
                ASSIGN cLLTableName = hBuffer:NAME.
            registerTable(hBuffer,cLLTableName).
        END.
		
		/* We register only active relations - is this ok? 
		   We don't register many-many relations.
		   We don't register recursive-relations (yet?). A dataset itself doesn't really support this.
		   It's just the flag and we have to have another buffer. I don't know how to do that dynamically.
		*/
		DO iRelation = 1 TO phDataset:NUM-RELATIONS:
		    hRelation = phDataset:GET-RELATION (iRelation).
		    IF hRelation:ACTIVE = FALSE OR hRelation:RECURSIVE = TRUE THEN 
		       NEXT.
		    cRelationType   = relationType(hRelation).
		    cRelationFields = hRelation:RELATION-FIELDS.
		    cRelationFieldsReverse = "".
		    DO iPair = 1 TO NUM-ENTRIES(cRelationFields) BY 2:
		        cRelationFieldsReverse = cRelationFieldsReverse + (IF iPair = 1 THEN "" ELSE ",")
		                               + SUBSTITUTE("&2,&1", ENTRY(iPair,cRelationFields),ENTRY(iPair + 1,cRelationFields) ).
		        
		    END.
		    /* Register relation twice */
		    IF cRelationType = "one-one" THEN 
		    DO:
                registerRelation (hRelation:PARENT-BUFFER,hRelation:CHILD-BUFFER,cRelationFields,hRelation:NAME ).
                registerRelation (hRelation:CHILD-BUFFER,hRelation:PARENT-BUFFER,cRelationFieldsReverse,hRelation:NAME ).
		    END.
		    ELSE IF cRelationType = "one-many" THEN 
		    DO:
                registerRelation (hRelation:PARENT-BUFFER,hRelation:CHILD-BUFFER,cRelationFields,hRelation:NAME ).
		    END.
		    ELSE IF cRelationType = "many-one" THEN
		    DO:
                registerRelation (hRelation:CHILD-BUFFER,hRelation:PARENT-BUFFER,cRelationFieldsReverse,hRelation:NAME ).
		    END.
		    ELSE.         
		END.
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE VOID registerService( pcServiceName AS CHARACTER ):
  		CREATE OpenEdgeService.
 		ASSIGN OpenEdgeService.ServiceId   = GUID
  		       OpenEdgeService.ServiceName = pcServiceName.
		RETURN.
	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerTable ( phBuffer      AS HANDLE ):
        registerTable (phBuffer, phBuffer:NAME, FALSE, FALSE).
        RETURN.
    END METHOD.

    METHOD PUBLIC VOID registerTable ( phBuffer      AS HANDLE,
                                       pcLLTableName AS CHARACTER):
        registerTable (phBuffer, pcLLTableName, FALSE, FALSE).
        RETURN.
    END.
    
    METHOD PUBLIC VOID registerCalculatedTable ( phBuffer AS HANDLE ):
        registerTable (phBuffer, phBuffer:NAME, TRUE, FALSE ).
        RETURN.
    END METHOD.
    METHOD PUBLIC VOID registerCalculatedTable ( phBuffer      AS HANDLE,
                                                 pcLLTableName AS CHARACTER):
        registerTable (phBuffer, pcLLTableName, TRUE, FALSE).
        RETURN.
    END.

    METHOD PUBLIC VOID registerTable ( phBuffer          AS HANDLE,
                                       pcLLTableName     AS CHARACTER,
                                       plCalculatedTable AS LOGICAL,
                                       plCachedTable     AS LOGICAL ):
		
		DEFINE VARIABLE iField AS INTEGER NO-UNDO.
		DEFINE VARIABLE iIndex AS INTEGER NO-UNDO.
		DEFINE VARIABLE hField AS HANDLE  NO-UNDO.
		
		FIND OpenEdgeService WHERE OpenEdgeService.ServiceName = ServiceName.
		
		FIND OpenEdgeTable WHERE OpenEdgeTable.ServiceId    = OpenEdgeService.ServiceId
		                   AND   OpenEdgeTable.OETableName  = phBuffer:NAME 
		                   NO-ERROR.
		
		IF NOT AVAILABLE OpenEdgeTable THEN 
		DO:
		    CREATE OpenEdgeTable.
            ASSIGN OpenEdgeTable.ServiceId         = OpenEdgeService.ServiceId
                   OpenEdgeTable.TableId           = GUID 
                   OpenEdgeTable.OETableName       = phBuffer:NAME
                   OpenEdgeTable.TableName         = pcLLTableName
                   OpenEdgeTable.OECalculatedTable = plCalculatedTable
                   OpenEdgeTable.OECachedTable     = plCachedTable.
                   
            IF phBuffer:DBNAME <> "PROGRESST" THEN  
               ASSIGN OpenEdgeTable.OEDbTableName  = SUBSTITUTE("&1.&2",phBuffer:DBNAME,phBuffer:TABLE).
		    
    		DO iField = 1 TO phBuffer:NUM-FIELDS:

                hField = phBuffer:BUFFER-FIELD (iField).
    		    
    		    IF hField:EXTENT = 0 THEN 
    		    DO:
        		    CREATE OpenEdgeTableColumn.
        		    ASSIGN OpenEdgeTableColumn.ColumnId       = GUID
        		           OpenEdgeTableColumn.TableId        = OpenEdgeTable.TableId
        		           OpenEdgeTableColumn.OEColumnIndex    = 0
        		           OpenEdgeTableColumn.OEColumnName     = hField:NAME
                           OpenEdgeTableColumn.OEColumnDataType = hField:DATA-TYPE
                           OpenEdgeTableColumn.OEColumnFormat   = hField:FORMAT
                           OpenEdgeTableColumn.OEColumnDecimals = hField:DECIMALS
                           OpenEdgeTableColumn.ColumnName       = OpenEdgeTableColumn.OEColumnName
           		           .
           		END. 
           		ELSE DO iIndex = 1 TO hField:EXTENT:
                    CREATE OpenEdgeTableColumn.
                    ASSIGN OpenEdgeTableColumn.ColumnId       = GUID
                           OpenEdgeTableColumn.TableId          = OpenEdgeTable.TableId
                           OpenEdgeTableColumn.OEColumnIndex    = iIndex
                           OpenEdgeTableColumn.OEColumnName     = /*SUBSTITUTE("&1[&2]",hField:NAME,iIndex)*/ hField:NAME
                           OpenEdgeTableColumn.OEColumnDataType = hField:DATA-TYPE
                           OpenEdgeTableColumn.OEColumnFormat   = hField:FORMAT
                           OpenEdgeTableColumn.OEColumnDecimals = hField:DECIMALS
                           OpenEdgeTableColumn.ColumnName       = SUBSTITUTE("&1_&2",OpenEdgeTableColumn.OEColumnName,iIndex)
                           .
           		END.         
    	    END.	    
        END.
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerRelation( phParentBuffer   AS HANDLE,    phChildBuffer AS HANDLE, 
                                         pcRelationFields AS CHARACTER, pcRelationName  AS CHARACTER):
	   registerRelation (phParentBuffer, phChildBuffer, pcRelationFields, pcRelationName,pcRelationName).
	   RETURN.
	END METHOD.
    METHOD PUBLIC VOID registerRelation( phParentBuffer   AS HANDLE,    phChildBuffer AS HANDLE, 
                                         pcRelationFields AS CHARACTER, pcRelationName  AS CHARACTER,
                                         pcLLRelationName AS CHARACTER):

        DEFINE BUFFER ParentTable  FOR OpenEdgeTable.
        DEFINE BUFFER ChildTable   FOR OpenEdgeTable.

        DEFINE VARIABLE iPair AS INTEGER NO-UNDO.
        
        FIND OpenEdgeService WHERE OpenEdgeService.ServiceName = ServiceName.
        
        FIND ParentTable WHERE ParentTable.ServiceId   = OpenEdgeService.ServiceId
                         AND   ParentTable.OETableName = phParentBuffer:NAME.
        FIND ChildTable  WHERE ChildTable.ServiceId    = OpenEdgeService.ServiceId
                         AND   ChildTable.OETableName  = phChildBuffer:NAME.
        
        FIND OpenEdgeDataRelation WHERE OpenEdgeDataRelation.ParentTableId    = ParentTable.TableId
                                  AND   OpenEdgeDataRelation.ChildTableId     = ChildTable.TableId
                                  AND   OpenEdgeDataRelation.OERelationFields = pcRelationFields
                                  NO-ERROR.
        IF NOT AVAILABLE OpenEdgeDataRelation THEN 
        DO:                                           
            CREATE OpenEdgeDataRelation.
            ASSIGN OpenEdgeDataRelation.RelationId        = GUID 
                   OpenEdgeDataRelation.ServiceId         = OpenEdgeService.ServiceId
                   OpenEdgeDataRelation.ParentTableId     = ParentTable.TableId
                   OpenEdgeDataRelation.ParentTableName   = ParentTable.TableName
                   OpenEdgeDataRelation.ChildTableId      = ChildTable.TableId
                   OpenEdgeDataRelation.ChildTableName    = ChildTable.TableName
                   OpenEdgeDataRelation.RelationName      = pcLLRelationName
                   OpenEdgeDataRelation.OERelationFields  = pcRelationFields
                   OpenEdgeDataRelation.OERelationName    = pcRelationName
                   .             
            DO iPair = 1 TO NUM-ENTRIES(pcRelationFields) BY 2:
                ASSIGN OpenEdgeDataRelation.ParentColumnName = OpenEdgeDataRelation.ParentColumnName
                                                             + (IF iPair = 1 THEN "" ELSE "~t")
                                                             + TRIM(ENTRY(iPair,pcRelationFields))
                       OpenEdgeDataRelation.ChildColumnName  = OpenEdgeDataRelation.ChildColumnName
                                                             + (IF iPair = 1 THEN "" ELSE "~t")
                                                             + TRIM(ENTRY(iPair + 1,pcRelationFields))
                       .                                        
            END.       
        END.
		
		RETURN.
	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerFile ( pcFileName AS CHARACTER ):
        
        registerFileBuffer(pcFilename, pcFilename).
    
    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerFileBuffer( pcFileName AS CHARACTER, pcBufferName AS CHARACTER ):
        
        DEFINE VARIABLE hBuffer AS HANDLE NO-UNDO.
        IF pcBufferName = "" THEN 
              ASSIGN pcBufferName = pcFileName.
        
        CREATE BUFFER hBuffer FOR TABLE SUBSTITUTE("&1.&2", DatabaseName , pcFilename)
               BUFFER-NAME pcBufferName.
               
        registerTable(hBuffer).       
        
        RETURN.
        
        FINALLY:
                DELETE OBJECT hBuffer NO-ERROR. 
        END FINALLY.

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID registerFileRelation( pcParentFileName   AS CHARACTER, 
                                             pcChildFileName    AS CHARACTER, 
                                             pcRelationFields   AS CHARACTER,
                                             pcRelationName     AS CHARACTER ):
        registerFileRelation(pcParentFileName,"",pcChildFileName,"",pcRelationFields,pcRelationName).
        RETURN.
    END.    
    
    METHOD PUBLIC VOID registerFileRelation( pcParentFileName   AS CHARACTER, 
                                             pcParentBufferName AS CHARACTER,
                                             pcChildFileName    AS CHARACTER, 
                                             pcChildBufferName  AS CHARACTER,
                                             pcRelationFields   AS CHARACTER,
                                             pcRelationName     AS CHARACTER ):
                                                 
        DEFINE VARIABLE hParentBuffer AS HANDLE NO-UNDO.
        DEFINE VARIABLE hChildBuffer  AS HANDLE NO-UNDO.
                                              
        IF pcParentBufferName = "" THEN 
            ASSIGN pcParentBufferName = pcParentFileName.
        IF pcChildBufferName = "" THEN 
            ASSIGN pcChildBufferName = pcChildFileName.
                                              
        CREATE BUFFER hParentBuffer FOR TABLE SUBSTITUTE("&1.&2", DatabaseName, pcParentFilename)
               BUFFER-NAME pcParentBufferName.
        CREATE BUFFER hChildBuffer FOR TABLE SUBSTITUTE ("&1.&2", DatabaseName, pcChildFilename)
               BUFFER-NAME pcChildBufferName.
        registerRelation(hParentBuffer,hChildBuffer,pcRelationFields,pcRelationName).                                 
        
        RETURN.
        
        FINALLY:
                DELETE OBJECT hParentBuffer NO-ERROR.
                DELETE OBJECT hChildBuffer NO-ERROR.
        END FINALLY.

    END METHOD.  

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    METHOD PUBLIC LOGICAL registerCalculatedColumn ( OETableName   AS CHARACTER,
                                                     OEColumnName  AS CHARACTER,
                                                     OEDataType    AS CHARACTER ):
        RETURN registerCalculatedColumn(OETableName,OEColumnName,OEDataType,"").

    END METHOD.	
	
    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
	METHOD PUBLIC LOGICAL registerCalculatedColumn ( OETableName   AS CHARACTER,
	                                                 OEColumnName  AS CHARACTER,
	                                                 OEDataType    AS CHARACTER,
	                                                 OEMimeType    AS CHARACTER):
	          
        FIND OpenEdgeService WHERE OpenEdgeService.ServiceName = ServiceName NO-ERROR.
        IF NOT AVAILABLE OpenEdgeService THEN 
            RETURN FALSE.

        FIND OpenEdgeTable OF OpenEdgeService WHERE OpenEdgeTable.OETableName = OETableName
             NO-ERROR.
        IF NOT AVAILABLE OpenEdgeTable THEN 
            RETURN FALSE.
        FIND OpenEdgeTableColumn OF OpenEdgeTable WHERE OpenEdgeTableColumn.OEColumnName = OEColumnName NO-ERROR.
        IF AVAILABLE OpenEdgeTableColumn THEN 
            RETURN FALSE.
            
        CREATE OpenEdgeTableColumn.
        ASSIGN OpenEdgeTableColumn.ColumnId           = GUID
               OpenEdgeTableColumn.TableId            = OpenEdgeTable.TableId
               OpenEdgeTableColumn.OEColumnName       = OEColumnName
               OpenEdgeTableColumn.OEColumnDataType   = OEDataType
               OpenEdgeTableColumn.OECalculatedColumn = TRUE 
               OpenEdgeTableColumn.ColumnName         = OEColumnName
               OpenEdgeTableColumn.OEMimeType         = OEMimeType.
               
        RETURN TRUE.       

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:    Note: We use OETableNames as parameter, but the view holds TableNames.
	------------------------------------------------------------------------------*/
	METHOD LOGICAL registerView( pcViewName        AS CHARACTER, 
	                             pcOEMasterTables  AS CHARACTER,
	                             piForeignKeyDepth AS INTEGER):
	                                 
        DEFINE VARIABLE cParentTable AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cChildTable  AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iParentTable AS INTEGER   NO-UNDO.
        DEFINE VARIABLE iChildTable  AS INTEGER   NO-UNDO.
        
        DEFINE VARIABLE cServiceId   AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSep         AS CHARACTER NO-UNDO.
        
        DEFINE VARIABLE lcList       AS LONGCHAR  NO-UNDO.
        
        EMPTY TEMP-TABLE ttViewTable.
        EMPTY TEMP-TABLE ttViewRelation.
        
        DEFINE BUFFER ParentTable FOR OpenEdgeTable.
        DEFINE BUFFER ChildTable  FOR OpenEdgeTable.
        DEFINE BUFFER Relation    FOR OpenEdgeDataRelation.
                	          
        FIND OpenEdgeService WHERE OpenEdgeService.ServiceName = ServiceName NO-ERROR.
        IF NOT AVAILABLE OpenEdgeService THEN 
            RETURN FALSE.
            
        FIND OpenEdgeView OF OpenEdgeService 
             WHERE OpenEdgeView.ViewName = pcViewName NO-ERROR.
        IF AVAILABLE OpenEdgeView THEN 
            RETURN FALSE.          
            
        cServiceId = OpenEdgeService.ServiceId.           	          
               
        /* Add the master tables and all relations between these tables */        	          
        DO iParentTable = 1 TO NUM-ENTRIES(pcOEMasterTables):
            cParentTable = TRIM(ENTRY(iParentTable,pcOEMasterTables)).
            FIND ParentTable WHERE ParentTable.ServiceId   = cServiceId 
                             AND   ParentTable.OETableName = cParentTable NO-ERROR.
            IF NOT AVAILABLE OpenEdgeTable THEN 
                RETURN FALSE.  
                
            DO TRANSACTION:     
                CREATE ttViewTable.
                ASSIGN ttViewTable.TableId     = ParentTable.TableId
                       ttViewTable.MasterTable = TRUE.    
            END.  
                    	  
            DO iChildTable = 1 TO NUM-ENTRIES (pcOEMasterTables):
                cChildTable = TRIM(ENTRY(iChildTable,pcOEMasterTables)).
                FIND ChildTable WHERE ChildTable.ServiceId   = cServiceId 
                                AND   ChildTable.OETableName = cChildTable NO-ERROR.
                IF NOT AVAILABLE ChildTable THEN 
                    RETURN FALSE.
                FOR EACH Relation WHERE Relation.ParentTableId = ParentTable.TableId
                                  AND   Relation.ChildTableId  = ChildTable.TableId:
                    FIND ttViewRelation WHERE ttViewRelation.RelationId = Relation.RelationId NO-ERROR.
                    IF NOT AVAILABLE ttViewRelation THEN 
                    DO TRANSACTION:                                 
                       CREATE ttViewRelation.
                       ASSIGN ttViewRelation.RelationId = Relation.RelationId.
                    END.                         
        	    END.
        	END.
        END.	 

        /* add foreign keys - recursive up to piForeignKeyDepth */
        IF piForeignKeyDepth > 0 THEN 
        FOR EACH ttViewTable WHERE ttViewTable.MasterTable = TRUE:
            addViewForeignKeys(cServiceId,ttViewTable.TableId, 1, piForeignKeyDepth).   
        END.    

        DO TRANSACTION:
            CREATE OpenEdgeView.
            ASSIGN OpenEdgeView.ServiceId  = cServiceId
                   OpenEdgeView.ViewName   = pcViewName.
                   
            cSep = "".   
            lcList = "".    
            FOR EACH ttViewTable, FIRST OpenEdgeTable WHERE OpenEdgeTable.ServiceId = OpenEdgeView.ServiceId
                                                      AND   OpenEdgeTable.TableId   = ttViewTable.TableId
                                                      BY    OpenEdgeTable.TableName: 
                   ASSIGN lcList = lcList + cSep + OpenEdgeTable.TableName
                          cSep   = ",".
            END.  
            ASSIGN OpenEdgeView.ViewTables = lcList.   

            cSep = "".
            lcList = "".
            FOR EACH ttViewRelation, FIRST Relation WHERE Relation.ServiceId  = OpenEdgeView.ServiceId
                                                    AND   Relation.RelationId = ttViewRelation.RelationId
                                                    BY    Relation.ParentTableName: 
                   ASSIGN lcList = lcList + cSep + Relation.RelationName
                          cSep   = ",".
            END.  
            ASSIGN OpenEdgeView.ViewRelations = lcList.    
        END. 

        RETURN TRUE.
 
        FINALLY:
            EMPTY TEMP-TABLE ttViewTable.
            EMPTY TEMP-TABLE ttViewRelation.
        END FINALLY.

	END METHOD.

    /* recursive! */
    METHOD PRIVATE VOID addViewForeignKeys ( pcServiceId AS CHARACTER, pcTableId AS CHARACTER, piLevel AS INTEGER, piMaxLevel AS INTEGER):
        
        DEFINE BUFFER FKRelation     FOR OpenEdgeDataRelation.
        DEFINE BUFFER ttViewRelation FOR ttViewRelation.
        DEFINE BUFFER ttViewTable    FOR ttViewTable.
        
        DEFINE VARIABLE lNew AS LOGICAL NO-UNDO.
        
        FOR EACH FKRelation WHERE FKRelation.ServiceId    = pcServiceId
                            AND   FKRelation.ChildTableId = pcTableId:
             FIND ttViewRelation WHERE ttViewRelation.RelationId = FKRelation.RelationId NO-ERROR.
             IF AVAILABLE ttViewRelation THEN 
                NEXT.                  
 
             lNew = FALSE.
             FIND ttViewTable WHERE ttViewTable.TableId = FKRelation.ParentTableId NO-ERROR.
             DO TRANSACTION:
                 IF NOT AVAILABLE ttViewTable THEN 
                 DO:
                     CREATE ttViewTable.
                     ASSIGN ttViewTable.TableId = FKRelation.ParentTableId.
                     lNew = TRUE.
                 END.      
                 CREATE ttViewRelation.
                 ASSIGN ttViewRelation.RelationId = FKRelation.RelationId.
             END.
                
             IF /*lNew AND*/ piLevel < piMaxLevel THEN 
                addViewForeignKeys(pcServiceId,FKRelation.ParentTableId, piLevel + 1, piMaxLevel).   
        END.
        
    END METHOD.
    
    /*------------------------------------------------------------------------------
     Purpose: Returns the relation type as
              'one-many', 'many-one' or 'one-one' 
     Notes:   New version based on index-information 
    ------------------------------------------------------------------------------*/
    METHOD PRIVATE CHARACTER relationType( phRelation AS HANDLE ):
        
        DEFINE VARIABLE cRelationFields AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE cChildFields    AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE cParentFields   AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE iField          AS INTEGER    NO-UNDO.
        DEFINE VARIABLE cSep            AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE lParentUnique   AS LOGICAL    NO-UNDO.
        DEFINE VARIABLE lChildUnique    AS LOGICAL    NO-UNDO.
        DEFINE VARIABLE cChildRel   AS CHARACTER  NO-UNDO.
        DEFINE VARIABLE cParentRel  AS CHARACTER  NO-UNDO.

        IF NOT VALID-HANDLE(phRelation) THEN
            RETURN '':U.

        ASSIGN cRelationFields  = phRelation:RELATION-FIELDS.
    
        DO iField = 1 TO NUM-ENTRIES(cRelationFields) BY 2:
           ASSIGN cParentFields = cParentFields + cSep + ENTRY(iField,cRelationFields)
                  cChildFields  = cChildFields  + cSep + ENTRY(iField + 1,cRelationFields)
                  cSep          = ",":U.
        END. 
    
        lParentUnique = isUniqueKey(phRelation:PARENT-BUFFER,cParentFields).
        lChildUnique  = isUniqueKey(phRelation:CHILD-BUFFER,cChildFields).
    
        IF lParentUnique THEN
          cParentRel = 'One':U.
        ELSE 
          cParentRel = 'Many':U.
    
        IF phRelation:REPOSITION OR lChildUnique THEN 
          cChildRel = 'One':U.
        ELSE 
          cChildRel = 'Many':U.
    
       RETURN cParentRel + '-':U + cChildRel. 

    END METHOD.
     
   
    /*------------------------------------------------------------------------------
     Purpose: Returns if a list of fields matches all fields of a unique index.
     Notes:   KEYS is misleading if a relation is based on alternate keys.
    ------------------------------------------------------------------------------*/
    METHOD PRIVATE LOGICAL isUniqueKey( phBuffer AS HANDLE, pcFields AS CHARACTER ):

        DEFINE VARIABLE cIndexInformation   AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iIndex              AS INTEGER   NO-UNDO.
        DEFINE VARIABLE lUniqueKey          AS LOGICAL   NO-UNDO.
        DEFINE VARIABLE iIndexField         AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cIndexFieldName     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iNumEntries         AS INTEGER   NO-UNDO.
        DEFINE VARIABLE iPos                AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cFieldsToMatch      AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cIndexFields        AS CHARACTER NO-UNDO.
        
        DO iIndex = 1 TO 1000:
            cIndexInformation = phBuffer:INDEX-INFORMATION(iIndex).
            IF cIndexInformation = ? THEN
                LEAVE.
            /* Name,Unique,Primary,WordIdx */
            IF ENTRY(2,cIndexInformation) <> "1":U THEN /* Not a unique index */
                NEXT.
            iNumEntries = NUM-ENTRIES(cIndexInformation).
    
            /* IndexFieldName,SortOrder,.... */
            cIndexFields = "":U.
            DO iIndexField = 5 TO iNumEntries BY 2:
                cIndexFields = cIndexFields + (IF cIndexFields > "":U THEN ",":U ELSE "":U)
                             + ENTRY(iIndexField,cIndexInformation).
            END.
            IF NUM-ENTRIES(pcFields) <> NUM-ENTRIES(cIndexFields) THEN
                NEXT.
            cFieldsToMatch = pcFields.
            DO iIndexField = 1 TO NUM-ENTRIES(cIndexFields):
                iPos = LOOKUP(ENTRY(iIndexField,cIndexFields),cFieldsToMatch).
                IF iPos > 0 THEN
                    ASSIGN ENTRY(iIndexField,cIndexFields) = "":U
                           ENTRY(iPos,cFieldsToMatch)      = "":U.
            END.
            ASSIGN cFieldsToMatch = TRIM(cFieldsToMatch,",":U)
                   cIndexFields   = TRIM(cIndexFields,",":U).
            /* If both lists are empty then we found a unique index matching all required fields */
            IF cFieldsToMatch = "":U AND cIndexFields = "":U THEN
               RETURN TRUE.
        END.
        RETURN FALSE.
    END METHOD.

END CLASS.