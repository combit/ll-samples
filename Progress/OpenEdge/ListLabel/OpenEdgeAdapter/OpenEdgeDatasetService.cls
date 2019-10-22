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
    File        : OpenEdgeDatasetService
    Purpose     : 
    Syntax      : 
    Description : Dataset in memory service.
    
                  Is used as a container for Datasets coming from 
                  somewhere else like Business Entities or Dataset Models
                  or whatever you name it.
                  
                  This service doesn't access the database. Your dataset
                  needs to contain all of your data.
                  
                  The OpenEdgeService (super) does the rest :-)
                  
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Mar 09 09:17:06 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeService     FROM PROPATH.
USING TasteITConsulting.ListLabel25.IServiceAdapter FROM ASSEMBLY.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService INHERITS OpenEdgeService:
    
    DEFINE PUBLIC PROPERTY TablePrefixToRemove AS CHARACTER NO-UNDO 
    GET.
    SET. 
    
    /* Constructor - pass your in memory dataset handle */
    CONSTRUCTOR PUBLIC OpenEdgeDatasetService ( phDataset AS HANDLE ):
		SUPER ().
		SourceDatasetHandle = phDataset.
	END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
      Purpose: Register the dataset schema.
      Notes:
      ------------------------------------------------------------------------------*/
    METHOD OVERRIDE PUBLIC VOID registerSchema(  ):
        IF TablePrefixToRemove > "" THEN 
            ServiceSchema:registerDataset(SourceDatasetHandle,TablePrefixToRemove).
	    ELSE 
    	    ServiceSchema:registerDataset(SourceDatasetHandle).
    	RETURN.    
    END METHOD.

END CLASS.