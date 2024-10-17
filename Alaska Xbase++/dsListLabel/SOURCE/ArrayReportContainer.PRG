/*============================================================================
 File Name:           arrayReportcontainer.PRG
 Author:       Marcus Herz
 Description:
 Created:                         29.05.2020     14:52:49        Updated: þ29.05.2020      þ14:52:49
 Copyright:                 2020 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//=========================================
PROCEDURE arrayReportContainer(nPrintingTarget, lDesignDocument, cFolder)
	LOCAL nError
	LOCAL oListLabel
	LOCAL aOrders		:= {}
	LOCAL aOrdDetail	:= {}

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
	// D: Tabellen öffnen
	// US: open tables
	DbUseArea(.T., , "CUSTOMERS")
	dbSetIndex("CUSTOMERS")
	ordSetfocus("CUSTOMERID")

	DbUseArea(.T., , "PRODUCTS")
	dbSetIndex("PRODUCTS")
	ordsetfocus("PRODUCTID")

	// D: diese beiden Tabellen werden als Array abgebildet
	// US: those two tables are copied into an array
	DbUseArea(.T., , "ORDDETAIL")
	dbSetIndex("ORDDETAIL")
	ordSetfocus("ORDERID")
	SELECT * FROM ORDDETAIL INTO OBJECTS aOrdDetail

	DbUseArea(.T., , "ORDERS")
	dbSetIndex("ORDERS")
	ordSetfocus("ORDERID")
	SELECT * FROM ORDERS INTO OBJECTS aOrders
	dbCloseArea()

	// D: Tabellen anmelden: AddTable(cSymbol, cDescription)
	// US:register tables
	oListLabel	:AddTable("ORDDETAIL")
	oListLabel	:AddTable("ORDERS")

	oListLabel	:DataSetField(aOrdDetail   ,"ORDDETAIL")
	oListLabel	:DataSetField(aOrders		,"ORDERS"	)
	oListLabel	:DataSetField(select("CUSTOMERS")	,"CUSTOMERS")
	oListLabel	:DataSetField(select("PRODUCTS")		,"PRODUCTS"	)

	// D: Relation definieren :AddTableRelationEx(cChild, cParent, cRelation, cDescription, cChildKey, cParentKey)
	// US:define relation
	oListLabel	:AddTableRelation("ORDDETAIL","ORDERS","ORDDETAIL")

	// D: Tabellenobjekt anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register table object, the report will skip through this table
	oListLabel:connect(aOrders)

	// D: Event in Druckvorschau abfangen
	// US: catch events in preview
	oListLabel:onNotify	:= {|nEvent,nId,oListLabel| CatchCallback(nEvent,nId,oListLabel)}

	// D: Tabellen positionieren, Customer nach Order, Products nach OrdDetail
	// US: position tables, Customer by Order, Products by OrdDetail
	oListLabel:AddSync( {|oLL,nSelect,nRecno,cSelect| if(cSelect = "ORDERS", CUSTOMERS->(dbseek(nSelect[nRecno]:CUSTOMERID)),)})
	oListLabel:AddSync( {|oLL,nSelect,nRecno,cSelect| if(cSelect = "ORDDETAIL", PRODUCTS->(dbseek(nSelect[nRecno]:PRODUCTID)),)})

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )
	oListLabel:tablechange	:= {|o,l,c,p,n| _TableChange(o,l,c,p,n)}
	oListLabel:PrintOption(nPrintingTarget)

	if lDesignDocument
		oListLabel:design()
	else
		nError := oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D: aufräumen
	// US: clean up
	oListLabel:destroy()

	// D:  Dateien schliessen
	// US: close tables
	ORDDETAIL->(dbclosearea())
	CUSTOMERS->(dbclosearea())
	PRODUCTS->(dbclosearea())

RETURN

//=========================================
STATIC FUNC _TableChange(oLL,lStart,cChild,cParent, nPos)
	LOCAL aOrdDetail	:= {}
   LOCAL nOrderid
	IF lStart .and. !empty(cParent)
		IF cChild = "ORDDETAIL" .and. cParent == "ORDERS"

			// D:  Childdaten einlesen
			// US: read child data
			select ORDDETAIL
         nOrderid	:= oLL:GetSelect(cParent)[nPos]:ORDERID

			dbSetScope(SCOPE_BOTH, nOrderid)
			SELECT * FROM ORDDETAIL INTO OBJECTS aOrdDetail
			dbClearScope()

			oLL:DataSetField(aOrdDetail, "ORDDETAIL")
		ENDIF
	ENDIF
RETURN NIL

