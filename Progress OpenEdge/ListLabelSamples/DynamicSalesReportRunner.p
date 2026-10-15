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
    File        : DynamicSalesReportRunner.p
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sun May 22 08:17:55 CEST 2016
    Notes       :
  ----------------------------------------------------------------------*/

USING TasteITConsulting.Reporting.OpenEdgeDataProvider FROM ASSEMBLY.
USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING ListLabelDemo.Sports2000ServiceAdapter FROM PROPATH.
USING ListLabelSamples.DynamicSalesReport FROM PROPATH.

DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider     NO-UNDO.
DEFINE VARIABLE oLL             AS ListLabel                NO-UNDO.

DEFINE VARIABLE oReport         AS DynamicSalesReport       NO-UNDO.
DEFINE VARIABLE oServiceAdapter AS Sports2000ServiceAdapter NO-UNDO.

oProvider = NEW OpenEdgeDataProvider().
oServiceAdapter = NEW Sports2000ServiceAdapter().
oLL = NEW ListLabel().

/* Get the schema */
oReport = NEW DynamicSalesReport(?).
oProvider:ServiceAdapter = oServiceAdapter.
oProvider:ServiceName    = oReport:ServiceName.
oProvider:Initialize().

oLL:DataSource     = oProvider.
oLL:ForceSingleThread = TRUE.
oLL:Design().
oLL:Dispose().

