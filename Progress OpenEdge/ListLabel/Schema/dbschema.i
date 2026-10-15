
/*------------------------------------------------------------------------
    File        : dbschema.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : 
    Created     : Thu Jan 28 08:40:19 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

    /* 1. Dataset to build information from a connected database */
    DEFINE TEMP-TABLE ttDatabaseInfo NO-UNDO 
        FIELD DatabaseName AS CHARACTER.
    
    DEFINE TEMP-TABLE ttTableInfo NO-UNDO
        FIELD TableName    AS CHARACTER 
        FIELD TableWords   AS CHARACTER 
        INDEX pk IS PRIMARY UNIQUE TableName
        INDEX words IS WORD-INDEX TableWords.
        
    DEFINE TEMP-TABLE ttIndexInfo NO-UNDO 
        FIELD TableName        AS CHARACTER
        FIELD IndexName        AS CHARACTER
        FIELD IndexFields      AS CHARACTER
        FIELD NumIndexFields   AS INTEGER  
        FIELD IndexMatch       AS CHARACTER 
        FIELD PrimaryIndex     AS LOGICAL 
        FIELD UniqueIndex      AS LOGICAL
        FIELD IndexFlags       AS CHARACTER 
        INDEX pk  IS PRIMARY UNIQUE TableName IndexName.

     DEFINE TEMP-TABLE ttRelationInfo  NO-UNDO 
        FIELD RelationIdentifier    AS CHARACTER 
        FIELD ParentTableName       AS CHARACTER 
        FIELD ChildTableName        AS CHARACTER 
        FIELD ParentRole            AS CHARACTER 
        FIELD ChildRole             AS CHARACTER 
        FIELD ParentChildRoleNumber AS INTEGER
        FIELD RelationName          AS CHARACTER 
        FIELD RelationType          AS CHARACTER  
        FIELD ParentFields          AS CHARACTER 
        FIELD ChildFields           AS CHARACTER 
        FIELD RelationFields        AS CHARACTER 
        FIELD ParentIndexName       AS CHARACTER 
        FIELD ParentIndexFlags      AS CHARACTER
        FIELD ParentIndexed         AS LOGICAL  
        FIELD ChildIndexName        AS CHARACTER
        FIELD ChildIndexFlags       AS CHARACTER 
        FIELD ChildIndexed          AS LOGICAL
        FIELD UserDefined           AS LOGICAL
        FIELD Inactive              AS LOGICAL 
        INDEX pk IS PRIMARY UNIQUE RelationIdentifier
        /* Used to generate a unique RelationName */
        INDEX akRoles IS UNIQUE ParentRole ChildRole ParentChildRoleNumber
        INDEX akRelationName IS UNIQUE RelationName
        INDEX ie ChildTableName ParentTableName.

    DEFINE DATASET dsDbInfo FOR ttDatabaseInfo, ttTableInfo, ttIndexInfo, ttRelationInfo.
    
    
    
    