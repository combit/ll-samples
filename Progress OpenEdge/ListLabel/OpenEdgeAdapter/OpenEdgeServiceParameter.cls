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
    File        : OpenEdgeServiceParameter
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting 
    Created     : Fri Feb 12 06:14:02 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/
USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter: 
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeServiceParameter.i}

    DEFINE PUBLIC PROPERTY UseInvariantCulture AS LOGICAL NO-UNDO 
    GET.
    PRIVATE SET. 

    DEFINE PUBLIC PROPERTY ClientCulture AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 

    DEFINE PUBLIC PROPERTY MaxRows AS INTEGER NO-UNDO 
    GET.
    PRIVATE SET. 

    DEFINE PUBLIC PROPERTY ClientId AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET. 
 
    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeServiceParameter (  ):
		SUPER ().
	END CONSTRUCTOR.
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeServiceParameter ( plcJsonData AS LONGCHAR ):
        SUPER ().
        IF LENGTH (plcJsonData) > 0 THEN
        DO: 
            DATASET dsOpenEdgeServiceParameter:READ-JSON ("LONGCHAR",plcJsonData,"EMPTY") NO-ERROR.
            FOR EACH OEServiceParameter:
                CASE OEServiceParameter.OEParameterName:
                    WHEN "ClientId" THEN 
                        ClientId = OEServiceParameter.OEParameterValue.
                    WHEN "UseInvariantCulture" THEN 
                        UseInvariantCulture = LOGICAL(OEServiceParameter.OEParameterValue) NO-ERROR.
                    WHEN "ClientCulture" THEN 
                        ClientCulture = OEServiceParameter.OEParameterValue.
                    WHEN "MaxRows" THEN 
                        MaxRows = INTEGER (OEServiceParameter.OEParameterValue) NO-ERROR.
                END CASE.    
            END.    
        END.    
	END CONSTRUCTOR.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC CHARACTER ParameterValue( pcParameterName AS CHARACTER ):
		DEFINE VARIABLE cValue AS CHARACTER NO-UNDO.
        FIND OEServiceParameter WHERE OEServiceParameter.OEParameterName = pcParameterName 
             NO-ERROR.
        IF AVAILABLE OEServiceParameter THEN 
            cValue = OEServiceParameter.OEParameterValue.
		RETURN cValue.
	END METHOD.

    METHOD PUBLIC CHARACTER LlReportParameterValue( pcParameterName AS CHARACTER ):
        DEFINE VARIABLE cValue AS CHARACTER NO-UNDO.
        FIND OEServiceParameter WHERE OEServiceParameter.OEParameterName = "LlReportParameter." + pcParameterName 
             NO-ERROR.
        IF AVAILABLE OEServiceParameter THEN 
            cValue = OEServiceParameter.OEParameterValue.
        RETURN cValue.
    END METHOD.


END CLASS.