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
    File        : IOpenEdgeService
    Purpose     : Interface to be implemented by an OpenEdge Service 
                  for the Data Provider.
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sun Jan 03 16:51:54 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/
USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

INTERFACE ListLabel.OpenEdgeAdapter.IOpenEdgeService:
    
    METHOD PUBLIC LONGCHAR getSchema   ( plcServiceParameterJson AS LONGCHAR ).
    METHOD PUBLIC LONGCHAR getData     ( plcServiceParameterJson AS LONGCHAR, plcRequestJson        AS LONGCHAR ).
    METHOD PUBLIC LONGCHAR ClientEvent ( plcServiceParameterJson AS LONGCHAR, plcRequestJson        AS LONGCHAR ).

END INTERFACE.