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
    File        : ExportOrder_Appserver.p
    Purpose     : Export an Order as PDF and send it to the client.
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
USING combit.Reporting.ExportConfiguration FROM ASSEMBLY.
USING combit.Reporting.LlExportTarget FROM ASSEMBLY.

DEFINE TEMP-TABLE ttFile NO-UNDO 
    FIELD FileGuid    AS CHARACTER 
    FIELD FileContent AS BLOB
    INDEX pix IS PRIMARY UNIQUE FileGuid.

/* Parameter */
DEFINE INPUT  PARAMETER pcBaseQuery AS CHARACTER NO-UNDO.
DEFINE OUTPUT PARAMETER plcPDF      AS LONGCHAR  NO-UNDO. 

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
   Can also be used as a "tenant/company/whatever" filter.*/
oProvider:setBaseQueryWhere("Order",pcBaseQuery).

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

DEFINE VARIABLE oExportConfiguration AS ExportConfiguration NO-UNDO.
DEFINE VARIABLE cExportFile          AS CHARACTER NO-UNDO.
DEFINE VARIABLE cProjectFile         AS CHARACTER NO-UNDO.
DEFINE VARIABLE cGuid                AS CHARACTER NO-UNDO.

cGuid = GUID.

FILE-INFO:FILE-NAME = "ListLabelSamples/Order.lst".
cProjectFile = FILE-INFO:FULL-PATHNAME.

cExportFile = SUBSTITUTE("&1&2_&3.pdf", SESSION:TEMP-DIRECTORY,"Order",cGuid).
oExportConfiguration = NEW ExportConfiguration (LlExportTarget:Pdf,cExportFile,cProjectFile).
oLL:Export(oExportConfiguration).

FILE-INFO:FILE-NAME = cExportFile.
IF FILE-INFO:FULL-PATHNAME <> ? THEN
DO: 
    /* Sending the PDF directly as a longchar should be possible, but there are (always) codepage
       problems. So, we put it in a temp-table and convert it to JSON. 
       The WRITE-JSON method takes care of proper encoding. 
    */   
    CREATE ttFile.
    ASSIGN ttFile.FileGuid = cGuid.
    COPY-LOB FROM FILE FILE-INFO:FULL-PATHNAME TO ttFile.FileContent.
    TEMP-TABLE ttFile:WRITE-JSON( "LONGCHAR", plcPDF ).
    OS-DELETE VALUE (FILE-INFO:FULL-PATHNAME).
END.
oLL:Dispose().
oProvider:Dispose().

RETURN.

