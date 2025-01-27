/*============================================================================
 File Name:	   XRechnung.PRG
 Author:       Marcus Herz
 Description:
 Created:		01.06.2021     14:32:29        Updated: þ12.12.2024      þ10:00:16
 Copyright:		 2021 DS-Datasoft, 87671 Ronsberg
 Revision:
 $Group:
============================================================================*/

#include "lldemo.ch"

//-------------------------------------------------------------------
PROCEDURE XRechnung(nPrintingTarget, lDesignDocument, cFolder)
	//-------------------------------------------------------------------
	LOCAL nCount := 0
	LOCAL oListLabel
	LOCAL cXRechnung	:= getAppDir() +"factur-x.xml"
	LOCAL cFile	:= "PDF"+ strzero(seconds(),8.0)+".PDF"
	LOCAL lRet

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

	// D: Datenbank sollte bei Applikation liegen...
	// US: Database should be with application exe...
	DbUseArea(.T., , "INVOICE")
	dbsetIndex("INVOICE")
	ordsetfocus("BILLNO")
	Goto top

	// select invoice
	dsSelectValue(,,"Select Invoice",select(),{;
		{"BILLNO"	,"BILLNO"},;
		{"Company"	,"NAME"	},;
		{"City"		,"CITY"	}},,,,{800,600})

	// D: Felder für LLDefineVariable anmelden, kein Parameter: aktuellen Workarea
	// US:register columns for LLDefineVariable, no paramater: active workarea
	oListLabel:DataSetVariable()

	DbUseArea(.T., , "Items")
	dbsetIndex("Items")
	ordsetfocus("BILLNO")

	set filter to field->billNo == invoice->BILLNO
	Goto top
	// D: Anzahl Artikel auf Rechnung ermitteln
	// US: Count how many items are on billNo
	Do While .not. eof()
		nCount++
		Skip
	EndDo
	Goto top

	// DEMO CODE starts here
	// D:  crtZugferd() => factur-x.xml
	// US: crtZugferd() => factur-x.xml
	ZUGFeRD():New():create(cXRechnung)

	// D:  setzen List & Label Optionen für ZUgFeRD
	// US: set List & Label options for ZUgFeRD
	oListLabel:ZugferdXml(cXRechnung)

	// D: aktuelle Workarea anmelden, über dies Tabelle wird für die Liste geskippt
	// US:register active workarea, the report will skip through this table
	oListLabel:connect(Select())

	// D: Anzahl Sätze für Fortschrittsbalken
	// US:number of records for progress bar
	oListLabel:lastrec(nCount)

	// D: alle Felder der aktuellen Workarea für LLDefineField anmelden
	// US:register all columns of active workarea for LLDefineField
	oListLabel:DataSetField(Select())

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:report	:= "INVOICE.LST"

	// D: ZUGFeRD Version deklarieren
	// US: declare ZUGFeRD version
	oListLabel:prepareblock	:= {|oLL, hJob| LlXSetParameter(hJob, LL_LLX_EXTENSIONTYPE_EXPORT, "PDF"   ,"PDF.ZUGFeRDConformanceLevel", "EXTENDED")}

	if lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	else

		// D:  automatisiertes Erstellen eines PDF ohne Benutzeraingriff: SaveAsPdf(cFile, lQuiet)
		// US: automated creation of a PDF file without user interaction: SaveAsPdf(cFile, lQuiet)
		lRet	:= oListLabel:saveaspdf(cFile, TRUE )

		if !lRet
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		else
			runshell('/C start " " /MIN "'+ GetAppDir()+cFile +'"')
		endif
	endif

	// D: aufräumen
	// US: clean up
	oListLabel:destroy()

	dbCloseArea()
RETURN

//=========================================
CLASS ZUGFeRD
	HIDDEN:
	PROTECTED:
		VAR _oRoot
		METHOD _CreateRoot()
		METHOD _ExchangedDocumentContext()
		METHOD _ExchangedDocument()                                 	// Rechnungskopf
		METHOD _SupplyChainTradeTransaction(oLine)							// Re-Positionen
		METHOD _SellerTradeParty(oSeller)						            // Verkäufer
		METHOD _BuyerTradeParty(oBuyer)											// Käufer
		METHOD _ApplicableHeaderTradeDelivery(oLine)
		METHOD _ApplicableHeaderTradeSettlement(oLine)
	EXPORTED:
		METHOD Init
		METHOD Create

		// only for this sample replace with your data
		VAR Seller
		VAR Total
		VAR nMwst
ENDCLASS

//=========================================
METHOD ZUGFeRD:Init(oParent)
	UNUSED (oParent)
RETURN self

//=========================================
METHOD ZUGFeRD:Create(cXmlFile)
	LOCAL oLine, oItem
	LOCAL hHandle
	LOCAL cDate

	::Seller	:= dataObject():New()
	::Seller		:STRASSE		:= "Kudamm 4711"
	::Seller		:ORT			:= "Berlin"
	::Seller		:PLZ			:= "14109"
	::Seller		:LAND			:= "DE"
	::Seller		:NAME			:= "Metropolitan Caffee"
	::Seller		:USTID		:= "DE123456789"
	::Seller		:KONTAKT		:= "Theke"
	::Seller		:TELNR		:= "+49 30 12345678"
	::Seller		:EMAIL		:= "info@seller.com"
	::Seller		:IBAN			:= "DE64200400600200400600"

	cDate		:=  set (_SET_DATEFORMAT, "yyyy-mm-dd")
	oLine 	:= NIL
	oItem 	:= NIL
	::Total	:= 0
	::nMwst	:= 19

	::_CreateRoot()

	::_ExchangedDocumentContext()

	::_ExchangedDocument()

	::_oRoot:addchild(;
		oLine	:= ::_oRoot:CreateElement("rsm:SupplyChainTradeTransaction"))              		//

	// beginn schleife Posten
	// IncludedSupplyChainTradeLineItem
	ITEMS->(dbgotop())
	do while !ITEMS->(eof())
		::_SupplyChainTradeTransaction(oLine)
		ITEMS->(dbskip())
	enddo

	oLine:addchild(;
		oItem	:= ::_oRoot:CreateElement("ram:ApplicableHeaderTradeAgreement" ))

	oItem:addchild(;
		::_oRoot:CreateElement("ram:BuyerReference", "AZ: XY"))                             // BT-10

	// SellerTradeParty
	::_SellerTradeParty(oItem)

	// BuyerTradeParty
	::_BuyerTradeParty(oItem)

	// ApplicableHeaderTradeDelivery
	::_ApplicableHeaderTradeDelivery(oLine)

	// ApplicableHeaderTradeSettlement
	::_ApplicableHeaderTradeSettlement(oLine)

	ferase(cXmlFile)
	hHandle	:= fcreate(cXmlFile)
	fwrite(hHandle, '<?xml version="1.0" encoding="UTF-8"?>' +CRLF+ Char2UTF8(::_oRoot:toXml()))
	fclose(hHandle)

	set( _SET_DATEFORMAT	, cDate )

RETURN NIL

//=========================================
METHOD ZUGFeRD:_CreateRoot()
	::_oRoot	:= XmlNode():CreateDocument("rsm:CrossIndustryInvoice","1.0","UTF-8")
	::_oRoot:addattribute("a"	,"urn:un:unece:uncefact:data:standard:QualifiedDataType:100", "xmlns" )
	::_oRoot:addattribute("rsm","urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100", "xmlns" )
	::_oRoot:addattribute("qdt","urn:un:unece:uncefact:data:standard:QualifiedDataType:100", "xmlns" )
	::_oRoot:addattribute("ram","urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100", "xmlns" )
	::_oRoot:addattribute("xs"	,"http://www.w3.org/2001/XMLSchema", "xmlns" )
	::_oRoot:addattribute("udt","urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100", "xmlns" )
RETURN ::_oRoot

//=========================================
METHOD ZUGFeRD:_ExchangedDocumentContext()
	// ExchangedDocumentContext
	::_oRoot:addchild(::_oRoot:CreateElement("rsm:ExchangedDocumentContext");        							// BG-2
		:addchild(::_oRoot:CreateElement("ram:BusinessProcessSpecifiedDocumentContextParameter" );			// BT-23
		:addchild(::_oRoot:CreateElement("ram:ID", "urn:fdc:peppol.eu:2017:poacc:billing:01:1.0" )));
		:addchild(::_oRoot:CreateElement("ram:GuidelineSpecifiedDocumentContextParameter" ); 					// BT-24
		:addchild(::_oRoot:CreateElement("ram:ID", "urn:cen.eu:en16931:2017#conformant#urn:factur-x.eu:1p0:extended" ))))

RETURN ::_oRoot

//=========================================
// TypeCode:
//  71 : Mahnung
// 380 : Handelsrechnung
// 384 : korrigierte rechnung
// 386 : Prepayment invoice / Anzahlung, Vorauskasse
// 381 : Credit note / Gutschrift
// 751 : Invoice information for accounting purposes => ProForma ?
//=========================================
METHOD ZUGFeRD:_ExchangedDocument()
	LOCAL oItem	:= NIL
	LOCAL cReg	:= ""

	::Seller		:STRASSE		:= "Kudamm 4711"
	::Seller		:ORT			:= "Berlin"
	::Seller		:PLZ			:= "14109"
	::Seller		:LAND			:= "DE"
	::Seller		:NAME			:= "Metropolitan Caffee"
	::Seller		:USTID		:= "DE123456789"
	::Seller		:KONTAKT		:= "Theke"
	::Seller		:TELNR		:= "+49 30 12345678"
	::Seller		:EMAIL		:= "info@seller.com"
	::Seller		:IBAN			:= "DE64200400600200400600"

	// offizielle Firmierung
	cReg	:= ::Seller:NAME	+ CRLF +;
			::Seller:STRASSE + CRLF +;
			::Seller:LAND +" "+ ::Seller:PLZ +" "+::Seller:ORT + CRLF +;
			"Geschäftsführer: Herr Idefix" + CRLF +;
			"HRB Berlin 2323"

	// ExchangedDocument / Invoice
	::_oRoot:addchild( oItem := ::_oRoot:CreateElement("rsm:ExchangedDocument"))
	oItem:addchild(::_oRoot:CreateElement("ram:ID", alltrim(INVOICE->BILLNO) ))            			// BT 1
	oItem:addchild(::_oRoot:CreateElement("ram:TypeCode", "380" ))                         			// BT 3
	oItem:addchild(::_oRoot:CreateElement("ram:IssueDateTime" );
		:addchild(::_oRoot:CreateElement("udt:DateTimeString", dtos(INVOICE->DATE), {{ "format", "102"}})))  // BT 2
	oItem:addchild(::_oRoot:CreateElement("ram:IncludedNote" );                           				// BG 1
		:addchild(::_oRoot:CreateElement("ram:Content", cReg));		      									// BT 22
		:addchild(::_oRoot:CreateElement("ram:SubjectCode", "REG" )))               						// BT 21
RETURN oItem

//=========================================
// orderpos
// beispiele für unitCode
// 'H87', 'Stück, Piece     '
// 'C62', 'ein Stück        '
// 'MTR', 'Meter            '
// 'KGM', 'kg               '
// 'LTR', 'Liter            '
// 'E50', 'Leistungs Einheit'
// 'AB' , 'Packungseinheit  '
// 'PR' , 'Paar             '
// 'SET', 'Satz             '
// 'P53', 'Stange           '
// 'HUR', 'Stunden          '
// 'OA' , 'Tafel, Platte    '
// 'TNE', 'Tonne            '
// 'CMT', 'Zentimeter       '
// 'GRM', 'Gramm            '
// 'MTR', 'lfm              '
// 'MTQ', 'Kubikmeter m3    '
// 'MMT', 'mm               '
// 'MTK', 'Quadratmeter m2  '
//=========================================
METHOD ZUGFeRD:_SupplyChainTradeTransaction(oParent)
	LOCAL oTrade:= NIL
	LOCAL oLine	:= NIL
	LOCAL oSub	:= NIL

	oParent:addchild(;
			oLine		:= ::_oRoot:CreateElement("ram:IncludedSupplyChainTradeLineItem" ))  								// BG 25

	// rechungsposition
	oLine	:addchild(::_oRoot:CreateElement("ram:AssociatedDocumentLineDocument" );
				:addchild(::_oRoot:CreateElement("ram:LineID", ntrim(ITEMS->(recno())))))   								// BT 126

	oLine	:addchild(oSub := ::_oRoot:CreateElement("ram:SpecifiedTradeProduct" ))                         		// BG-31

//	IF !empty(ITEMS->oArtikelc:ean_nr)
//		oSub:addchild(::_oRoot:CreateElement("ram:GlobalID", alltrim(ITEMS->:EAN_NR), {{"schemeID", "0160"}})) 	// BT-157
//	ENDIF

	oSub:addchild(::_oRoot:CreateElement("ram:SellerAssignedID", alltrim(ITEMS->ARTICLENO)))
	oSub:addchild(::_oRoot:CreateElement("ram:BuyerAssignedID", ITEMS->ARTICLENO))
	oSub:addchild(::_oRoot:CreateElement("ram:Name", alltrim(ITEMS->DESCRIPT1))) 											// BT-153
	oSub:addchild(::_oRoot:CreateElement("ram:Description", alltrim(ITEMS->DESCRIPT1) +CRLF+ alltrim(ITEMS->DESCRIPT2)))	// BT 154

	oLine	:addchild(oTrade := ::_oRoot:CreateElement("ram:SpecifiedLineTradeAgreement" ))      						// BG-29

	oTrade :addchild(oSub := ::_oRoot:CreateElement("ram:GrossPriceProductTradePrice"))

	oSub:addchild(::_oRoot:CreateElement("ram:ChargeAmount", ntrim(ITEMS->PRICEPP,2))) 									// BT-148
	oSub:addchild(::_oRoot:CreateElement("ram:BasisQuantity", "1",; 															// BT-149-1
		{{"unitCode", "H87"}}))     					                                                       			// BT-130

/*	bei Rabatten den rabatt betrag übergeben, nucht den rabattierten Preis
IF RABATT > 0
		nRabatt1		:= ITEMS->PRICEPP * RABATT / 100
		oSub:addchild(::_oRoot:CreateElement("ram:AppliedTradeAllowanceCharge");      									// BT-147
			:addchild(::_oRoot:CreateElement("ram:ChargeIndicator");
			:addchild(::_oRoot:CreateElement("udt:Indicator", "false")));
			:addchild(::_oRoot:CreateElement("ram:ActualAmount", ntrim(round(nRabatt1,2),2))))
	ENDIF
*/

	oTrade	:addchild(::_oRoot:CreateElement("ram:NetPriceProductTradePrice");
			:addchild(::_oRoot:CreateElement("ram:ChargeAmount", ntrim(round(ITEMS->PRICEPP,2),2)));					// BT-146
			:addchild(::_oRoot:CreateElement("ram:BasisQuantity", "1",;									 						// BT-149
			{{"unitCode", "H87"}})))     					                                                       		// BT-130


	oLine	:addchild(oSub := ::_oRoot:CreateElement("ram:SpecifiedLineTradeDelivery" ))

	oSub:addchild(::_oRoot:CreateElement("ram:BilledQuantity", ntrim(ITEMS->COUNT),;										// BT 129
			{{"unitCode", "H87"}}))

//	IF LIEFSCHNR > 0
//		oSub:addchild(::_oRoot:CreateElement("ram:DeliveryNoteReferencedDocument");                              // BG-X-83
//			:addchild(::_oRoot:CreateElement("ram:IssuerAssignedID", ntrim( LIEFSCHNR))))	 								// BT-X-92
//	ENDIF

	oLine	:addchild(::_oRoot:CreateElement("ram:SpecifiedLineTradeSettlement" );
			:addchild(::_oRoot:CreateElement("ram:ApplicableTradeTax" );														// BG 30
				:addchild(::_oRoot:CreateElement("ram:TypeCode", "VAT" ));     												// BT 151-0
				:addchild(::_oRoot:CreateElement("ram:CategoryCode", "S" ));   												// BT 151
				:addchild(::_oRoot:CreateElement("ram:RateApplicablePercent", ntrim(::nMwst) )));  						// BT 152
			:addchild(::_oRoot:CreateElement("ram:SpecifiedTradeSettlementLineMonetarySummation" );
				:addchild(::_oRoot:CreateElement("ram:LineTotalAmount", ntrim(ITEMS->PRICEPP * ITEMS->COUNT,2)))))	// BT 131
	::Total	+= ITEMS->PRICEPP * ITEMS->COUNT

RETURN oLine

//=========================================
METHOD ZUGFeRD:_SellerTradeParty(oItem)
	LOCAL oSeller	:= NIL
   LOCAL oPostal	:= NIL
   LOCAL oContact	:= NIL

	oItem:addchild(oSeller := ::_oRoot:CreateElement("ram:SellerTradeParty"))          							// BG 4
	oSeller:addchild(::_oRoot:CreateElement("ram:ID", "737237" ))                      							// BT 29
	oSeller:addchild(::_oRoot:CreateElement("ram:Name", ::Seller:NAME))												// BT 27

	oSeller:addchild( oContact := ::_oRoot:CreateElement("ram:DefinedTradeContact"))								// BG 6

	oContact:addchild(::_oRoot:CreateElement("ram:PersonName", "Hr Maier")) 										// BT 41
	oContact:addchild(::_oRoot:CreateElement("ram:TelephoneUniversalCommunication");
				:addchild(::_oRoot:CreateElement("ram:CompleteNumber", "+49 30 123 4321"))) 						// BT-42
	oContact:addchild(::_oRoot:CreateElement("ram:EmailURIUniversalCommunication");
				:addchild(::_oRoot:CreateElement("ram:URIID", "Maier@seller.de", {{ "schemeID", "EM"}})))		// BT-43

	oSeller:addchild(oPostal := ::_oRoot:CreateElement("ram:PostalTradeAddress" ))     							// BG 5
	oPostal:addchild(::_oRoot:CreateElement("ram:PostcodeCode", ::Seller:PLZ )) 									// BT 38
	oPostal:addchild(::_oRoot:CreateElement("ram:LineOne", ::Seller:STRASSE ))  									// BT 35
	oPostal:addchild(::_oRoot:CreateElement("ram:CityName", ::Seller:ORT ))     									// BT 37
	oPostal:addchild(::_oRoot:CreateElement("ram:CountryID", ::Seller:LAND ))	  									// BT 40

	oSeller:addchild(::_oRoot:CreateElement("ram:URIUniversalCommunication" );
				:addchild(::_oRoot:CreateElement("ram:URIID", "info@seller.de", {{ "schemeID", "EM"}}))) 		// BT 49
	oSeller:addchild(::_oRoot:CreateElement("ram:SpecifiedTaxRegistration", ::Seller:NAME);
				:addchild(::_oRoot:CreateElement("ram:ID", "DE1234567" , {{ "schemeID", "VA"}})))				// BT 48
RETURN oSeller

//=========================================
METHOD ZUGFeRD:_BuyerTradeParty(oItem)
	LOCAL oBuyer	:= NIL
   LOCAL oPostal	:= NIL
	// BuyerTradeParty
	oItem:addchild(oBuyer:= ::_oRoot:CreateElement("ram:BuyerTradeParty"))       									// BG 7
	oBuyer:addchild(::_oRoot:CreateElement("ram:ID", "737237" ))                 									// BT 46
	oBuyer:addchild(::_oRoot:CreateElement("ram:Name", INVOICE->NAME))           									// BT 44

	oBuyer:addchild(oPostal	:= ::_oRoot:CreateElement("ram:PostalTradeAddress" ))      							// BG 8
	oPostal:addchild(::_oRoot:CreateElement("ram:PostcodeCode", "10034")) 					 						// BT 53
	oPostal:addchild(::_oRoot:CreateElement("ram:LineOne", alltrim(INVOICE->STREET)))   						// BT 50
	oPostal:addchild(::_oRoot:CreateElement("ram:CityName", alltrim(INVOICE->CITY)))      						// BT 52
	oPostal:addchild(::_oRoot:CreateElement("ram:CountryID", "DE"))					 	    						// BT 55

	oBuyer:addchild(::_oRoot:CreateElement("ram:URIUniversalCommunication" );
				:addchild(::_oRoot:CreateElement("ram:URIID", "info@buyer.de", {{ "schemeID", "EM"}})))		// BT 49
	oBuyer:addchild(::_oRoot:CreateElement("ram:SpecifiedTaxRegistration", INVOICE->NAME);
				:addchild(::_oRoot:CreateElement("ram:ID", "DE1234567", {{ "schemeID", "VA"}})))					// BT 48
RETURN oBuyer

//=========================================
METHOD ZUGFeRD:_ApplicableHeaderTradeDelivery(oLine)
	LOCAL oSub	:= NIL
	// ApplicableHeaderTradeDelivery
	oLine:addchild(oSub	:= ::_oRoot:CreateElement("ram:ApplicableHeaderTradeDelivery" ))						// BG-13-00

	// lieferdatum
	oSub:addchild( ::_oRoot:CreateElement("ram:ActualDeliverySupplyChainEvent" );									// BT-72-000
		:addchild(::_oRoot:CreateElement("ram:OccurrenceDateTime" );													// BT-72-00
			:addchild(::_oRoot:CreateElement("udt:DateTimeString", dtos(date()-3), {{ "format", "102"}}))))	// BT-72

RETURN oLine

//=========================================
METHOD ZUGFeRD:_ApplicableHeaderTradeSettlement(oLine)
	LOCAL oItem	:= NIL
	LOCAL oSub	:= NIL
	LOCAL oTrade:= NIL

	// ApplicableHeaderTradeSettlement(oLine)
	oLine:addchild( oItem	:= ::_oRoot:CreateElement("ram:ApplicableHeaderTradeSettlement" ))

	oItem:addchild(::_oRoot:CreateElement("ram:InvoiceCurrencyCode", "EUR" ))            													// BT 5

	oItem:addchild(oSub := ::_oRoot:CreateElement("ram:SpecifiedTradeSettlementPaymentMeans"))											// BG-16
	oSub:addchild(::_oRoot:CreateElement("ram:TypeCode", "58"))                      														// BT-81
	oSub:addchild(::_oRoot:CreateElement("ram:Information", "Zahlung per SEPA Überweisung." ))											// BT-82
	oSub:addchild(::_oRoot:CreateElement("ram:PayeePartyCreditorFinancialAccount" );  														// BG-17
		:addchild(::_oRoot:CreateElement("ram:IBANID", "DE12500100200345"));				  	 													// BT-84
		:addchild(::_oRoot:CreateElement("ram:AccountName", alltrim(::Seller:NAME))))		  											 		// BT-85

	// mehrwersteuer
	// je mwst satz ein Knoten
	oItem:addchild(::_oRoot:CreateElement("ram:ApplicableTradeTax");
			:addchild(::_oRoot:CreateElement("ram:CalculatedAmount", ntrim(::total * ::nMwst / 100,2) )); 								// BT 117
			:addchild(::_oRoot:CreateElement("ram:TypeCode", "VAT" ));                   														// BT 118
			:addchild(::_oRoot:CreateElement("ram:BasisAmount", ntrim(::total,2) ));  															// BT 116
			:addchild(::_oRoot:CreateElement("ram:CategoryCode", "S"));                   													// BT 118
			:addchild(::_oRoot:CreateElement("ram:RateApplicablePercent", ntrim(::nMwst,2) )))												// BT-119

	// fällig zum
	oItem:addchild(oTrade := ::_oRoot:CreateElement("ram:SpecifiedTradePaymentTerms"))
	oTrade:addchild(::_oRoot:CreateElement("ram:Description", "Zahlbar innerhalb 30 Tagen netto bis 30.12.2024, 3% Skonto innerhalb 10 Tagen bis 10.12.2024" ))  // BT 20
	oTrade:addchild(::_oRoot:CreateElement("ram:DueDateDateTime");		 																			// BT-9-00
		:addchild(::_oRoot:CreateElement("udt:DateTimeString", dtos(date()+30), {{"format", "102"}})))									// BT-9

	//skonto, nur wenn tatsächlich gegeben
	oTrade:addchild(oSub :=  ::_oRoot:CreateElement("ram:ApplicableTradePaymentDiscountTerms"))											// BG-X-44
	oSub:addchild(::_oRoot:CreateElement("ram:BasisDateTime" );                                       									// BT-X-282-00
		:addchild(::_oRoot:CreateElement("udt:DateTimeString", dtos(date()+10), {{"format", "102"}})))				  					// BT-X-282

	oSub:addchild(::_oRoot:CreateElement("ram:BasisPeriodMeasure", "10", {{"unitCode", "DAY"}}))											// BT-X-283
	oSub:addchild(::_oRoot:CreateElement("ram:BasisAmount", ntrim(::total,2)))																	// BT-X-285
	oSub:addchild(::_oRoot:CreateElement("ram:CalculationPercent", ntrim(2,0)))																// BT-X-286
	oSub:addchild(::_oRoot:CreateElement("ram:ActualDiscountAmount", ntrim(::total * 3 / 100,2)))										// BT-X-287

	oItem:addchild(::_oRoot:CreateElement("ram:SpecifiedTradeSettlementHeaderMonetarySummation");										// BG 22
			:addchild(::_oRoot:CreateElement("ram:LineTotalAmount", ntrim(::total,2) ));  													// BT 106
			:addchild(::_oRoot:CreateElement("ram:TaxBasisTotalAmount", ntrim(::total,2)));  												// BT 109
			:addchild(::_oRoot:CreateElement("ram:TaxTotalAmount", ntrim(::total * ::nMwst / 100,2) , {{"currencyID", "EUR"}}));	// BT 110
			:addchild(::_oRoot:CreateElement("ram:GrandTotalAmount", ntrim(::total * (::nMwst + 100) / 100,2)));						// BT-112
			:addchild(::_oRoot:CreateElement("ram:DuePayableAmount", ntrim(::total * (::nMwst + 100) / 100,2))))						// BT-115
RETURN oItem












































