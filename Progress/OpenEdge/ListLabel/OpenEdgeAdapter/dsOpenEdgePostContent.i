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
    File        : dsOpenEdgePostContent.i
    Purpose     : Dataset for the HTTP Post Content, Name/Value Pairs 

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Fri Jan 15 16:59:51 CET 2021
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

DEFINE TEMP-TABLE OEPostContent NO-UNDO 
    FIELD OEContentName AS CHARACTER 
    FIELD OEContentData AS CLOB  
    INDEX pk IS PRIMARY UNIQUE OEContentName.
    
DEFINE DATASET dsOpenEdgePostContent SERIALIZE-NAME "OpenEdgePostContent"
       FOR OEPostContent.
    

    
    
    