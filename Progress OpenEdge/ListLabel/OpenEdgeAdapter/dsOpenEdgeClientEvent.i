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
    File        : dsOpenEdgeClientEvent.i
    Purpose     : 

    Syntax      :

    Description : Dataset to hold information about a ClientEvent passed
                  from the data provider.
                  We use a dataset here and pass the information as Json
                  just in case we have to add additional information 
                  later.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Oct 02 08:48:44 CEST 2018
    Notes       :
  ----------------------------------------------------------------------*/
DEFINE TEMP-TABLE OEClientEvent NO-UNDO
    FIELD EventId   AS CHARACTER 
    FIELD ClientId  AS CHARACTER 
    FIELD EventName AS CHARACTER
    INDEX pk IS PRIMARY UNIQUE EventId 
    .

DEFINE TEMP-TABLE OEClientEventArg NO-UNDO
    FIELD EventId  AS CHARACTER 
    FIELD ArgName  AS CHARACTER 
    FIELD ArgValue AS CHARACTER 
    INDEX pk IS PRIMARY UNIQUE EventId ArgName
    .

DEFINE DATASET dsOpenEdgeClientEvent SERIALIZE-NAME "OpenEdgeClientEvent" FOR OEClientEvent, OEClientEventArg 
    DATA-RELATION Args FOR OEClientEvent, OEClientEventArg
        RELATION-FIELDS(EventId,EventId).
