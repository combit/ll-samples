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
    File        : dbschema
    Purpose     : Generate all relations for a db by just reading the
                  schema.
                  The rule is (and this is the only one)
                  - A PARENT table (alias foreign key) inherits all 
                    UNIQUE INDEX FIELDS TO a CHILD table.
                  - This class loops though all unique indexes and tries
                    to find all matching child tables.
                  - If there is more than one relation between two table
                    found, the parent index with less components wins.
                  - 1:1 relations would be found twice.
                  - This class will propably generate to much relations,
                    but it's even better than nothing.
                  - If the field names don't match (role names of keys) 
                    this class will not be able to find those.
                  - You may generate code from the result...
                      
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sun Jan 17 17:56:25 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

&GLOBAL DT "integer,int64,character,decimal,date,datetime,datetime-tz,logical"

CLASS ListLabel.Schema.dbschema: 

    {ListLabel/Schema/dbschema.i}
    {ListLabel/Schema/ttField.i}

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC dbschema (  ):
		SUPER ().
		buildSchema().
	END CONSTRUCTOR.
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE VOID buildSchema( ):
	    
	    DEFINE VARIABLE cWords AS CHARACTER NO-UNDO.
	    DEFINE VARIABLE iDT    AS INTEGER   NO-UNDO.
	    DEFINE VARIABLE cSep   AS CHARACTER NO-UNDO.
	    
	    CREATE ttDatabaseInfo.
	    ASSIGN ttDatabaseInfo.DatabaseName = LDBNAME ("DICTDB").
	    
	    FOR EACH DICTDB._file WHERE DICTDB._file._hidden = FALSE NO-LOCK :
	        
	        CREATE ttTableInfo.
	        ASSIGN ttTableInfo.TableName = _file._file-name.
	        
	        cSep = "".
	        
	        FOR EACH DICTDB._field OF _file 
	                 WHERE LOOKUP(_field._data-type,{&DT}) > 0
	                 AND   _field._extent = 0 NO-LOCK:
                ASSIGN ttTableInfo.TableWords = ttTableInfo.TableWords + cSep
                                              + SUBSTITUTE("<&1@&2>",_field._field-name,LOOKUP(_field._data-type,{&DT}))
                       cSep                   = " ".
	        END.
	        
	        FOR EACH DICTDB._index OF _file 
	                 WHERE _index._index-name <> "default" 
	                 AND   _index._active     = TRUE 
                     AND   _index._wordidx    = ? NO-LOCK:
	            CREATE ttIndexInfo.
	            ASSIGN ttIndexInfo.TableName    = ttTableInfo.TableName
	                   ttIndexInfo.IndexName    = _index._index-name
	                   ttIndexInfo.PrimaryIndex = RECID (_index) = _file._prime-index
	                   ttIndexInfo.UniqueIndex  = _index._unique.
	                   
	            IF ttIndexInfo.PrimaryIndex THEN 
	               ttIndexInfo.IndexFlags = "P".
                IF ttIndexInfo.UniqueIndex THEN 
                   ttIndexInfo.IndexFlags = ttIndexInfo.IndexFlags + "U".
	            
	            FOR EACH DICTDB._index-field OF _index NO-LOCK,
	                FIRST DICTDB._field OF _Index-field NO-LOCK:
	                ASSIGN ttIndexInfo.IndexFields = ttIndexInfo.IndexFields 
	                                               + (IF ttIndexInfo.IndexFields > "" THEN "," ELSE "") 
	                                               + _field._field-name
	                       ttIndexInfo.IndexMatch  = ttIndexInfo.IndexMatch 
	                                               + (IF ttIndexInfo.IndexMatch > "" THEN " & " ELSE "") 
	                                               + SUBSTITUTE("<&1@&2>",_field._field-name,LOOKUP(_field._data-type,{&DT}))
	                       ttIndexInfo.NumIndexFields = ttIndexInfo.NumIndexFields + 1                        
	                                               .
	            END.
	        END.
	    END.    

        DEFINE VARIABLE cEntry     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iEntry     AS INTEGER   NO-UNDO.
        DEFINE VARIABLE iNumber    AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cIndexName AS CHARACTER NO-UNDO.
        DEFINE VARIABLE lFullMatch AS LOGICAL   NO-UNDO.
        DEFINE VARIABLE cIdent     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cFlags     AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iField     AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cField     AS CHARACTER NO-UNDO.

        DEFINE BUFFER b_RelationInfo FOR ttRelationInfo.

        FOR EACH ttIndexInfo WHERE ttIndexInfo.UniqueIndex = TRUE
            BY ttIndexInfo.NumIndexFields:

            TableLoop:
            FOR EACH ttTableInfo WHERE ttTableInfo.TableWords CONTAINS ttIndexInfo.IndexMatch
                                 AND   ttTableInfo.TableName <> ttIndexInfo.TableName :
                
                /* 20161115 - The contains finds to much - that drives me crazy :-) */
                FIND DICTDB._file WHERE DICTDB._file._file-name = ttTableInfo.TableName NO-LOCK.
                DO iField = 1 TO NUM-ENTRIES(ttIndexInfo.IndexFields):
                    cField = TRIM(ENTRY(iField,ttIndexInfo.IndexFields)).
                    FIND DICTDB._field OF DICTDB._file WHERE DICTDB._field._field-name = cField NO-ERROR.
                    IF NOT AVAILABLE _field THEN 
                        NEXT TableLoop.
                END.
                
                /* It doesn't make sense to have more than one foreign-key relation between two tables!? 
                   The relations with less index fields wins */
                iNumber = 1.
                FIND LAST ttRelationInfo WHERE ttRelationInfo.ParentRole = ttIndexInfo.TableName
                                         AND   ttRelationInfo.ChildRole  = ttTableInfo.TableName USE-INDEX akRoles NO-ERROR .
                IF AVAILABLE ttRelationInfo THEN 
                    ASSIGN iNumber = ttRelationInfo.ParentChildRoleNumber + 1.                    
                         
/*
RelationIdentifier = String.Format("{0}.{1}@{2}.{3}", ParentTableName, ParentColumnName.Replace("\t", "_"), ChildTableName, ChildColumnName.Replace("\t", "_"));

*/
                cIdent = SUBSTITUTE("&1.&2@&3.&4",ttIndexInfo.TableName, 
                                                  REPLACE(ttIndexInfo.IndexFields,",","_"),
                                                  ttTableInfo.TableName,
                                                  REPLACE(ttIndexInfo.IndexFields,",","_")).     

                FIND b_RelationInfo WHERE b_RelationInfo.RelationIdentifier = cIdent NO-ERROR.
                IF AVAILABLE b_RelationInfo THEN 
                    NEXT.

                CREATE ttRelationInfo.
                ASSIGN ttRelationInfo.RelationIdentifier        = cIdent
                       ttRelationInfo.ParentTableName           = ttIndexInfo.TableName
                       ttRelationInfo.ParentRole                = ttRelationInfo.ParentTableName
                       ttRelationInfo.ChildTableName            = ttTableInfo.TableName
                       ttRelationInfo.ChildRole                 = ttRelationInfo.ChildTableName
                       ttRelationInfo.ParentFields              = ttIndexInfo.IndexFields
                       ttRelationInfo.ChildFields               = ttIndexInfo.IndexFields
                       ttRelationInfo.ParentChildRoleNumber     = iNumber
                       ttRelationInfo.RelationName              = SUBSTITUTE("&1_&2&3",ttRelationInfo.ParentRole,ttRelationInfo.ChildRole,
                                                                                       IF iNumber > 1 THEN STRING(iNumber) ELSE "" )
                       ttRelationInfo.ParentIndexName           = ttIndexInfo.IndexName
                       ttRelationInfo.ParentIndexFlags          = ttIndexInfo.IndexFlags
                       ttRelationInfo.ParentIndexed             = TRUE
                       ttRelationInfo.RelationType              = "one-many".
                     
                findIndex(ttRelationInfo.ChildTableName,ttIndexInfo.IndexFields, OUTPUT cIndexName, OUTPUT lFullMatch, OUTPUT cFlags ).
                IF cIndexName > "" THEN 
                DO:
                    ASSIGN ttRelationInfo.ChildIndexName  = cIndexName
                           ttRelationInfo.ChildIndexFlags = cFlags
                           ttRelationInfo.ChildIndexed    = TRUE
                           ttRelationInfo.RelationType    = "one-one" WHEN lFullMatch.
                END.
                           
                DO iEntry = 1 TO NUM-ENTRIES (ttIndexInfo.IndexFields):
                    ASSIGN cEntry                    = ENTRY (iEntry,ttIndexInfo.IndexFields)
                           ttRelationInfo.RelationFields = ttRelationInfo.RelationFields 
                                                     + (IF iEntry = 1 THEN "" ELSE ",")
                                                     + SUBSTITUTE("&1,&1",cEntry).
                END.
            END.
        END.
		
		RETURN.

	END METHOD.
	
	/*------------------------------------------------------------------------------
	 Purpose: Find an index that has the fields as leading components.
	 Notes:   Order of pcFields doesn't matter.
	------------------------------------------------------------------------------*/
	METHOD PUBLIC LOGICAL FindIndex( INPUT  pcTableName AS CHARACTER, 
	                                 INPUT  pcFields    AS CHARACTER,
	                                 OUTPUT pcIndexName AS CHARACTER,
	                                 OUTPUT plFullMatch AS LOGICAL,
	                                 OUTPUT pcFlags     AS CHARACTER ):
		
		DEFINE VARIABLE iFieldsToMatch  AS INTEGER   NO-UNDO.
		DEFINE VARIABLE iMatchingFields AS INTEGER   NO-UNDO.
		DEFINE VARIABLE iField          AS INTEGER   NO-UNDO.
		DEFINE VARIABLE cField          AS CHARACTER NO-UNDO.
		
		iFieldsToMatch = NUM-ENTRIES (pcFields).
		
		DEFINE BUFFER ttIndexInfo FOR ttIndexInfo.
		
		FOR EACH ttIndexInfo WHERE ttIndexInfo.TableName       = pcTableName
		                     AND   ttIndexInfo.NumIndexFields >= iFieldsToMatch
		                     BY ttIndexInfo.NumIndexFields:
		    
		    iMatchingFields = 0.
		    
		    DO iField = 1 TO NUM-ENTRIES(ttIndexInfo.IndexFields):
		          cField = ENTRY(iField,ttIndexInfo.IndexFields).
		          IF LOOKUP(cField,pcFields) > 0 THEN 
		          DO:
		              iMatchingFields = iMatchingFields + 1.
		              IF iMatchingFields = iFieldsToMatch THEN
		              DO: 
		                  pcIndexName = ttIndexInfo.IndexName. /* Here it is! */
		                  plFullMatch = ttIndexInfo.UniqueIndex AND NUM-ENTRIES(pcFields) = ttIndexInfo.NumIndexFields.
		                  pcFlags     = ttIndexInfo.IndexFlags.
		                  RETURN TRUE.
		              END.    
		          END.
		          ELSE LEAVE.
		    END.
		END.

		RETURN FALSE .

	END METHOD.
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC CHARACTER getTableUniqueIndexNames( pcTableName AS CHARACTER ):
		
		DEFINE VARIABLE cNames AS CHARACTER NO-UNDO.
		
        FOR EACH ttIndexInfo WHERE ttIndexInfo.TableName    = pcTableName 
                             AND   ttIndexInfo.UniqueIndex  = TRUE 
                             BY    ttIndexInfo.PrimaryIndex = TRUE:
            cNames = cNames + (IF cNames > "" THEN "," ELSE "" )
                   + SUBSTITUTE("&1 &2",ttIndexInfo.IndexFlags,ttIndexInfo.IndexName).                      
        END.

		RETURN cNames.

	END METHOD.

    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID getSchema( OUTPUT DATASET dsDbInfo ):
		RETURN.
	END METHOD.
	
    METHOD PUBLIC VOID getSchemaDataset( OUTPUT DATASET dsDbInfo ):
        RETURN.
    END METHOD.
	
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID getTableFields( pcTableName     AS CHARACTER, 
	                                   plExcludeArrays AS LOGICAL, 
	                                   OUTPUT TABLE ttField ):
		EMPTY TEMP-TABLE ttField.
		FOR FIRST DICTDB._file WHERE DICTDB._file._file-name = pcTableName NO-LOCK,
		    EACH DICTDB._field OF DICTDB._file NO-LOCK:
		    
		    IF _field._extent > 0 AND plExcludeArrays = TRUE THEN 
		      NEXT.
		    
		    CREATE ttField.
		    ASSIGN ttField.FieldName   = _field._field-name
		           ttField.DataType    = _field._data-type
		           ttField.FieldOrder  = _field._order
		           ttField.FieldExtent = _field._extent.
		END.
		RETURN.
	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID getIndexFields( pcTableName     AS CHARACTER, 
                                       pcIndexName     AS CHARACTER,
                                       OUTPUT TABLE ttField ):
        EMPTY TEMP-TABLE ttField.
        FOR FIRST DICTDB._file WHERE DICTDB._file._file-name = pcTableName NO-LOCK,
            FIRST DICTDB._index OF DICTDB._file WHERE _index._index-name = pcIndexName NO-LOCK,
            EACH DICTDB._index-field OF DICTDB._index NO-LOCK,
            FIRST DICTDB._field OF DICTDB._index-field NO-LOCK
            BY DICTDB._index-field._index-seq:
            
            CREATE ttField.
            ASSIGN ttField.FieldName   = _field._field-name
                   ttField.DataType    = _field._data-type
                   ttField.FieldOrder  = _index-seq
                   ttField.FieldExtent = _field._extent. /* always 0 */
        END.
        RETURN.
    END METHOD.

END CLASS.