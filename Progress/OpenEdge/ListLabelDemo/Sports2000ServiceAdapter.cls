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
    File        : ServiceAdapter
    Purpose     : Sample for an OpenEdge ServiceAdapter
    Syntax      : 
    Description : 
    Author(s)   : 
    Created     : Sun Dec 27 07:09:00 CET 2015
    Notes       : 20181001 New Version for LL24 implements ClientEvent
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING TasteITConsulting.Reporting.IServiceAdapter FROM ASSEMBLY.
USING TasteITConsulting.Reporting.OELongchar FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.IOpenEdgeService FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelDemo.Sports2000ServiceAdapter IMPLEMENTS IServiceAdapter: 

    DEFINE VARIABLE moService AS IOpenEdgeService NO-UNDO.
    DEFINE VARIABLE mcLogfile AS CHARACTER NO-UNDO.
    
    DEFINE STREAM s.
    
    DEFINE VARIABLE mhAppserver       AS HANDLE NO-UNDO.
    DEFINE VARIABLE mhAppserverHandle AS HANDLE NO-UNDO.
    
    DEFINE VARIABLE mcAppserverConnection AS CHARACTER 
           INIT "-AppService listlabel -H localhost -S 5162".
    
    DEFINE PUBLIC PROPERTY AppserverHandle AS HANDLE NO-UNDO 
    GET:
        RETURN mhAppserver.
    END GET.    

    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC Sports2000ServiceAdapter (  ):
		SUPER ().
		mhAppserver = SESSION.
		mcLogfile = SESSION:TEMP-DIRECTORY + "Sports2000ServiceAdapter.log".
		writeLog("CLEAR").
		writeLog("LL27").
	END CONSTRUCTOR.

    CONSTRUCTOR PUBLIC Sports2000ServiceAdapter ( plUseAppserver AS LOGICAL ):
        SUPER ().
        mcLogfile = SESSION:TEMP-DIRECTORY + "Sports2000ServiceAdapter.log".
        writeLog("CLEAR").
        writeLog("LL27").
        IF plUseAppserver = FALSE THEN
            mhAppserver = SESSION.
        ELSE DO:
            IF NOT VALID-HANDLE (mhAppserverHandle) THEN 
            DO:
                CREATE SERVER mhAppserverHandle.
                mhAppserverHandle:CONNECT (mcAppserverConnection).
            END. 
            mhAppserver = mhAppserverHandle.
            WriteLog(SUBSTITUTE("Appserver: &1 &2",mcAppserverConnection)).
        END.
            
    END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:   Passing a Json string from C# and mapping it to 
              INPUT PARAMETER x AS LONGCHAR doesn't compile. 
              So, we pass the Json string in a container class.
    ------------------------------------------------------------------------------*/
	METHOD PUBLIC LOGICAL GetData( INPUT  ServiceName       AS CHARACTER, 
	                               INPUT  JsonParameter     AS OELongchar,
	                               INPUT  JsonDataRequest   AS OELongchar,
	                               OUTPUT JsonDataResponse  AS OELongchar ):
		
		DEFINE VARIABLE lcRequest   AS LONGCHAR NO-UNDO.
        DEFINE VARIABLE lcParameter AS LONGCHAR NO-UNDO.
		DEFINE VARIABLE lcResponse  AS LONGCHAR NO-UNDO.
        
        lcParameter = JsonParameter:Data.
        writeLog ( SUBSTITUTE ("ServiceName: &1 GetData()", ServiceName)).
        writeLog (STRING(lcParameter)).
		lcRequest = JsonDataRequest:Data.
        writeLog (STRING(lcRequest)).
        JsonDataResponse = NEW OELongchar().
        RUN ListLabel/OpenEdgeAdapter/OpenEdgeGateway.p ON SERVER mhAppserver 
              (INPUT ServiceName, INPUT "GetData", INPUT lcParameter, INPUT lcRequest, OUTPUT lcResponse ).
        JsonDataResponse:Data = lcResponse.
        RETURN TRUE.
	END METHOD.

	METHOD PUBLIC LOGICAL  GetSchema( INPUT  ServiceName   AS CHARACTER,
	                                  INPUT  JsonParameter AS OELongchar,
	                                  OUTPUT JsonSchema    AS OELongchar ):
        DEFINE VARIABLE lcParameter AS LONGCHAR NO-UNDO.
        DEFINE VARIABLE lcResponse  AS LONGCHAR NO-UNDO.
        lcParameter = JsonParameter:Data.
        writeLog ( SUBSTITUTE ("ServiceName: &1 GetSchema()", ServiceName)).
        writeLog (STRING(lcParameter)).
        JsonSchema = NEW OELongchar().
        RUN ListLabel/OpenEdgeAdapter/OpenEdgeGateway.p ON SERVER mhAppserver 
              (INPUT ServiceName, INPUT "GetSchema", INPUT lcParameter, INPUT "", OUTPUT lcResponse ).
        JsonSchema:Data = lcResponse.
		RETURN TRUE.
	END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LOGICAL ClientEvent( INPUT  ServiceName       AS CHARACTER, 
                                       INPUT  JsonParameter     AS OELongchar,
                                       INPUT  JsonDataRequest   AS OELongchar,
                                       OUTPUT JsonDataResponse  AS OELongchar ):
        DEFINE VARIABLE lcRequest   AS LONGCHAR NO-UNDO.
        DEFINE VARIABLE lcParameter AS LONGCHAR NO-UNDO.
        DEFINE VARIABLE lcResponse  AS LONGCHAR NO-UNDO.
        
        lcParameter = JsonParameter:Data.
        writeLog ( SUBSTITUTE ("ServiceName: &1 ClientEvent()", ServiceName)).
        writeLog (STRING(lcParameter)).
        lcRequest = JsonDataRequest:Data.
        writeLog (STRING(lcRequest)).
        JsonDataResponse = NEW OELongchar().
        RUN ListLabel/OpenEdgeAdapter/OpenEdgeGateway.p ON SERVER mhAppserver 
            (INPUT ServiceName, INPUT "ClientEvent", INPUT lcParameter, INPUT lcRequest, OUTPUT lcResponse ).

        JsonDataResponse:Data = lcResponse.
        RETURN TRUE.
    END METHOD.
    

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID WriteLog( INPUT pcMessage AS CHARACTER ):
	    /*
	    IF pcMessage = "CLEAR" THEN 
	    DO:
            OUTPUT STREAM s TO VALUE (mcLogfile).
            OUTPUT STREAM s CLOSE.
            RETURN.
	    END. 
	    
	    OUTPUT STREAM s TO VALUE (mcLogfile) APPEND.
	    PUT STREAM s UNFORMATTED pcMessage SKIP.
        OUTPUT STREAM s CLOSE.
        */
	END METHOD.



	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	DESTRUCTOR PUBLIC Sports2000ServiceAdapter ( ):

        IF VALID-HANDLE (mhAppserver) AND mhAppserver <> SESSION THEN 
        DO:
            IF mhAppserver:CONNECTED () THEN 
                mhAppserver:DISCONNECT ().
            DELETE OBJECT mhAppserver.
        END.    

	END DESTRUCTOR.

END CLASS.