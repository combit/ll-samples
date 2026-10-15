
/*------------------------------------------------------------------------
    File        : dbrelations.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : 
    Created     : Sat Jan 30 06:18:24 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

    DEFINE TEMP-TABLE ttDatabase NO-UNDO 
        FIELD DatabaseName AS CHARACTER.
    
    DEFINE TEMP-TABLE ttTable NO-UNDO
        FIELD TableName     AS CHARACTER
        FIELD Inactive      AS LOGICAL 
        INDEX pk IS PRIMARY UNIQUE TableName.
 
     DEFINE TEMP-TABLE ttRelation NO-UNDO 
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
  
    DEFINE DATASET dsRelation FOR ttDatabase, ttTable, ttRelation.
