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
    File        : OpenEdgeNativeFunction
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Thu May 26 07:48:02 CEST 2016
    Notes       : Objekt to execute native Function call from LL.
                  Known as NativeAggregateFunctions.
                  In SQL this is quite easy. 
                  In OpenEdge unfortunatelly not!
                  
    A call is something like this (pseudo code):
      return TOTAL(Order.OrderTotal) from order where order.salesrep = "BBB".
      return <FunctionName>(<Expression>) from <Table> where <Filter>.
      
   <Function name> is an aggregate function used on a query for records
   found in <table> filtered by <filter>.
   
   <expression> is often just a single column name, but can be anything.
   This class implements the shunting yard algorithm to be able to 
   evaluate an <expression> at run time.
   
   The shunting yards algorithm parses an expression an transforms it to an
   expression in RPN (Reverse polish notation). 
   RPN is then evaluated using a stack and returns the result.
   
   In the moment the result here is always a single decimal value!

   Links:
   ------    
   https://en.wikipedia.org/wiki/Shunting-yard_algorithm
   
   c# implementation - but here we are in OpenEdge!
   http://www.csharpprogramming.tips/2015/12/infix-notation-parser-via-shunting-yard.html
                  
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeNativeFunctionArgs FROM PROPATH.


BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeNativeFunction: 
    
    DEFINE TEMP-TABLE ttOperator
        FIELD Operator           AS CHARACTER 
        FIELD Precedence         AS INTEGER 
        FIELD Associativity      AS CHARACTER 
        INDEX pix IS PRIMARY UNIQUE Operator.
        
    DEFINE PRIVATE VARIABLE miSeq AS INTEGER NO-UNDO.    
        
    DEFINE TEMP-TABLE ttOutput NO-UNDO
        FIELD OutputOrder AS INTEGER
        FIELD TokenNumber AS INTEGER
        INDEX pix IS PRIMARY UNIQUE OutputOrder
        INDEX ix IS UNIQUE TokenNumber.
        
    DEFINE TEMP-TABLE ttStack NO-UNDO
        FIELD StackOrder  AS INTEGER
        FIELD TokenNumber AS INTEGER 
        INDEX pix IS PRIMARY UNIQUE StackOrder
        INDEX ix IS UNIQUE TokenNumber.
        
    DEFINE TEMP-TABLE ttToken NO-UNDO
        FIELD TokenNumber AS INTEGER 
        FIELD TokenType   AS CHARACTER 
        FIELD Token       AS CHARACTER
        INDEX pix IS PRIMARY UNIQUE TokenNumber.
                
    DEFINE PRIVATE VARIABLE mhBuffer AS HANDLE  NO-UNDO. 
    DEFINE PRIVATE VARIABLE mhQuery  AS HANDLE  NO-UNDO.
    DEFINE PRIVATE VARIABLE miToken  AS INTEGER NO-UNDO.  
             
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC OpenEdgeNativeFunction (  ):
		SUPER ().
		init().
		
	END CONSTRUCTOR.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC INTEGER NativeCount( phBuffer AS HANDLE, pcWhere AS CHARACTER ):
		
		DEFINE VARIABLE iCount AS INTEGER NO-UNDO.
		DEFINE VARIABLE hQuery AS HANDLE  NO-UNDO.
		
		hQuery = createQuery (phBuffer,pcWhere).
		hQuery:QUERY-OPEN ().
		hQuery:GET-FIRST().
		DO WHILE hQuery:QUERY-OFF-END = FALSE:
		      iCount = iCount + 1.
		      hQuery:GET-NEXT ().
		END.
		RETURN iCount.
	END METHOD.

    METHOD PUBLIC DECIMAL NativeMaximum ( phBuffer AS HANDLE, pcWhere AS CHARACTER, pcExpression AS CHARACTER ):
        
        DEFINE VARIABLE dValue   AS DECIMAL   NO-UNDO.
        DEFINE VARIABLE dResult  AS DECIMAL   NO-UNDO INIT ?.
        DEFINE VARIABLE hQuery   AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cRPN     AS CHARACTER NO-UNDO.
        
        cRPN = convertToRPN(pcExpression).
        
        hQuery = createQuery (phBuffer,pcWhere).
        hQuery:QUERY-OPEN ().
        hQuery:GET-FIRST().
        DO WHILE hQuery:QUERY-OFF-END = FALSE:
              dValue = evaluate(mhBuffer).
              IF dResult = ? THEN 
                 dResult = dValue.
              ELSE 
                 dResult = MAX(dResult,dValue). 
              hQuery:GET-NEXT ().
        END.
        RETURN dResult.
    END METHOD.
    
    METHOD PUBLIC DECIMAL NativeMinimum ( phBuffer AS HANDLE, pcWhere AS CHARACTER, pcExpression AS CHARACTER ):
        
        DEFINE VARIABLE dValue   AS DECIMAL   NO-UNDO.
        DEFINE VARIABLE dResult  AS DECIMAL   NO-UNDO INIT ?.
        DEFINE VARIABLE hQuery   AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cRPN     AS CHARACTER NO-UNDO.
        
        cRPN = convertToRPN(pcExpression).
        
        hQuery = createQuery (phBuffer,pcWhere).
        hQuery:QUERY-OPEN ().
        hQuery:GET-FIRST().
        DO WHILE hQuery:QUERY-OFF-END = FALSE:
              dValue = evaluate(mhBuffer).
              IF dResult = ? THEN 
                 dResult = dValue.
              ELSE 
                 dResult = MIN(dResult,dValue). 
              hQuery:GET-NEXT ().
        END.
        RETURN dResult.
    END METHOD.
    
    METHOD PUBLIC DECIMAL NativeTotal ( phBuffer AS HANDLE, pcWhere AS CHARACTER, pcExpression AS CHARACTER ):
        
        DEFINE VARIABLE dValue   AS DECIMAL   NO-UNDO.
        DEFINE VARIABLE dResult  AS DECIMAL   NO-UNDO INIT 0.
        DEFINE VARIABLE hQuery   AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cRPN     AS CHARACTER NO-UNDO.
        
        cRPN = convertToRPN(pcExpression).
        hQuery = createQuery (phBuffer,pcWhere).
        hQuery:QUERY-OPEN ().
        hQuery:GET-FIRST().
        DO WHILE hQuery:QUERY-OFF-END = FALSE:
              dValue = evaluate(mhBuffer).
              dResult = dResult + dValue.
              hQuery:GET-NEXT ().
        END.
        RETURN dResult.
    END METHOD.
    
    METHOD PUBLIC DECIMAL NativeAverage ( phBuffer AS HANDLE, pcWhere AS CHARACTER, pcExpression AS CHARACTER ):
        
        DEFINE VARIABLE dTotal   AS DECIMAL   NO-UNDO.
        DEFINE VARIABLE dCount   AS DECIMAL   NO-UNDO.
        DEFINE VARIABLE dResult  AS DECIMAL   NO-UNDO INIT ?.
        DEFINE VARIABLE hQuery   AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cRPN     AS CHARACTER NO-UNDO.
        
        cRPN = convertToRPN(pcExpression).
        
        hQuery = createQuery (phBuffer,pcWhere).
        hQuery:QUERY-OPEN ().
        hQuery:GET-FIRST().
        DO WHILE hQuery:QUERY-OFF-END = FALSE:
              dTotal = dTotal + evaluate(mhBuffer).
              dCount = dCount + 1.
              hQuery:GET-NEXT ().
        END.
        
        IF dCount > 0 THEN 
           dResult = dTotal / dCount.
        
        RETURN dResult.
    END METHOD.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE HANDLE createQuery( phBuffer AS HANDLE, pcWhere AS CHARACTER ):
		
		IF NOT VALID-HANDLE (mhQuery) THEN 
		  CREATE QUERY mhQuery.

        mhBuffer = phBuffer.
        mhQuery:SET-BUFFERS(mhBuffer).

        IF pcWhere BEGINS "WHERE " THEN 
           ASSIGN pcWhere = SUBSTRING(pcWhere,7).
        IF pcWhere = "" THEN 
           pcWhere = "TRUE".
        
        mhQuery:QUERY-PREPARE( SUBSTITUTE ("FOR EACH &1 WHERE &2 NO-LOCK",phBuffer:NAME,pcWhere)) NO-ERROR.
        IF ERROR-STATUS:ERROR THEN
            mhQuery:QUERY-PREPARE( SUBSTITUTE ("FOR EACH &1 WHERE &2 NO-LOCK",phBuffer:NAME,"FALSE")). 
        
        /*
        mhQuery:QUERY-PREPARE( SUBSTITUTE ("FOR EACH &1",phBuffer:NAME,pcWhere)) NO-ERROR.
        
        phBuffer:TABLE-HANDLE:WRITE-JSON("FILE","T:\temp\calctable.json",TRUE).  
        */
		RETURN mhQuery.

	END METHOD.
         
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID init(  ):
	    
	    addOperator("+",1,"LEFT").
        addOperator("-",1,"LEFT").
        addOperator("*",2,"LEFT").
        addOperator("/",2,"LEFT").
        addOperator("^",3,"RIGHT").
        addOperator("(",0,"" ).
        addOperator(")",0,"" ).
        
		RETURN.

	END METHOD.     
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE VOID addOperator( pcOperator      AS CHARACTER,
	                                 piPrecedence    AS INTEGER,
	                                 pcAssociativity AS CHARACTER ):
		
		FIND ttOperator WHERE ttOperator.Operator = pcOperator NO-ERROR.
		IF NOT AVAILABLE ttOperator THEN 
		DO:
		    CREATE ttOperator.
		    ASSIGN ttOperator.Operator      = pcOperator
		           ttOperator.Precedence    = piPrecedence
		           ttOperator.Associativity = pcAssociativity.
		END.
		RETURN.

	END METHOD.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC CHARACTER parseExpression ( pcInfixNotationString AS CHARACTER ):
		
		DEFINE VARIABLE dValue                 AS DECIMAL   NO-UNDO.
		DEFINE VARIABLE cPostFixNotationString AS CHARACTER NO-UNDO.
		
		pcInfixNotationString = TRIM (pcInfixNotationString).
		IF pcInfixNotationString > "" THEN 
		DO:
		    cPostFixNotationString = convertToRPN(pcInfixNotationString).
		END.
		RETURN cPostFixNotationString.

	END METHOD.
    
    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PRIVATE LOGICAL isNumeric( pcText AS CHARACTER ):
		DEFINE VARIABLE dNumber   AS DECIMAL NO-UNDO.
		pcText = TRIM(pcText).
		IF pcText = "" THEN 
		   RETURN FALSE.
		   
		dNumber = DECIMAL(pcText) NO-ERROR.
		
		IF ERROR-STATUS:ERROR THEN 
		   RETURN FALSE.
		   
		RETURN TRUE. 
	END METHOD.
    
    METHOD PRIVATE LOGICAL isOperator (pcText AS CHARACTER ):
        pcText = TRIM (pcText).
        FIND ttOperator WHERE ttOperator.Operator = pcText NO-ERROR.
        RETURN AVAILABLE ttOperator.
    END METHOD .   
    
    METHOD PRIVATE LOGICAL isVariable (pcText AS CHARACTER ):
        
        RETURN FALSE.
    END.
    
    METHOD PRIVATE CHARACTER TokenType (pcText AS CHARACTER ):
        IF isOperator (pcText) THEN 
            RETURN "Operator".
        ELSE IF isNumeric(pcText) THEN 
            RETURN "Value".
        ELSE 
            RETURN "Variable".
    END.    
    
    /*------------------------------------------------------------------------------
     Purpose: Converts to Reverse Polish Notation
     Notes:   Shunting Yard Algorithm.
    ------------------------------------------------------------------------------*/
    METHOD PRIVATE CHARACTER convertToRPN (pcInfixNotationString AS CHARACTER):
        
        DEFINE VARIABLE cPostFixNotationString AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iValue AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cValue AS CHARACTER NO-UNDO.
        DEFINE VARIABLE lFound AS LOGICAL   NO-UNDO.
        DEFINE VARIABLE iToken AS INTEGER NO-UNDO.
        
        DEFINE BUFFER ttStack         FOR ttStack.
        DEFINE BUFFER ttStackToken    FOR ttToken.
        DEFINE BUFFER ttOperator      FOR ttOperator.
        DEFINE BUFFER ttStackOperator FOR ttOperator.
        
        EMPTY TEMP-TABLE ttStack.
        EMPTY TEMP-TABLE ttOutput.
        EMPTY TEMP-TABLE ttToken.
        
        /* Note: Minus in the middle of two variable cannot be detected */
        ASSIGN pcInfixNotationString = REPLACE(pcInfixNotationString,"("," ( ")
               pcInfixNotationString = REPLACE(pcInfixNotationString,")"," ) ")
               pcInfixNotationString = REPLACE(pcInfixNotationString,"+"," + ")
               pcInfixNotationString = REPLACE(pcInfixNotationString," -"," - ")
               pcInfixNotationString = REPLACE(pcInfixNotationString,"*"," * ")
               pcInfixNotationString = REPLACE(pcInfixNotationString,"/"," / ")
               pcInfixNotationString = REPLACE(pcInfixNotationString,"^"," ^ ")
               . 
        
        /* Convert to a list of tokens. */
        DO iValue = 1 TO NUM-ENTRIES(pcInfixNotationString," "):
             cValue = TRIM (ENTRY(iValue,pcInfixNotationString," ")).
             IF cValue = "" THEN 
                NEXT.
             miToken = miToken + 1.
             CREATE ttToken.
             ASSIGN ttToken.TokenNumber = miToken
                    ttToken.Token       = cValue
                    ttToken.TokenType   = TokenType(cValue).   
        END.
        
        /* Walk through the list */
        FOR EACH ttToken:
            CASE ttToken.TokenType:
                
                WHEN "Value" THEN 
                DO:
                    addToOutput(ttToken.TokenNumber).
                END.
                WHEN "Variable" THEN 
                DO:
                    addToOutput(ttToken.TokenNumber).
                END.
                WHEN "Operator" THEN 
                DO:
                    IF ttToken.Token = "(" THEN 
                    DO:
                        pushStack(ttToken.TokenNumber).
                    END.    
                    ELSE IF ttToken.Token = ")" THEN 
                    DO:
                        lFound = FALSE.
                        iToken = peekStack().
                        DO WHILE iToken > 0:
                            FIND ttStackToken WHERE ttStackToken.TokenNumber = iToken.
                            IF ttStackToken.Token <> "(" THEN 
                            DO:
                                popStack().
                                addToOutput(iToken).
                            END.
                            ELSE DO:
                                popStack().
                                lFound = TRUE.
                                LEAVE.
                            END.
                            iToken = peekStack().
                        END.
                        
                        IF lFound = FALSE THEN 
                        DO:
                            MESSAGE "( not found"
                            VIEW-AS ALERT-BOX.
                        END.
                    END.
                    ELSE DO:
                        iToken = PeekStack().
                        IF iToken > 0 THEN 
                        DO:
                            FIND ttStackToken    WHERE ttStackToken.TokenNumber = iToken.
                            FIND ttStackOperator WHERE ttStackOperator.Operator = ttStackToken.Token.
                            FIND ttOperator      WHERE ttOperator.Operator      = ttToken.Token.
                            
                            IF    (ttOperator.Associativity = "LEFT"  AND ttOperator.Precedence <= ttStackOperator.Precedence)
                               OR (ttOperator.Associativity = "RIGHT" AND ttOperator.Precedence <  ttStackOperator.Precedence) THEN 
                            DO:
                               popStack().
                               addToOutput(iToken).
                            END.
                        END.
                        pushStack(ttToken.TokenNumber).
                    END.
                    
                END.
            END CASE. 
               /*
            MESSAGE "Token:"  ttToken.Token SKIP 
                    "Output:" OutputContent() SKIP 
                    "Stack:"  StackContent()
            VIEW-AS ALERT-BOX.   
               */
        END.
        
        /* */
        iToken = peekStack().
        DO WHILE iToken > 0:
           FIND ttStackToken WHERE ttStackToken.TokenNumber = iToken.
           IF ttStackToken.Token = "(" THEN 
           DO:
               MESSAGE "Extra ( left"
               VIEW-AS ALERT-BOX.
           END.
           ELSE IF ttStackToken.Token = ")" THEN 
           DO:
               MESSAGE "Extra ) left"
               VIEW-AS ALERT-BOX.
           END.
           ELSE DO:
               addToOutput(iToken).
           END.
           PopStack().
           iToken = peekStack().
        END.
        
        cPostFixNotationString = "".
        FOR EACH ttOutput, FIRST ttToken OF ttOutput:
            cPostFixNotationString = cPostFixNotationString 
                                   + (IF cPostFixNotationString > "" THEN " " ELSE "")
                                   + ttToken.Token.
        END.
        
        RETURN cPostFixNotationString.
        
    END.


    METHOD PUBLIC DECIMAL evaluate( phBuffer AS HANDLE):
        
        EMPTY TEMP-TABLE ttStack.
        
        DEFINE VARIABLE iRight     AS INTEGER NO-UNDO.
        DEFINE VARIABLE iLeft      AS INTEGER NO-UNDO.
        
        DEFINE VARIABLE dValue      AS DECIMAL NO-UNDO.
        DEFINE VARIABLE dLeftValue  AS DECIMAL NO-UNDO.
        DEFINE VARIABLE dRightValue AS DECIMAL NO-UNDO.
        
        DEFINE VARIABLE dResult     AS DECIMAL NO-UNDO.
        
        DEFINE BUFFER ttValueToken FOR ttToken.
        
        DEFINE VARIABLE iToken AS INTEGER NO-UNDO.
        FOR EACH ttToken:
            iToken = iToken + 1.
        END.    
        
        /*
        IF NOT VALID-HANDLE (phBuffer) OR mhBuffer:TYPE <> "BUFFER" OR mhBuffer:AVAILABLE = FALSE THEN 
           RETURN 0. 
        */
        mhBuffer = phBuffer.
        
        FOR EACH ttOutput, FIRST ttToken OF ttOutput:
            
            CASE ttToken.TokenType:
                
                WHEN "Value" THEN 
                DO:
                    pushStack(ttOutput.TokenNumber).
                END.
                WHEN "Variable" THEN 
                DO:
                    pushStack(ttOutput.TokenNumber).
                END.
                WHEN "Operator" THEN 
                DO:
                    iRight = popStack().
                    iLeft  = popStack().
                    IF iLeft = 0 OR iRight = 0 THEN 
                    DO:
                        MESSAGE "Less than 2 values in the stack"
                        VIEW-AS ALERT-BOX.
                        RETURN 0.
                    END.
                    dLeftValue  = TokenValue(iLeft).
                    dRightValue = TokenValue(iRight).
                    IF dLeftValue = ? OR dRightValue = ? THEN 
                    DO:
                        MESSAGE "Value error" SKIP
                                "Left:" dLeftValue SKIP 
                                "Right:" dRightValue SKIP
                                VIEW-AS ALERT-BOX.
                        RETURN 0.
                    END.
                    dValue = ?.
                    CASE ttToken.Token:
                        WHEN "+" THEN
                           ASSIGN dValue = dLeftValue + dRightValue.
                        WHEN "-" THEN
                           ASSIGN dValue = dLeftValue - dRightValue.
                        WHEN "*" THEN
                           ASSIGN dValue = dLeftValue * dRightValue.
                        WHEN "/" THEN
                           ASSIGN dValue = dLeftValue / dRightValue NO-ERROR.
                    END.
                    IF dValue = ? THEN 
                    DO:
                        MESSAGE "unknown value calculated" 
                                VIEW-AS ALERT-BOX.
                        RETURN 0.
                    END.    
                    miToken = miToken + 1.
                    CREATE ttValueToken.
                    ASSIGN ttValueToken.TokenNumber = miToken
                           ttValueToken.Token       = STRING(dValue)
                           ttValueToken.TokenType   = "Value".   
                    pushStack(ttValueToken.TokenNumber).                    
                END.
                
            END.
        
        END.
        
        DEFINE VARIABLE iItems AS INTEGER NO-UNDO.
        FOR EACH ttStack:
            iItems = iItems + 1.
        END.
        IF iItems <> 1 THEN 
        DO:
            MESSAGE "Result Stack has" iItems "items"
            VIEW-AS ALERT-BOX.
            RETURN 0.
        END.
        
        FIND FIRST ttStack.
        dResult = TokenValue(ttStack.TokenNumber).
        IF dResult = ? THEN 
            RETURN 0.
        ELSE 
            RETURN dResult.   
    END.
    
    METHOD PRIVATE VOID addToOutput (piTokenNumber AS INTEGER):
        miSeq = miSeq + 1.
        CREATE ttOutput.
        ASSIGN ttOutput.OutputOrder = miSeq
               ttOutput.TokenNumber = piTokenNumber.
        RETURN.
    END.    
 
    METHOD PRIVATE VOID pushStack (piTokenNumber AS INTEGER):
        miSeq = miSeq + 1.
        CREATE ttStack.
        ASSIGN ttStack.StackOrder  = miSeq
               ttStack.TokenNumber = piTokenNumber.
        RETURN.
    END.  
    
    METHOD PRIVATE INTEGER popStack ():
        DEFINE VARIABLE iTokenNumber AS INTEGER NO-UNDO.
        FIND LAST ttStack NO-ERROR.
        IF AVAILABLE ttStack THEN 
        DO:
            iTokenNumber = ttStack.TokenNumber.
            DELETE ttStack.
        END.    
        RETURN iTokenNumber.
    END.  
    
    METHOD PRIVATE INTEGER peekStack ():
        DEFINE VARIABLE iTokenNumber AS INTEGER NO-UNDO.
        FIND LAST ttStack NO-ERROR.
        IF AVAILABLE ttStack THEN 
        DO:
            iTokenNumber = ttStack.TokenNumber.
        END.    
        RETURN iTokenNumber.
    END.  
    
    METHOD PRIVATE CHARACTER StackContent ():
        DEFINE VARIABLE cValue AS CHARACTER NO-UNDO.
        DEFINE BUFFER ttToken FOR ttToken.
        FOR EACH ttStack, FIRST ttToken OF ttStack BY ttStack.StackOrder DESCENDING:
        
            cValue = cValue + (IF cValue > "" THEN " " ELSE "")
                   + ttToken.Token.
        END.
        RETURN cValue.
    END.    
        
    METHOD PRIVATE CHARACTER OutputContent ():
        DEFINE VARIABLE cValue AS CHARACTER NO-UNDO.
        DEFINE BUFFER ttToken FOR ttToken.
        FOR EACH ttOutput, FIRST ttToken OF ttOutput:
            cValue = cValue + (IF cValue > "" THEN " " ELSE "")
                   + ttToken.Token.
        END.
        RETURN cValue.
    END.    

    METHOD PRIVATE DECIMAL TokenValue (piTokenNumber AS INTEGER):
        
        DEFINE VARIABLE dValue AS DECIMAL NO-UNDO INIT ?.
        DEFINE BUFFER ttToken FOR ttToken.
        
        DEFINE VARIABLE cField AS CHARACTER NO-UNDO.
        DEFINE VARIABLE hField AS HANDLE    NO-UNDO.
        DEFINE VARIABLE cExt   AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iExt   AS INTEGER   NO-UNDO.
        
        FIND ttToken WHERE ttToken.TokenNumber = piTokenNumber.
        
        CASE ttToken.TokenType:
            WHEN "Value" THEN 
            DO:
                dValue = DECIMAL(ttToken.Token) NO-ERROR.
            END.
            WHEN "Variable" THEN 
            DO:
                cField = ttToken.Token.
                cField = ENTRY (NUM-ENTRIES(cField,"."),cField,".").
                cField = TRIM(cField).
                IF INDEX (cField,"[") > 0 THEN 
                DO:
                    ASSIGN cExt   = ENTRY(2,cField,"[")
                           cField = ENTRY(1,cField,"[")
                           iExt   = INTEGER(REPLACE(cExt,"]",""))
                           dValue = mhBuffer:BUFFER-FIELD (cField):BUFFER-VALUE(iExt) NO-ERROR.
                END.           
                ELSE DO:
                   ASSIGN dValue = mhBuffer:BUFFER-FIELD (cField):BUFFER-VALUE NO-ERROR.
                END.   
            END.
        END.
        
        RETURN dValue.
        
    END.    

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	DESTRUCTOR PUBLIC OpenEdgeNativeFunction ( ):
	    
	    IF VALID-HANDLE(mhQuery) THEN 
	       DELETE OBJECT mhQuery NO-ERROR.
	       
	    RETURN.   

	END DESTRUCTOR.

END CLASS.