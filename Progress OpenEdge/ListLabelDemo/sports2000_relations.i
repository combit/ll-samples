/* sports2000_relations.i */
/* Generated: 05.12.2016 17:35:45 */
/* Parent -> Child : the first table is a foreign key in the second table */

/* Benefits */
ServiceSchema:registerFileRelation("Benefits","Employee","EmpNum,EmpNum","Benefits_Employee"). /* Indexes: Benefits.Benefits <->> Employee.EmpNo */
ServiceSchema:registerFileRelation("Benefits","Family","EmpNum,EmpNum","Benefits_Family"). /* Indexes: Benefits.Benefits <->> Family.EmpNoRelativeName */
ServiceSchema:registerFileRelation("Benefits","TimeSheet","EmpNum,EmpNum","Benefits_TimeSheet"). /* Indexes: Benefits.Benefits <->> TimeSheet.EmpNoDayRecorded */
ServiceSchema:registerFileRelation("Benefits","Vacation","EmpNum,EmpNum","Benefits_Vacation"). /* Indexes: Benefits.Benefits <->> Vacation.EmpNoStartDate */

/* BillTo */
ServiceSchema:registerFileRelation("BillTo","Order","CustNum,CustNum,BillToID,BillToID","BillTo_Order"). /* ** Indexes: BillTo.BillTo <->> Order.<none> */

/* Bin */
ServiceSchema:registerFileRelation("Bin","InventoryTrans","BinNum,BinNum","Bin_InventoryTrans"). /* ** Indexes: Bin.Bin <->> InventoryTrans.<none> */

/* Customer */
ServiceSchema:registerFileRelation("Customer","BillTo","CustNum,CustNum","Customer_BillTo"). /* Indexes: Customer.Customer <->> BillTo.custnumbillto */
ServiceSchema:registerFileRelation("Customer","Invoice","CustNum,CustNum","Customer_Invoice"). /* Indexes: Customer.Customer <->> Invoice.CustNum */
ServiceSchema:registerFileRelation("Customer","Order","CustNum,CustNum","Customer_Order"). /* Indexes: Customer.Customer <->> Order.CustOrder */
ServiceSchema:registerFileRelation("Customer","RefCall","CustNum,CustNum","Customer_RefCall"). /* Indexes: Customer.Customer <->> RefCall.CustNum */
ServiceSchema:registerFileRelation("Customer","ShipTo","CustNum,CustNum","Customer_ShipTo"). /* Indexes: Customer.Customer <->> ShipTo.custnumshipto */

/* Department */
ServiceSchema:registerFileRelation("Department","Employee","DeptCode,DeptCode","Department_Employee"). /* Indexes: Department.Department <->> Employee.DeptCode */

/* Employee */
ServiceSchema:registerFileRelation("Employee","Benefits","EmpNum,EmpNum","Employee_Benefits"). /* Indexes: Employee.Employee <->> Benefits.EmpNo */
ServiceSchema:registerFileRelation("Employee","Family","EmpNum,EmpNum","Employee_Family"). /* Indexes: Employee.Employee <->> Family.EmpNoRelativeName */
ServiceSchema:registerFileRelation("Employee","TimeSheet","EmpNum,EmpNum","Employee_TimeSheet"). /* Indexes: Employee.Employee <->> TimeSheet.EmpNoDayRecorded */
ServiceSchema:registerFileRelation("Employee","Vacation","EmpNum,EmpNum","Employee_Vacation"). /* Indexes: Employee.Employee <->> Vacation.EmpNoStartDate */

/* Item */
ServiceSchema:registerFileRelation("Item","Bin","Itemnum,Itemnum","Item_Bin"). /* Indexes: Item.Item <->> Bin.ItemNum */
ServiceSchema:registerFileRelation("Item","InventoryTrans","Itemnum,Itemnum","Item_InventoryTrans"). /* ** Indexes: Item.Item <->> InventoryTrans.<none> */
ServiceSchema:registerFileRelation("Item","OrderLine","Itemnum,Itemnum","Item_OrderLine"). /* Indexes: Item.Item <->> OrderLine.itemnum */
ServiceSchema:registerFileRelation("Item","POLine","Itemnum,Itemnum","Item_POLine"). /* ** Indexes: Item.Item <->> POLine.<none> */
ServiceSchema:registerFileRelation("Item","SupplierItemXref","Itemnum,Itemnum","Item_SupplierItemXref"). /* Indexes: Item.Item <->> SupplierItemXref.ItemNumSupplierID */

/* Order */
ServiceSchema:registerFileRelation("Order","Invoice","CustNum,CustNum,Ordernum,Ordernum","Order_Invoice2"). /* ** Indexes: Order.Order <->> Invoice.<none> */
ServiceSchema:registerFileRelation("Order","InventoryTrans","Ordernum,Ordernum","Order_InventoryTrans"). /* ** Indexes: Order.Order <->> InventoryTrans.<none> */
ServiceSchema:registerFileRelation("Order","Invoice","Ordernum,Ordernum","Order_Invoice"). /* Indexes: Order.Order <->> Invoice.OrderNum */
ServiceSchema:registerFileRelation("Order","OrderLine","Ordernum,Ordernum","Order_OrderLine"). /* Indexes: Order.Order <->> OrderLine.orderline */

/* PurchaseOrder */
ServiceSchema:registerFileRelation("PurchaseOrder","InventoryTrans","PONum,PONum","PurchaseOrder_InventoryTrans"). /* ** Indexes: PurchaseOrder.PurchaseOrder <->> InventoryTrans.<none> */
ServiceSchema:registerFileRelation("PurchaseOrder","POLine","PONum,PONum","PurchaseOrder_POLine"). /* Indexes: PurchaseOrder.PurchaseOrder <->> POLine.PONumLinenum */

/* Salesrep */
ServiceSchema:registerFileRelation("Salesrep","Customer","SalesRep,SalesRep","Salesrep_Customer"). /* Indexes: Salesrep.Salesrep <->> Customer.SalesRep */
ServiceSchema:registerFileRelation("Salesrep","Order","SalesRep,SalesRep","Salesrep_Order"). /* Indexes: Salesrep.Salesrep <->> Order.SalesRep */
ServiceSchema:registerFileRelation("Salesrep","RefCall","SalesRep,SalesRep","Salesrep_RefCall"). /* ** Indexes: Salesrep.Salesrep <->> RefCall.<none> */

/* ShipTo */
ServiceSchema:registerFileRelation("ShipTo","Order","CustNum,CustNum,ShipToID,ShipToID","ShipTo_Order"). /* ** Indexes: ShipTo.ShipTo <->> Order.<none> */

/* State */
ServiceSchema:registerFileRelation("State","BillTo","State,State","State_BillTo"). /* ** Indexes: State.State <->> BillTo.<none> */
ServiceSchema:registerFileRelation("State","Customer","State,State","State_Customer"). /* ** Indexes: State.State <->> Customer.<none> */
ServiceSchema:registerFileRelation("State","Employee","State,State","State_Employee"). /* ** Indexes: State.State <->> Employee.<none> */
ServiceSchema:registerFileRelation("State","ShipTo","State,State","State_ShipTo"). /* ** Indexes: State.State <->> ShipTo.<none> */
ServiceSchema:registerFileRelation("State","Supplier","State,State","State_Supplier"). /* ** Indexes: State.State <->> Supplier.<none> */
ServiceSchema:registerFileRelation("State","Warehouse","State,State","State_Warehouse"). /* ** Indexes: State.State <->> Warehouse.<none> */

/* Supplier */
ServiceSchema:registerFileRelation("Supplier","PurchaseOrder","SupplierIDNum,SupplierIDNum","Supplier_PurchaseOrder"). /* ** Indexes: Supplier.Supplier <->> PurchaseOrder.<none> */
ServiceSchema:registerFileRelation("Supplier","SupplierItemXref","SupplierIDNum,SupplierIDNum","Supplier_SupplierItemXref"). /* Indexes: Supplier.Supplier <->> SupplierItemXref.SupplieridItemNum */

/* Vacation */
ServiceSchema:registerFileRelation("Vacation","Employee","EmpNum,EmpNum,StartDate,StartDate","Vacation_Employee"). /* ** Indexes: Vacation.Vacation <->> Employee.<none> */

/* Warehouse */
ServiceSchema:registerFileRelation("Warehouse","Bin","WarehouseNum,WarehouseNum","Warehouse_Bin"). /* Indexes: Warehouse.Warehouse <->> Bin.WarehouseNumItemNum */
ServiceSchema:registerFileRelation("Warehouse","InventoryTrans","WarehouseNum,WarehouseNum","Warehouse_InventoryTrans"). /* ** Indexes: Warehouse.Warehouse <->> InventoryTrans.<none> */
ServiceSchema:registerFileRelation("Warehouse","Order","WarehouseNum,WarehouseNum","Warehouse_Order"). /* ** Indexes: Warehouse.Warehouse <->> Order.<none> */
