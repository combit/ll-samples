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
    File        : OpenEdgeDatasetServiceAdapter
    Purpose     : In Memory Service Adapter for a (Dataset) Service 
                  running on a Windows Client. 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Jul 27 20:40:10 CEST 2016
    Notes       : .Net required 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING TasteITConsulting.ListLabel24.IServiceAdapter    FROM ASSEMBLY.
USING TasteITConsulting.ListLabel24.OELongchar         FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter IMPLEMENTS IServiceAdapter: 

    DEFINE PRIVATE VARIABLE moService AS OpenEdgeDatasetService NO-UNDO.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeDatasetServiceAdapter ( poService AS OpenEdgeDatasetService ):
		SUPER ().
		moService = poService.
	END CONSTRUCTOR.

    /* Service Adapter - getSchema() */
    METHOD PUBLIC LOGICAL GetSchema( INPUT  ServiceName          AS CHARACTER, 
                                     INPUT  JsonServiceParameter AS OELongchar, 
                                     OUTPUT JsonSchema           AS OELongchar ):
        
        DEFINE VARIABLE lcParameter   AS LONGCHAR   NO-UNDO.
        DEFINE VARIABLE lcSchema      AS LONGCHAR   NO-UNDO.
        lcParameter     = JsonServiceParameter:Data.                           
        lcSchema        = moService:getSchema(lcParameter).
        JsonSchema      = NEW OELongchar().
        JsonSchema:Data = lcSchema.

        RETURN TRUE.

    END METHOD. 

    /* Service Adapter - getData() */
    METHOD PUBLIC LOGICAL GetData  ( INPUT  ServiceName           AS CHARACTER, 
                                     INPUT  JsonServiceParameter  AS OELongchar, 
                                     INPUT  JsonDataRequest       AS OELongchar, 
                                     OUTPUT JsonDataResponse      AS OELongchar ):

        DEFINE VARIABLE lcParameter   AS LONGCHAR   NO-UNDO.
        DEFINE VARIABLE lcRequest     AS LONGCHAR   NO-UNDO.
        DEFINE VARIABLE lcResponse    AS LONGCHAR   NO-UNDO.
        
        lcParameter = JsonServiceParameter:Data.
        lcRequest   = JsonDataRequest:Data.
        
        lcResponse = moService:GetData( lcParameter, lcRequest ).
        JsonDataResponse = NEW OELongchar().
        JsonDataResponse:Data = lcResponse.

        RETURN TRUE.

    END METHOD.

    /* Service Adapter - Client Event */
    METHOD PUBLIC LOGICAL ClientEvent( INPUT  ServiceName      AS CHARACTER, 
                                       INPUT  JsonParameter    AS OELongchar,
                                       INPUT  JsonDataRequest  AS OELongchar,
                                       OUTPUT JsonDataResponse AS OELongchar ):
        JsonDataResponse = NEW OELongchar().
        RETURN TRUE.
    END METHOD.

    METHOD PUBLIC LOGICAL ClientEvent( INPUT ServiceName AS CHARACTER, 
                                       INPUT JsonServiceParameter   AS OELongchar, 
                                       INPUT EventName AS CHARACTER ):
                                           
        RETURN TRUE.
    END METHOD.

END CLASS.