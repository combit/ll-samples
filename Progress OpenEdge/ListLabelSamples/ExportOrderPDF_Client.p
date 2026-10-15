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
    File        : ExportOrderPDF_Client.p
    Purpose     : Create a PDF on the Appserver.
                  The PDF is send back as a json wrapped temp-table.
    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Thu Nov 22 12:59:23 CET 2018
    Notes       :
  ----------------------------------------------------------------------*/
BLOCK-LEVEL ON ERROR UNDO, THROW.

USING ListLabelDemo.Sports2000ServiceAdapter FROM PROPATH.

DEFINE VARIABLE cBaseQueryWhere AS CHARACTER NO-UNDO.
DEFINE VARIABLE lcPDF           AS LONGCHAR  NO-UNDO.

DEFINE VARIABLE hAppserver      AS HANDLE NO-UNDO.
DEFINE VARIABLE oServiceAdapter AS Sports2000ServiceAdapter NO-UNDO.

/* We use the Demo Service Adapter to create an appserver connection. */
DEFINE VARIABLE lUseAppserver AS LOGICAL   NO-UNDO INIT TRUE .
DEFINE VARIABLE cPDFFile      AS CHARACTER NO-UNDO.
oServiceAdapter = NEW Sports2000ServiceAdapter( TRUE ).

/* The filter for orders */
cBaseQueryWhere = "OrderNum = '1'".

hAppserver = oServiceAdapter:AppserverHandle.

DEFINE TEMP-TABLE ttFile NO-UNDO 
    FIELD FileGuid    AS CHARACTER 
    FIELD FileContent AS BLOB
    INDEX pix IS PRIMARY UNIQUE FileGuid.

RUN ListLabelSamples/ExportOrderPDF_AppServer.p ON SERVER hAppserver (INPUT cBaseQueryWhere, OUTPUT lcPDF).
IF LENGTH(lcPDF) > 0 THEN 
DO:
    TEMP-TABLE ttFile:READ-JSON ("LONGCHAR",lcPDF).
    FIND FIRST ttFile NO-ERROR.
    IF AVAILABLE ttFile THEN 
    DO:
        cPDFFile = SUBSTITUTE ("&1&2", SESSION:TEMP-DIRECTORY,"Order_from_appserver.pdf").
        COPY-LOB FROM ttFile.FileContent TO FILE cPDFFile.
        MESSAGE "PDF written to" cPDFFile
            VIEW-AS ALERT-BOX.
        OS-COMMAND SILENT VALUE (cPDFFile).    
    END.
    ELSE DO:
        MESSAGE "Data returned from Appserver, but no PDF received!"
        VIEW-AS ALERT-BOX ERROR.
    END.    
END.
ELSE DO:
    MESSAGE "Server didn't return data!"
    VIEW-AS ALERT-BOX ERROR.
END.        





