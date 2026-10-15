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
    File        : OpenEdgeClientEvent
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Oct 02 09:01:47 CEST 2018
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeClientEvent: 
    
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeClientEvent.i}
    
    DEFINE PUBLIC PROPERTY ClientId  AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 
    
    DEFINE PUBLIC PROPERTY EventName AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 

    DEFINE PUBLIC PROPERTY EventID   AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC OpenEdgeClientEvent (  ):
        SUPER ().
    END CONSTRUCTOR.

    CONSTRUCTOR PUBLIC OpenEdgeClientEvent ( plcClientEventJson AS LONGCHAR ):
        SUPER ().
        
        IF LENGTH(plcClientEventJson) > 0 THEN 
        DO:
            DATASET dsOpenEdgeClientEvent:READ-JSON ("LONGCHAR",plcClientEventJson,"EMPTY") NO-ERROR.
            
            /* Only one record used */
            FIND FIRST OEClientEvent NO-ERROR.
            IF AVAILABLE OEClientEvent THEN 
                ASSIGN ClientId  = OEClientEvent.ClientId
                       EventName = OEClientEvent.EventName
                       EventId   = OEClientEvent.EventId.
        END.                   
        RETURN.
    END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC CHARACTER ArgValue( pcArgName AS CHARACTER):
        FIND OEClientEventArg WHERE OEClientEventArg.EventId = EventId
                              AND   OEClientEventArg.ArgName = pcArgName NO-ERROR.
        IF AVAILABLE OEClientEventArg THEN 
            RETURN OEClientEventArg.ArgValue.
        
        RETURN "".
    END METHOD.    

END CLASS.