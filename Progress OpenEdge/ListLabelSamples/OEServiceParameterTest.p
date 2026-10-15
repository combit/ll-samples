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
    File        : OEServiceParameterTest.p
    Purpose     : Report to test if the Report Parameters from a layout
                  reach the service.
                  
                  Report Parameter can be used directly in a layout in
                  a filter for a table and are also passed via 
                  ServiceParameter to the ABL service. So the service
                  is able to filter or collect data based on these 
                  parameters.
                  
                  These Service Parameter have a special name
                  "LLReportParameter.<ParameterNameInLayout>".
                    
                  Use ListLabel/OEServiceParameterInfo.lst as a sample
                  layout.  

    Syntax      :

    Description : 

    Author(s)   : 
    Created     : 2021
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

BLOCK-LEVEL ON ERROR UNDO, THROW.

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
oProvider:ServiceAdapter = oServiceAdapter.
oProvider:ServiceName = "ListLabelSamples.OEServiceParameterInfoService".

oLL = NEW ListLabel().
oProvider:Initialize().

oLL:DataSource     = oProvider.
oLL:ForceSingleThread = TRUE.
oLL:Design().
oLL:Dispose().

