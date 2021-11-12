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

USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING TasteITConsulting.Reporting.OpenEdgeDataProvider FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService   FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.

DEFINE TEMP-TABLE ttCustomer NO-UNDO 
    FIELD Cust-Num  AS INTEGER 
    FIELD Cust-Name AS CHARACTER
    INDEX pix IS PRIMARY UNIQUE Cust-Num.
    
DEFINE TEMP-TABLE ttOrder NO-UNDO 
    FIELD Order-Num AS INTEGER 
    FIELD Cust-Num  AS INTEGER 
    FIELD Order-Total AS DECIMAL 
    INDEX pix IS PRIMARY UNIQUE Order-Num
    INDEX ixCustomer Cust-Num Order-Num.

DEFINE DATASET dsData FOR ttCustomer, ttOrder
   DATA-RELATION CustOrder FOR ttCustomer, ttOrder
      RELATION-FIELDS (Cust-Num,Cust-Num).

DO TRANSACTION:
    CREATE ttCustomer.
    ASSIGN ttCustomer.Cust-Num  = 1
           ttCustomer.Cust-Name = "combit".
           
    CREATE ttOrder.
    ASSIGN ttOrder.Order-Num      = 1
           ttOrder.Cust-Num       = 1
           ttOrder.Order-Total = 1000.

    CREATE ttOrder.
    ASSIGN ttOrder.Order-Num      = 2
           ttOrder.Cust-Num       = 1
           ttOrder.Order-Total = 2000.

    CREATE ttOrder.
    ASSIGN ttOrder.Order-Num      = 3
           ttOrder.Cust-Num       = 1
           ttOrder.Order-Total = 3000.

    CREATE ttCustomer.
    ASSIGN ttCustomer.Cust-Num  = 2
           ttCustomer.Cust-Name = "Taste IT Consulting".
           
    CREATE ttOrder.
    ASSIGN ttOrder.Order-Num   = 4
           ttOrder.Cust-Num    = 2
           ttOrder.Order-Total = 4000.
           
    CREATE ttOrder.
    ASSIGN ttOrder.Order-Num   = 5
           ttOrder.Cust-Num    = 2
           ttOrder.Order-Total = 5000.
           
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



