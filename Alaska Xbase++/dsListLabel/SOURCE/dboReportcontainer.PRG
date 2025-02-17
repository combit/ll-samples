/*============================================================================
 File Name:	   reportcontainer.PRG
 Author:       Marcus Herz
 Description:
 Created:			 29.05.2020     14:52:49        Updated: �29.05.2020      �14:52:49
 Copyright:		 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//=========================================
PROCEDURE dboReportContainer(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel
	LOCAL dboOrdDetail, dboOrders, dboCustomers, dboProducts

	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO  LL_PRINT_PREVIEW
	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// DEMO CODE starts here
	// D: Datenbank sollte bei Applikation liegen...
	//    Tabellen mit Xbase++ DBE �ffnen und die Workarea in einem Klasseobjekt kapseln (hier XClass++)
	// US: Database should be with application exe...
	//    open tables via Xbase++ DBE and wrap workarea in a class object (using XClass++)

	dboCustomers	:= OpenDbTable("CUSTOMERS")
	dboCustomers:ordsetfocus("CUSTOMERID")

	dboProducts	:= OpenDbTable("PRODUCTS")
	dboProducts:ordsetfocus("PRODUCTID")

	dboOrdDetail	:= OpenDbTable("ORDDETAIL")
	dboOrdDetail:ordsetfocus("ORDERID")

	dboOrdDetail:SetRelation( dboProducts,,"PRODUCTID")

	dboOrders	:= OpenDbTable("ORDERS")
	dboOrders:ordsetfocus("ORDERID")

	dboOrders:SetRelation( dboCustomers,,"CUSTOMERID")

	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:AddTable("ORDDETAIL")
	oListLabel	:AddTable("ORDERS")

	oListLabel	:DataSetField(dboOrdDetail		,"ORDDETAIL")
	oListLabel	:DataSetField(dboOrders			,"ORDERS"	)
	oListLabel	:DataSetField(dboCustomers		,"CUSTOMERS")
	oListLabel	:DataSetField(dboProducts		,"PRODUCTS"	)

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelation("ORDDETAIL","ORDERS","ORDDETAIL")

	// D: Tabellenobjekt anmelden, �ber dies Tabelle wird f�r die Liste geskippt
	// US:register table object, the report will skip through this table
	oListLabel:connect(dboOrders)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:tablechange	:= {|o,l,c,p| _TableChange(o,l,c,p)}
	oListLabel:PrintOption(nPrintingTarget)

	if lDesignDocument
		oListLabel:design()
	else
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D: aufr�umen
	// US: clean up
	oListLabel:destroy()

	// D:  Destroy Objekt, Datei schliessen
	// US: Destroy object, close table
	dboOrders:close()
	dboOrdDetail:close()
	dboProducts:close()
	dboCustomers:close()
RETURN

//=========================================
STATIC FUNC _TableChange(oLL,lStart,cChild,cParent)
	if lStart .and. !empty(cParent)
		if cChild <> cParent
			oLL:GetSelect(cChild):setscope( SCOPE_BOTH, (oLL:GetSelect(cParent)):ORDERID)
		endif
   elseif !lStart .and. !empty(cParent)
		oLL:GetSelect(cChild):ClearScope()
	endif
RETURN NIL

