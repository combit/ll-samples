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
    File        : OpenEdgeDataRequest
    Purpose     : Object to hold a request from the data provider.
    Syntax      : 
    Description : 
    Author(s)   : 23.01.2016 Thomas Wurl, Taste IT Consulting
    Created     : Wed Dec 30 06:28:54 CET 2015
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeDataRequest: 
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeDataRequest.i}
    
    DEFINE PRIVATE VARIABLE iTableNumber AS INTEGER NO-UNDO.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeDataRequest (  ):
		SUPER ().
	END CONSTRUCTOR.

    CONSTRUCTOR PUBLIC OpenEdgeDataRequest ( plcJsonData AS LONGCHAR ):
        SUPER ().
        DATASET dsOpenEdgeDataRequest:READ-JSON ("LONGCHAR",plcJsonData).
    END CONSTRUCTOR.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID addTable( pcOETableName    AS CHARACTER, 
	                             pcOEDbTableName  AS CHARACTER,
	                             pcOETableWhere   AS CHARACTER,
	                             pcOETableSortBy  AS CHARACTER,
	                             pcOETableColumns AS CHARACTER):
	                                 
        iTableNumber = iTableNumber + 1.
        CREATE OEDataTable.
        ASSIGN OEDataTable.TableNumber    = iTableNumber
               OEDataTable.OETableName    = pcOETableName
               OEDataTable.OEDbTableName  = pcOEDbTableName
               OEDataTable.OETableWhere   = pcOETableWhere
               OEDataTable.OETableSortBy  = pcOETableSortBy
               OEDataTable.OETableColumns = pcOETableColumns.    
	                                 
		RETURN.
	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID addRelation( pcOETableName          AS CHARACTER,
                                    pcOEChildTableName     AS CHARACTER,
                                    pcOERelationFields     AS CHARACTER,
                                    pcOERelationName       AS CHARACTER):
        
        CREATE OEDataRelation.
        ASSIGN OEDataRelation.OETableName      = pcOETableName
               OEDataRelation.OEChildTableName = pcOEChildTableName
               OEDataRelation.OERelationName   = pcOERelationName
               OEDataRelation.OERelationFields = pcOERelationFields.                                      
                                          
        RETURN.

    END METHOD.
    
    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID clearRequest ():
        
        DATASET dsOpenEdgeDataRequest:EMPTY-DATASET.
        iTableNumber = 0.
        
        RETURN.

    END METHOD.
 
 	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID getDataset( OUTPUT DATASET dsOpenEdgeDataRequest ):
		
		RETURN.

	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR getJson(  ):
        
        DEFINE VARIABLE lcData AS LONGCHAR NO-UNDO.
        DATASET dsOpenEdgeDataRequest:WRITE-JSON ("LONGCHAR",lcData,TRUE).
        RETURN lcData.

    END METHOD.

END CLASS.