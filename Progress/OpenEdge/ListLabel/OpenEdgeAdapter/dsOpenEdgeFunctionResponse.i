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
    File        : dsOpenEdgeFunctionResponse.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sat May 28 18:07:54 CEST 2016
    Notes       :
  ----------------------------------------------------------------------*/

/* Native Function Call Response */
DEFINE TEMP-TABLE OEFunctionResponse NO-UNDO 
    FIELD OEFunctionCallGuid     AS CHARACTER
    FIELD OEFunctionResult       AS DECIMAL 
    INDEX pk IS PRIMARY UNIQUE OEFunctionCallGuid. 
    
DEFINE DATASET dsOpenEdgeFunctionResponse SERIALIZE-NAME "OpenEdgeDataResponse"
       FOR OEFunctionResponse.

