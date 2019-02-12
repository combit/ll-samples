
/*------------------------------------------------------------------------
    File        : dsOpenEdgeFunctionResponse.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : 
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

