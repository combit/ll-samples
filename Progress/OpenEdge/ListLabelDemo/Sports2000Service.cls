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
    File        : Sports2000Service
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Jan 26 11:28:25 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/
USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeService.
USING ListLabel.OpenEdgeAdapter.OpenEdgeSchema FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeClientEvent FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeCalculatedTableArgs FROM PROPATH.

/*
BLOCK-LEVEL ON ERROR UNDO, THROW.
*/
CLASS ListLabelDemo.Sports2000Service INHERITS OpenEdgeService: 

    /* Since LL24 - let's add a Calculated Table */
    DEFINE TEMP-TABLE calcCustomerSales NO-UNDO 
        FIELD CustNum     LIKE Customer.CustNum
        FIELD SalesYear   AS INTEGER
        FIELD SalesAmount AS DECIMAL
        INDEX pix IS PRIMARY UNIQUE CustNum SalesYear.

    DEFINE TEMP-TABLE calcSalesYear NO-UNDO
        FIELD SalesYear   AS INTEGER
        FIELD StartDate   AS DATE 
        FIELD EndDate     AS DATE 
        INDEX pix IS PRIMARY UNIQUE SalesYear.

	CONSTRUCTOR PUBLIC Sports2000Service (  ):
		SUPER ().
	END CONSTRUCTOR.


	METHOD OVERRIDE PUBLIC VOID registerSchema(  ):
        ServiceSchema:DatabaseName = "sports2000".
        FOR EACH sports2000._file WHERE _file._hidden = FALSE NO-LOCK:
              ServiceSchema:registerFile(_file._file-name).
        END.
        {ListLabelDemo/sports2000_relations.i}
        
        /* Add a calculated Temp-Table and a relation to the parent */
        ServiceSchema:registerCalculatedTable(TEMP-TABLE calcCustomerSales:DEFAULT-BUFFER-HANDLE).
        ServiceSchema:registerRelation(BUFFER Customer:HANDLE , TEMP-TABLE calcCustomerSales:DEFAULT-BUFFER-HANDLE, "CustNum,CustNum", "CustomerSales").
        
        /* Add a calculated table with no direct relation. May be used as a parent for the new LL25 filter based relation */ 
        ServiceSchema:registerCalculatedTable(TEMP-TABLE calcSalesYear:DEFAULT-BUFFER-HANDLE).
        
        /*
        ServiceSchema:registerFileRelation("Customer", "calcCustomerSales", "CustNum,CustNum", "CustomerSales").
        */
        /* Optional Views for large schemas */
        ServiceSchema:registerView("OrderView","Order,OrderLine",2).
        
        /* Optional Calculated Columns */
        ServiceSchema:registerCalculatedColumn("Customer","AddressLines","character").
        ServiceSchema:registerCalculatedColumn("BillTo","AddressLines","character").
        ServiceSchema:registerCalculatedColumn("ShipTo","AddressLines","character").
        ServiceSchema:registerCalculatedColumn("Warehouse","AddressLines","character").
        ServiceSchema:registerCalculatedColumn("Supplier","AddressLines","character").
        ServiceSchema:registerCalculatedColumn("Item","ItemImage","blob","image/jpeg").
        ServiceSchema:registerCalculatedColumn("Order","OrderTotal","decimal").
        /* 20170819 - To be able to sort orders by customer.name */
        ServiceSchema:registerCalculatedColumn("Order","CustomerName","character").
        
        RETURN.
	END METHOD.
	
    /* Since LL24 */
    METHOD OVERRIDE PUBLIC LONGCHAR ClientEvent( INPUT plcServiceParameterJson AS LONGCHAR, INPUT plcRequestJson AS LONGCHAR ):
        
        DEFINE VARIABLE oClientEvent AS OpenEdgeClientEvent NO-UNDO.
        
        oClientEvent = NEW OpenEdgeClientEvent(plcRequestJson).
        /*
        MESSAGE "ClientEvent:" oClientEvent:EventName "from ClientId:" oClientEvent:ClientId
        VIEW-AS ALERT-BOX.
        */
        RETURN "".

    END METHOD.

    /* Since LL24 */
    METHOD OVERRIDE PUBLIC VOID CalculateTable( INPUT poArgs AS OpenEdgeCalculatedTableArgs ):
        
        DEFINE BUFFER Customer  FOR Sports2000.Customer.
        DEFINE BUFFER Order     FOR Sports2000.Order.
        DEFINE BUFFER OrderLine FOR Sports2000.OrderLine.
        
        /* Create a tt buffer to scope it here. If not then the temp-table may not be returned properly 
           Not sure what the problem is.
        */
        DEFINE BUFFER calcCustomerSales FOR calcCustomerSales.
        
        DEFINE BUFFER calcSalesYear FOR calcSalesYear.
        
        IF poArgs:OETableName = "calcCustomerSales" THEN 
        DO:
            EMPTY TEMP-TABLE calcCustomerSales.
            poArgs:OETableBufferHandle = TEMP-TABLE calcCustomerSales:DEFAULT-BUFFER-HANDLE.
            
            /* Find the parent. */
            BUFFER Customer:FIND-UNIQUE (SUBSTITUTE("WHERE &1",poArgs:OEParentTableWhere), NO-LOCK).
            
            IF AVAILABLE Customer THEN 
            DO:
                DEFINE VARIABLE dAmount AS DECIMAL NO-UNDO.
                FOR EACH Order OF Customer NO-LOCK BREAK BY YEAR(Order.OrderDate):
                    IF FIRST-OF (YEAR(Order.OrderDate)) THEN 
                    DO:
                        dAmount = 0.
                    END.
                    FOR EACH OrderLine OF Order NO-LOCK:
                        dAmount = dAmount + OrderLine.ExtendedPrice.
                    END.
                    IF LAST-OF (YEAR(Order.OrderDate)) THEN
                    DO:
                        CREATE calcCustomerSales.
                        ASSIGN calcCustomerSales.CustNum     = Customer.CustNum
                               calcCustomerSales.SalesAmount = dAmount
                               calcCustomerSales.SalesYear   = YEAR(Order.OrderDate).
                    END.    
                END.
            END.
         END. 

        IF poArgs:OETableName = "calcSalesYear" THEN 
        DO:
            EMPTY TEMP-TABLE calcSalesYear.
            
            poArgs:OETableBufferHandle = TEMP-TABLE calcSalesYear:DEFAULT-BUFFER-HANDLE.
            
            DEFINE VARIABLE iFirstYear AS INTEGER NO-UNDO.
            DEFINE VARIABLE iLastYear  AS INTEGER NO-UNDO.
            DEFINE VARIABLE iYear      AS INTEGER NO-UNDO.
            
            FIND FIRST Order USE-INDEX orderdate NO-LOCK NO-ERROR.
            IF AVAILABLE Order THEN 
            DO:
                iFirstYear = YEAR(Order.OrderDate).
                FIND LAST Order USE-INDEX orderdate NO-LOCK.
                iLastYear  = YEAR(Order.OrderDate).
                
                DO iYear = iFirstYear TO iLastYear:
                    CREATE calcSalesYear.
                    ASSIGN calcSalesYear.SalesYear = iYear
                           calcSalesYear.StartDate = DATE(1,1,iYear)
                           calcSalesYear.EndDate   = DATE(12,31,iYear).
                END.
            END.
        END. 
 
    END METHOD.

    /*------------------------------------------------------------------------------
	 Purpose: The calulation methods are dynamically invoked.
	          Name = Calculate<DbTableName>
	          pcBuffer:  Temp-Table Buffer. May have a different name
	          pcColumns: Calcuated columns used in a request.
	 Notes:   If a calculated column isn't used for a request it doesn't exist in 
	          the buffer. All other colums from the DbTable are available.
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID CalculateCustomer( phBuffer AS HANDLE, pcColumns AS CHARACTER):
	    DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        IF LOOKUP("AddressLines",pcColumns) > 0 THEN 
        DO:
            ASSIGN cLines = phBuffer::NAME + CHR(10) + FormattedAddress(phBuffer).
    		phBuffer::AddressLines = cLines.
    	END.	
		RETURN.
	END METHOD.
	
    METHOD PUBLIC VOID CalculateSupplier( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        IF LOOKUP("AddressLines",pcColumns) > 0 THEN 
        DO:
            ASSIGN cLines = phBuffer::NAME + CHR(10) + FormattedAddress(phBuffer).
            phBuffer::AddressLines = cLines.
        END.    
        RETURN.
    END METHOD.

    METHOD PUBLIC VOID CalculateBillTo( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        IF LOOKUP("AddressLines",pcColumns) > 0 THEN 
        DO:
            FIND Customer WHERE Customer.CustNum = phBuffer::CustNum NO-LOCK NO-ERROR.
            IF AVAILABLE Customer THEN 
               cLines = Customer.Name.
            ASSIGN cLines = cLines + CHR(10) + FormattedAddress(phBuffer).
            phBuffer::AddressLines = cLines.
        END.    
        RETURN.
    END METHOD.
    
    METHOD PUBLIC VOID CalculateShipTo( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        IF LOOKUP("AddressLines",pcColumns) > 0 THEN 
        DO:
            FIND Customer WHERE Customer.CustNum = phBuffer::CustNum NO-LOCK NO-ERROR.
            IF AVAILABLE Customer THEN 
               cLines = Customer.Name.
            ASSIGN cLines = cLines + CHR(10) + FormattedAddress(phBuffer).
            phBuffer::AddressLines = cLines.
        END.    
        RETURN.
    END METHOD.

    METHOD PUBLIC VOID CalculateWarehouse( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        IF LOOKUP("AddressLines",pcColumns) > 0 THEN 
        DO:
            FIND Warehouse WHERE Warehouse.WarehouseNum = phBuffer::WarehouseNum NO-LOCK NO-ERROR.
            IF AVAILABLE Warehouse THEN 
               cLines = Warehouse.WarehouseName.
            ASSIGN cLines = cLines + CHR(10) + FormattedAddress(phBuffer).
            phBuffer::AddressLines = cLines.
        END.    
        RETURN.
    END METHOD.

    METHOD PUBLIC VOID CalculateItem( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cFile  AS CHARACTER NO-UNDO.
        DEFINE VARIABLE hField AS HANDLE    NO-UNDO.
        DEFINE VARIABLE m      AS MEMPTR    NO-UNDO.
        IF LOOKUP("ItemImage",pcColumns) > 0 THEN 
        DO:
            cFile = SUBSTITUTE("ListLabelDemo/Images/cat&1.jpg", STRING(phBuffer::ItemNum,"99999")).
            FILE-INFO:FILE-NAME = cFile.
            IF FILE-INFO:FULL-PATHNAME <> ? THEN 
            DO:
                COPY-LOB FROM FILE FILE-INFO:FULL-PATHNAME TO m.
                phBuffer::ItemImage = m.
                SET-SIZE(m) = 0.
            END.    
        END.    
        RETURN.
    END METHOD.
    
    METHOD PUBLIC VOID CalculateOrder( phBuffer AS HANDLE, pcColumns AS CHARACTER):
        DEFINE VARIABLE dTotal AS DECIMAL NO-UNDO.
        IF LOOKUP("OrderTotal",pcColumns) > 0 THEN 
        DO:
            FIND Order WHERE Order.Ordernum = phBuffer::OrderNum NO-LOCK NO-ERROR.
            FOR EACH OrderLine OF Order NO-LOCK:
                dTotal = dTotal + OrderLine.ExtendedPrice.
            END.    
            phBuffer::OrderTotal = dTotal.
        END.
        IF LOOKUP("CustomerName",pcColumns) > 0 THEN 
        DO:
            FIND Customer WHERE Customer.CustNum = phBuffer::CustNum NO-LOCK NO-ERROR.
            IF AVAILABLE Customer THEN 
                phBuffer::CustomerName = Customer.Name.
        END.
            
        RETURN.
    END METHOD.
    
	/*------------------------------------------------------------------------------
	 Purpose: Dynamic build of adress lines for different tables.
	 Notes:   You have to decide if you want to have someting like this dynamic or
	          static :-)
	------------------------------------------------------------------------------*/
	METHOD PRIVATE CHARACTER FormattedAddress ( phBuffer AS HANDLE ):
		
		DEFINE VARIABLE cLines AS CHARACTER NO-UNDO.

        ASSIGN cLines = phBuffer::Address
               cLines = cLines + CHR(10) + phBuffer::Address2 WHEN phBuffer::Address2 > "".
        IF phBuffer::Country = "USA" THEN 
            ASSIGN cLines = cLines + CHR (10) 
                          + SUBSTITUTE("&1, &2 &3",phBuffer::City,phBuffer::State,phBuffer::PostalCode).
        ELSE
            ASSIGN cLines = cLines + CHR (10) 
                          + SUBSTITUTE("&1 &2",phBuffer::PostalCode,phBuffer::City).
        IF phBuffer::Country > "" THEN 
            ASSIGN cLines = cLines + CHR (10) + CHR(10) + CAPS(phBuffer::Country).

		RETURN cLines.

	END METHOD.




END CLASS.
