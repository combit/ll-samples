@openapi.openedge.export FILE(type="REST", executionMode="external", useReturnValue="false", writeDataSetBeforeImage="false").
/**********************************************************************
 * Copyright (C) 2021 by Taste IT Consulting ("TIC") -                *
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
    File        : OpenEdgeHttpHello.p
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sun Jan 17 20:38:50 CET 2021
    Notes       :
  ----------------------------------------------------------------------*/
BLOCK-LEVEL ON ERROR UNDO, THROW.

DEFINE OUTPUT PARAMETER pcMessage AS CHARACTER NO-UNDO.

pcMessage = "Congratulation! You have reached List/OpenEdgeAdapter/OpenEdgeHttpHello.p".

RETURN.

