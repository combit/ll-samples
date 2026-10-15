 /**********************************************************************
 * Copyright (C) 2019 by Taste IT Consulting ("TIC") -                *
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
    File        : OEServiceParameterInfoService
    Purpose     : Returns Service Parameter as a LL Table.
    Syntax      : 
    Description : Useful to test if report parameter from the report
                  server reach the service.
        
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : October 2019
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService   FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.OEServiceParameterInfoService INHERITS OpenEdgeDatasetService: 
    {ListLabel/OpenEdgeAdapter/dsOpenEdgeServiceParameter.i}
    
    CONSTRUCTOR PUBLIC OEServiceParameterInfoService (  ):
        SUPER (DATASET dsOpenEdgeServiceParameter:HANDLE).
    END CONSTRUCTOR.

    METHOD OVERRIDE PUBLIC LONGCHAR getData( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        DATASET dsOpenEdgeServiceParameter:READ-JSON ("LONGCHAR",plcServiceParameterJson,"EMPTY") NO-ERROR.
        RETURN SUPER:getData(INPUT plcServiceParameterJson, INPUT plcRequestJson).
    END METHOD.
END CLASS.