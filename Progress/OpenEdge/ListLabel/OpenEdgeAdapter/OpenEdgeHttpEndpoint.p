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
    File        : OpenEdgeHttpEndpoint.p
    Purpose     : REST Endpoint for HTTP calls to a service.
                  The post body (json) holds all parameters for 
                  OpenEdgeGateway.p that gets called by this procedure.

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Sun Jan 17 10:59:29 CET 2021
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING ListLabel.OpenEdgeAdapter.OpenEdgePostContent FROM PROPATH.

DEFINE INPUT  PARAMETER plcPostContent          AS LONGCHAR  NO-UNDO.
DEFINE OUTPUT PARAMETER plcResponse             AS LONGCHAR  NO-UNDO.

DEFINE VARIABLE cServiceName               AS CHARACTER NO-UNDO.
DEFINE VARIABLE cMethodName                AS CHARACTER NO-UNDO.
DEFINE VARIABLE lcOpenEdgeServiceParameter AS LONGCHAR  NO-UNDO.
DEFINE VARIABLE lcOpenEdgeDataRequest      AS LONGCHAR  NO-UNDO.

DEFINE VARIABLE oOpenEdgePostContent AS OpenEdgePostContent NO-UNDO.

oOpenEdgePostContent = NEW OpenEdgePostContent(plcPostContent).

cServiceName = oOpenEdgePostContent:getContent("ServiceName").
cMethodName  = oOpenEdgePostContent:getContent("MethodName").
lcOpenEdgeServiceParameter = oOpenEdgePostContent:getContent("OpenEdgeServiceParameter").
lcOpenEdgeDataRequest      = oOpenEdgePostContent:getContent("OpenEdgeDataRequest").

RUN ListLabel/OpenEdgeAdapter/OpenEdgeGateway.p (
    INPUT cServiceName, 
    INPUT cMethodName,
    INPUT lcOpenEdgeServiceParameter,
    INPUT lcOpenEdgeDataRequest,
    OUTPUT plcResponse
    ).

RETURN.

