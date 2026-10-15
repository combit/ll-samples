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
    File        : OpenEdgeCalculatedTableArgs
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Thu Oct 04 08:35:33 CEST 2018
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeCalculatedTableArgs: 
    DEFINE PUBLIC PROPERTY OETableName         AS CHARACTER NO-UNDO 
    GET.
    SET. 

    DEFINE PUBLIC PROPERTY OETableWhere        AS CHARACTER NO-UNDO 
    GET.
    SET. 

    DEFINE PUBLIC PROPERTY OEParentTableName   AS CHARACTER NO-UNDO 
    GET.
    SET. 
    
    DEFINE PUBLIC PROPERTY OEParentTableWhere  AS CHARACTER NO-UNDO 
    GET.
    SET. 
    
    DEFINE PUBLIC PROPERTY OETableBufferHandle AS HANDLE NO-UNDO 
    GET.
    SET. 

END CLASS.