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
    File        : DatasetSample.p
    Purpose     : 

    Syntax      :

    Description : Sample how to access an already existing dataset on
                  the client.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Mar 09 09:55:18 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING combit.ListLabel24.ListLabel FROM ASSEMBLY.
USING TasteITConsulting.ListLabel24.OpenEdgeDataProvider FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService   FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.

DEFINE TEMP-TABLE ttCustomer NO-UNDO 
    FIELD CustNum  AS INTEGER 
    FIELD CustName AS CHARACTER
    INDEX pix IS PRIMARY UNIQUE CustNum.
    
DEFINE TEMP-TABLE ttOrder NO-UNDO 
    FIELD OrderNum AS INTEGER 
    FIELD CustNum  AS INTEGER 
    FIELD OrderTotal AS DECIMAL 
    INDEX pix IS PRIMARY UNIQUE OrderNum
    INDEX ixCustomer CustNum OrderNum.

DEFINE DATASET dsData FOR ttCustomer, ttOrder
   DATA-RELATION CustOrder FOR ttCustomer, ttOrder
      RELATION-FIELDS (CustNum,CustNum).

DO TRANSACTION:
    CREATE ttCustomer.
    ASSIGN ttCustomer.CustNum  = 1
           ttCustomer.CustName = "combit".
           
    CREATE ttOrder.
    ASSIGN ttOrder.OrderNum      = 1
           ttOrder.CustNum       = 1
           ttOrder.OrderTotal = 1000.

    CREATE ttOrder.
    ASSIGN ttOrder.OrderNum      = 2
           ttOrder.CustNum       = 1
           ttOrder.OrderTotal = 2000.

    CREATE ttOrder.
    ASSIGN ttOrder.OrderNum      = 3
           ttOrder.CustNum       = 1
           ttOrder.OrderTotal = 3000.
END.        

DEFINE VARIABLE iRow AS INTEGER NO-UNDO.

DEFINE VARIABLE oLL             AS ListLabel              NO-UNDO.
DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider   NO-UNDO.
DEFINE VARIABLE oDatasetService AS OpenEdgeDatasetService NO-UNDO.

oProvider = NEW OpenEdgeDataProvider().
oLL       = NEW ListLabel().

/* Generic in-memory Dataset Service. */
oDatasetService = NEW OpenEdgeDatasetService(DATASET dsData:HANDLE ).
oDatasetService:TablePrefixToRemove = "tt".

/* Get the schema */
oProvider:ServiceName    = oDatasetService:ServiceName.
/* .Net Client Service Adapter accessing the dataset */
oProvider:ServiceAdapter = NEW OpenEdgeDatasetServiceAdapter(oDatasetService).
oProvider:Initialize().

oLL:DataSource           = oProvider.
oLL:ForceSingleThread    = TRUE.

oLL:Design().
oLL:Dispose().

RETURN.



