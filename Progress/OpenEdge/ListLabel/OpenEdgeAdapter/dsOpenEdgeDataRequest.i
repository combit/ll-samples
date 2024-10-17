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
    File        : dsOpenEdgeDataRequest.i
    Purpose     : Dataset for a data provide request

    Syntax      :

    Description : Dataset to read the Json request from the data provider.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Dec 30 06:08:58 CET 2015
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */
DEFINE TEMP-TABLE OEDataTable NO-UNDO
    FIELD TableNumber          AS INTEGER 
    FIELD OETableName          AS CHARACTER
    FIELD OEDbTableName        AS CHARACTER
    FIELD OECalculatedTable    AS LOGICAL 
    FIELD OETableWhere         AS CHARACTER
    FIELD OETableSortBy        AS CHARACTER
    FIELD OETableColumns       AS CHARACTER
    FIELD OECalculatedColumns  AS CHARACTER
    FIELD OEParentTableName    AS CHARACTER 
    FIELD OEParentTableWhere   AS CHARACTER 
    INDEX pk IS PRIMARY UNIQUE TableNumber
    INDEX ak IS UNIQUE OETableName
    .
    
DEFINE TEMP-TABLE OEDataRelation   NO-UNDO 
    FIELD OETableName          AS CHARACTER 
    FIELD OEChildTableName     AS CHARACTER
    FIELD OERelationName       AS CHARACTER 
    FIELD OERelationFields     AS CHARACTER
    INDEX pk IS PRIMARY UNIQUE OETableName OEChildTableName
    INDEX ie OEChildTableName
    .

/* Multi Value Filter */    
DEFINE TEMP-TABLE OEAdvancedFilter NO-UNDO 
    FIELD OETableName           AS CHARACTER 
    FIELD OEColumnName          AS CHARACTER 
    FIELD OEDataType            AS CHARACTER 
    FIELD OEFilterName          AS CHARACTER 
    FIELD OEFilterOperator      AS CHARACTER
    FIELD OEValueDelimiter      AS CHARACTER
    FIELD OEFilterValues        AS CLOB
    INDEX pk IS PRIMARY UNIQUE OETableName OEFilterName. 
    
/* Native Function Call */
DEFINE TEMP-TABLE OEFunctionCall NO-UNDO 
    FIELD OEFunctionCallGuid     AS CHARACTER
    FIELD TableNumber            AS INTEGER
    FIELD OETableName            AS CHARACTER
    FIELD OETableWhere           AS CHARACTER 
    FIELD OEFunctionName         AS CHARACTER
    FIELD OEExpression           AS CHARACTER
    FIELD OEDistinct             AS LOGICAL
    INDEX pk IS PRIMARY UNIQUE OEFunctionCallGuid. 
    
DEFINE DATASET dsOpenEdgeDataRequest SERIALIZE-NAME "OpenEdgeDataRequest"
       FOR OEDataTable, OEDataRelation, OEAdvancedFilter, OEFunctionCall
       .
       
               
     
        

    
    
    
    