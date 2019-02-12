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
    File        : OpenEdgeGateway.p
    Purpose     : Main (and only :-) ) appserver entry point for 
                  the data provider to talk to the OpenEdge services.
                  This procedure is also used by ProxyGen to generate
                  the OpenClient .Net proxy.

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Jan 13 07:12:41 CET 2016
    Notes       : Since LL24 new method ClientEvent.
                  
  ----------------------------------------------------------------------*/
  
/* ***************************  Definitions  ************************** */

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter FROM PROPATH.

DEFINE INPUT  PARAMETER pcServiceName           AS CHARACTER NO-UNDO.
DEFINE INPUT  PARAMETER pcMethodName            AS CHARACTER NO-UNDO.
DEFINE INPUT  PARAMETER plcServiceParameterJson AS CHARACTER NO-UNDO.
DEFINE INPUT  PARAMETER plcRequest              AS LONGCHAR  NO-UNDO.
DEFINE OUTPUT PARAMETER plcResponse             AS LONGCHAR  NO-UNDO.

/* ********************  Preprocessor Definitions  ******************** */

/* ***************************  Main Block  *************************** */

DEFINE VARIABLE oService AS ListLabel.OpenEdgeAdapter.IOpenEdgeService NO-UNDO.
DEFINE VARIABLE oServiceParameter AS OpenEdgeServiceParameter          NO-UNDO.

DEFINE VARIABLE lUseInvariantCulture AS LOGICAL   NO-UNDO.
DEFINE VARIABLE cNumericFormat       AS CHARACTER NO-UNDO.
DEFINE VARIABLE cDateFormat          AS CHARACTER NO-UNDO.
DEFINE VARIABLE cEventName           AS CHARACTER NO-UNDO.

IF pcMethodName = "Ping" THEN 
DO:
    /* We could even return something more meaningful here, like some kind of info in Json 
       - is the service available.
       - which databases are connected.
       - the session settings.
       - supported services.
       - os name
       - whatever...   
    */
    plcResponse = "Pong".   
    RETURN.
END.

IF LENGTH(plcServiceParameterJson) > 0 THEN 
DO:
    oServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
    lUseInvariantCulture = oServiceParameter:UseInvariantCulture NO-ERROR.
    IF lUseInvariantCulture THEN 
    DO:
        cNumericFormat = SESSION:NUMERIC-FORMAT.
        cDateFormat    = SESSION:DATE-FORMAT.
        /* Switch to Invariant Culture = US culture */
        SESSION:NUMERIC-FORMAT = "AMERICAN".
        SESSION:DATE-FORMAT    = "mdy".
    END.  
END.

/* TODO: proper error handling */
oService = DYNAMIC-NEW pcServiceName ().

IF pcMethodName = "GetData" THEN 
DO:
    plcResponse = oService:getData(plcServiceParameterJson,plcRequest).
END.    
ELSE IF pcMethodName = "GetSchema" THEN 
DO:
    plcResponse = oService:getSchema(plcServiceParameterJson). 
END. 
ELSE IF pcMethodName = "ClientEvent" THEN 
DO:
    cEventName = plcRequest.
    oService:ClientEvent(plcServiceParameterJson,cEventName).
END.    

RETURN.

FINALLY:
    IF lUseInvariantCulture THEN 
    DO:
        /* Don't forget to switch back. Others won't like it :-) */
        SESSION:NUMERIC-FORMAT = cNumericFormat.
        SESSION:DATE-FORMAT    = cDateFormat.
    END. 
    DELETE OBJECT (oService) NO-ERROR. 
END FINALLY.


