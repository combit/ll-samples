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
    File        : DynamicSalesReport
    Purpose     : 
    Syntax      : 
    Description : This example creates data because of service parameters
                  passed from the List & Label Layout.
                  The service parameters are *not* used to filter data
                  in the layout!
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Wed Jun 29 20:57:16 CEST 2016
    Notes       : Layout: SalesReport.lst
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeServiceParameter FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.DynamicSalesReport INHERITS OpenEdgeDatasetService:
    
    DEFINE TEMP-TABLE ttSales NO-UNDO
        FIELD SalesRep LIKE Salesrep.SalesRep
        FIELD SalesAmount AS DECIMAL 
        INDEX pix IS PRIMARY UNIQUE Salesrep.
        
    DEFINE TEMP-TABLE ttSalesRep NO-UNDO LIKE Salesrep.    
        
    DEFINE DATASET dsSales FOR ttSales, ttSalesrep
        DATA-RELATION Salesrep FOR ttSales, ttSalesRep
            RELATION-FIELDS (SalesRep,SalesRep).
        
	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC DynamicSalesReport (  ):
		SUPER (DATASET dsSales:HANDLE).
	END CONSTRUCTOR.
	      
	CONSTRUCTOR PUBLIC DynamicSalesReport ( INPUT phDataset AS HANDLE ):
		SUPER (DATASET dsSales:HANDLE ).
	END CONSTRUCTOR.
	
	/* Override the getData Method of the OpenEdgeService 
	   We use the ServiceParameters to create data */
	METHOD OVERRIDE PUBLIC LONGCHAR getData( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
	    
	    DEFINE VARIABLE oServiceParameter AS OpenEdgeServiceParameter NO-UNDO.
	    DEFINE VARIABLE cValues   AS CHARACTER NO-UNDO.
	    DEFINE VARIABLE iValue    AS INTEGER   NO-UNDO.
	    DEFINE VARIABLE cSalesrep AS CHARACTER NO-UNDO.
        FOR EACH Salesrep NO-LOCK:
            CREATE ttSalesRep.
            BUFFER-COPY Salesrep TO ttSalesRep.
        END.
	    oServiceParameter = NEW OpenEdgeServiceParameter(plcServiceParameterJson).
	    cValues = oServiceParameter:LlReportParameterValue("@Salesrep").
	    
	    IF cValues > "" THEN 
	    DO iValue = 1 TO NUM-ENTRIES(cValues,"|"):
	        cSalesrep = TRIM(ENTRY(iValue,cValues,"|")).
	        FIND Salesrep WHERE Salesrep.SalesRep = cSalesrep NO-LOCK NO-ERROR.
	        IF AVAILABLE Salesrep THEN 
	        DO:
	            CREATE ttSales.
	            ASSIGN ttSales.SalesRep = Salesrep.SalesRep.
	            FOR EACH Customer WHERE Customer.SalesRep = Salesrep.SalesRep NO-LOCK,
	                EACH Order OF Customer NO-LOCK,
	                EACH OrderLine OF Order:
	                ttSales.SalesAmount = ttSales.SalesAmount + OrderLine.ExtendedPrice.    
	            END.
	        END.
	    END.
		
		DEFINE VARIABLE lcData AS LONGCHAR NO-UNDO.
		
		lcData = SUPER:getData(INPUT plcServiceParameterJson, INPUT plcRequestJson).
		
		MESSAGE STRING(lcData)
        VIEW-AS ALERT-BOX.
		
		RETURN lcData.

	END METHOD.

END CLASS.