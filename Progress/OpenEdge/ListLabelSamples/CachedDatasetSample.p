/**********************************************************************
 * Copyright (C) 2018 by Taste IT Consulting ("TIC") -                *
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
    File        : CachedDatasetSample.p
    Purpose     : 

    Syntax      :

    Description : Sample for running a cached dataset service in the
                  client memory. Normally a service like this would
                  be called though a normal service adapter running
                  on the appserver.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Thu Nov 08 10:08:14 CET 2018
    Notes       :
  ----------------------------------------------------------------------*/
BLOCK-LEVEL ON ERROR UNDO, THROW.

USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING TasteITConsulting.Reporting.OpenEdgeDataProvider      FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.
USING ListLabelSamples.CachedDatasetService FROM PROPATH.

DEFINE VARIABLE oLL             AS ListLabel            NO-UNDO.
DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider NO-UNDO.
DEFINE VARIABLE oDatasetService AS CachedDatasetService NO-UNDO.

oProvider = NEW OpenEdgeDataProvider().
oLL = NEW ListLabel().

oDatasetService          = NEW CachedDatasetService().
oProvider:ServiceName    = oDatasetService:ServiceName.
oProvider:ServiceAdapter = NEW OpenEdgeDatasetServiceAdapter(oDatasetService).
oProvider:Initialize().

oLL:DataSource           = oProvider.
oLL:ForceSingleThread    = TRUE.

oLL:Design().

FINALLY: 
    oLL:Dispose().
    oProvider:Dispose().
END.




