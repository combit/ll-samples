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
    File        : Samples/PrintOrder.p
    Purpose     : Print an Order.
                  Order     -> Variables
                  OrderLine -> Fields
    Syntax      : 

    Description : Sample how to filter data from the application context.
                  Use the table "BaseQueryWhere" to add a filter
                  This filter is not visible in the designer but always used.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Jan 26 06:13:21 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING TasteITConsulting.Reporting.OpenEdgeDataProvider FROM ASSEMBLY.
USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING ListLabelDemo.Sports2000ServiceAdapter FROM PROPATH.
USING combit.Reporting.LlAutoMasterMode FROM ASSEMBLY.

DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider     NO-UNDO.
DEFINE VARIABLE oLL             AS ListLabel                NO-UNDO.
DEFINE VARIABLE oServiceAdapter AS Sports2000ServiceAdapter NO-UNDO.

oProvider = NEW OpenEdgeDataProvider().
oServiceAdapter = NEW Sports2000ServiceAdapter().
oLL = NEW ListLabel().

/* Get the schema */
oProvider:ServiceAdapter = oServiceAdapter.
oProvider:ServiceName    = "ListLabelDemo.Sports2000Service".
oProvider:Initialize().

/* After we have the schema, we define the base query for table order.
   A base query is not shown in the designer and can not be removed.
   Can also be used as a "tenant/company/whatever" filter.
*/
oProvider:setBaseQueryWhere("Order","OrderNum <= 100").

/* 20170816 - the provider has a new method to define an initial sort by.
   Currently (LL22) there is no way to add a sort order in the designer for the 
   master table with AutomasterMode "AsVariables".
   This sort by clause is also not shown in the designer, but will be replaced
   whenever a new one is set in the designer.
*/
oProvider:SetInitialSortBy("Order","BY Custnum BY OrderNum").
/* Register order table as variables */
oLL:DataSource     = oProvider.
oLL:DataMember     = "Order".
oLL:AutoMasterMode = LlAutoMasterMode:AsVariables.
oLL:ForceSingleThread = TRUE.

oLL:AutoProjectFile = "ListLabelSamples/Order.lst".
oLL:AutoShowSelectFile = FALSE.

oLL:Design().
oLL:Dispose().

