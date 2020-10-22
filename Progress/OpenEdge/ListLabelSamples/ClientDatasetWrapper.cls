/**********************************************************************
 * Copyright (C) 2017 by Taste IT Consulting ("TIC") -                *
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
    File        : ClientDatasetWrapper
    Purpose     : This sample wrapper receives any dataset from an 
                  ABL client object and prints it or calls the designer. 
    Syntax      : 
    Description : Use this as a sample to print data from any dataset
                  from an ABL client.
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Dec 06 16:32:28 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING TasteITConsulting.Reporting.OpenEdgeDataProvider FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService   FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.
USING combit.Reporting.ListLabel FROM ASSEMBLY.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.ClientDatasetWrapper:
    
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID PrintDataset( phDataset AS HANDLE, plDesign AS LOGICAL):
    
        DEFINE VARIABLE oLL             AS ListLabel              NO-UNDO.
        DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider   NO-UNDO.
        DEFINE VARIABLE oDatasetService AS OpenEdgeDatasetService NO-UNDO.
        
        oProvider = NEW OpenEdgeDataProvider().
        oLL       = NEW ListLabel().
        
        /* Generic in-memory Dataset Service. */
        oDatasetService = NEW OpenEdgeDatasetService( phDataset ).
        /*oDatasetService:TablePrefixToRemove = "tt".*/
        
        /* Get the schema */
        oProvider:ServiceName    = oDatasetService:ServiceName.
        /* .Net Client Service Adapter accessing the dataset */
        oProvider:ServiceAdapter = NEW OpenEdgeDatasetServiceAdapter(oDatasetService).
        oProvider:Initialize().
        
        oLL:DataSource           = oProvider.
        oLL:ForceSingleThread    = TRUE.
        
        IF plDesign THEN 
            oLL:Design().
        ELSE 
            oLL:Print().
        
        oLL:Dispose().
		
		RETURN.

	END METHOD.

END CLASS.