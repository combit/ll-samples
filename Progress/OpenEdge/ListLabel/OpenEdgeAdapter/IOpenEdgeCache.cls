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
    File        : IOpenEdgeCache
    Purpose     : 
    Syntax      : 
    Description : Interface for a cache to store service data as json
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sat Sep 29 09:18:38 CEST 2018
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

INTERFACE ListLabel.OpenEdgeAdapter.IOpenEdgeCache:

    DEFINE PUBLIC PROPERTY ServiceName AS CHARACTER NO-UNDO 
    GET.

    DEFINE PUBLIC PROPERTY ClientId    AS CHARACTER NO-UNDO 
    GET.

    METHOD PUBLIC LONGCHAR ReadCache   ( ).    
    METHOD PUBLIC LOGICAL  WriteCache  ( plcJsonData AS LONGCHAR ).   
    METHOD PUBLIC LOGICAL  DeleteCache ( ).   
    METHOD PUBLIC LOGICAL  CacheExists ( ).   

END INTERFACE.