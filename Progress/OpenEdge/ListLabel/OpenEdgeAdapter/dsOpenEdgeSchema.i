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
    File        : dsOpenEdgeSchema.i
    Purpose     : OpenEdge Schema Meta Data for LL

    Syntax      :

    Description : OpenEdge Service Meta Data
                  This data gives LL the knowledge how to get data from 
                  an OpenEdge Service. It's also used to create the 
                  objects in LL.
                  Supports multiple services
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sat Dec 19 06:54:03 CET 2015
    Notes       :
  ----------------------------------------------------------------------*/

  DEFINE TEMP-TABLE OpenEdgeService NO-UNDO 
    FIELD ServiceId                 AS CHARACTER SERIALIZE-HIDDEN
    FIELD ServiceName               AS CHARACTER
    FIELD ServiceClassName          AS CHARACTER
    FIELD SupportsSorting           AS LOGICAL 
    FIELD SupportsAdvancedSorting   AS LOGICAL
    FIELD SupportsCount             AS LOGICAL 
    FIELD SupportsFiltering         AS LOGICAL 
    FIELD SupportsGetParentRow      AS LOGICAL
    FIELD SupportsAnyBaseTable      AS LOGICAL
    FIELD SupportsCaching           AS LOGICAL  
    INDEX pk IS PRIMARY UNIQUE ServiceId
    INDEX ak IS UNIQUE ServiceName.
    
  /* The TableName is:
      - a temp-table = buffer-name in a prodataset
      - a buffer-name for a DataBase Table in a database
      In some cases we have have the same physical table more than once
      like for billingAdresse shippingAdresse.     
  */  
  DEFINE TEMP-TABLE OpenEdgeTable NO-UNDO
    FIELD TableId             AS CHARACTER SERIALIZE-HIDDEN 
    FIELD ServiceId           AS CHARACTER SERIALIZE-HIDDEN 
    FIELD OETableName         AS CHARACTER
    FIELD OEDbTableName       AS CHARACTER
    FIELD OECalculatedTable   AS LOGICAL
    FIELD OECachedTable       AS LOGICAL
    FIELD TableName           AS CHARACTER 
    INDEX pk IS PRIMARY UNIQUE TableId
    INDEX ak IS UNIQUE ServiceId TableName.
    
  /* Note: We don't support relations between OpenEdge Arrays.
     And there is a rule for a name of an array field in LL <Column>[n] -> <Column>_<n>.
  */  
  DEFINE TEMP-TABLE OpenEdgeTableColumn NO-UNDO 
    FIELD TableId            AS CHARACTER SERIALIZE-HIDDEN 
    FIELD ColumnId           AS CHARACTER SERIALIZE-HIDDEN 
    FIELD OEColumnName       AS CHARACTER
    FIELD OEColumnIndex      AS INTEGER  
    FIELD OEColumnDataType   AS CHARACTER
    FIELD OEColumnFormat     AS CHARACTER
    FIELD OEColumnDecimals   AS INTEGER  
    FIELD OESampleValue      AS CHARACTER
    FIELD OEMimeType         AS CHARACTER
    FIELD OECalculatedColumn AS LOGICAL
    FIELD ColumnName         AS CHARACTER   
    FIELD DataType           AS CHARACTER
    FIELD LlFieldType        AS CHARACTER
    INDEX pk IS PRIMARY UNIQUE ColumnId
    INDEX ak IS UNIQUE TableId OEColumnName OEColumnIndex.
      
  DEFINE TEMP-TABLE OpenEdgeDataRelation NO-UNDO
    FIELD RelationId                AS CHARACTER SERIALIZE-HIDDEN 
    FIELD ParentTableId             AS CHARACTER SERIALIZE-HIDDEN
    FIELD ChildTableId              AS CHARACTER SERIALIZE-HIDDEN
    FIELD ServiceId                 AS CHARACTER SERIALIZE-HIDDEN
    FIELD OERelationFields          AS CHARACTER  
    FIELD OERelationName            AS CHARACTER
    FIELD ParentTableName           AS CHARACTER 
    FIELD ParentColumnName          AS CHARACTER 
    FIELD ChildTableName            AS CHARACTER 
    FIELD ChildColumnName           AS CHARACTER  
    FIELD RelationName              AS CHARACTER
    INDEX pk IS UNIQUE RelationId
    INDEX ak IS UNIQUE ParentTableId ChildTableId OERelationFields
    /* 20181128 - The relation name is unique in LL. So, we ensure this here now. */
    INDEX akRelation OERelationName
    INDEX ie ChildTableId 
    INDEX ie2 ServiceId ParentTableName
    .    

 DEFINE TEMP-TABLE OpenEdgeView NO-UNDO 
    FIELD ViewId              AS CHARACTER SERIALIZE-HIDDEN 
    FIELD ServiceId           AS CHARACTER SERIALIZE-HIDDEN 
    FIELD ViewName            AS CHARACTER 
    FIELD ViewTables          AS CLOB  
    FIELD ViewRelations       AS CLOB 
    INDEX pk IS PRIMARY UNIQUE ViewId
    INDEX ak IS UNIQUE ServiceId ViewName.
    
 DEFINE DATASET dsOpenEdgeSchema SERIALIZE-NAME "OpenEdgeServiceCatalog" FOR OpenEdgeService, OpenEdgeTable, OpenEdgeTableColumn, OpenEdgeDataRelation, OpenEdgeView 

    DATA-RELATION ServiceTables FOR OpenEdgeService, OpenEdgeTable
        RELATION-FIELDS (ServiceId,ServiceId) NESTED 
    DATA-RELATION TableColumns FOR OpenEdgeTable, OpenEdgeTableColumn
        RELATION-FIELDS (TableId,TableId) NESTED 
    DATA-RELATION DataRelations FOR OpenEdgeService, OpenEdgeDataRelation
        RELATION-FIELDS (ServiceId,ServiceId) NESTED
    DATA-RELATION ServiceViews FOR OpenEdgeService, OpenEdgeView
        RELATION-FIELDS (ServiceId,ServiceId) NESTED 
    .
    
        
        
 
         
    
    
    
    
    
    
  
    
    
    
    
  