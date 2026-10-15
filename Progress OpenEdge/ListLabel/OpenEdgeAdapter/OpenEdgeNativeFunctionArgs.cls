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
    File        : OpenEdgeNativeFunctionArgs
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Fri May 27 19:56:36 CEST 2016
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeNativeFunctionArgs:

    DEFINE PUBLIC PROPERTY OEFunctionName AS CHARACTER NO-UNDO 
    GET.
    SET. 
    
    DEFINE PUBLIC PROPERTY OETableName AS CHARACTER NO-UNDO 
	GET.
	SET. 
	
    DEFINE PUBLIC PROPERTY OETableWhere AS CHARACTER NO-UNDO 
    GET.
    SET. 
	
    DEFINE PUBLIC PROPERTY OEExpression AS CHARACTER NO-UNDO 
    GET.
    SET. 
    
    DEFINE PUBLIC PROPERTY OEDistinct   AS CHARACTER NO-UNDO 
    GET.
    SET. 
	 
    DEFINE PUBLIC PROPERTY OEResult     AS DECIMAL NO-UNDO 
    GET.
    SET. 

END CLASS.