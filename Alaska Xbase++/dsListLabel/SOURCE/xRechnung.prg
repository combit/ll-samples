/*============================================================================
 File Name:	   XRechnung.PRG
 Author:       Marcus Herz
 Description:
 Created:			 01.06.2021     14:32:29        Updated: þ01.06.2021      þ14:32:29
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
	// D: _crtXrechnung() => factur-x.xml
	// US: _crtXrechnung() => factur-x.xml
	_crtZugferd21(cXRechnung)

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
	oListLabel:addpath(".\xrechung")
	oListLabel:report	:= "INVOICE.LST"

	if lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	else

		// D:  automatisiertes Erstellen eines PDF ohne Benutzeraingriff: SaveAsPdf(cFile, lQuiet)
		// US: automated creation of a PDF file without user interaction: SaveAsPdf(cFile, lQuiet)
		lRet	:= oListLabel:saveaspdf(cFile, true )

		oListLabel:ZugferdXML()
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
STATIC FUNC _crtZugferd21(cXRechnung)
	LOCAL oRoot, oLine, oItem
	LOCAL dbOrder		:= dataObject():New()
	LOCAL dbOrderpos	:= dataObject():New()
	LOCAL dbFirma		:= dataObject():New()
	LOCAL hHandle
	LOCAL cDate

	// D: Verkäufer
	// US: seller
	dbFirma		:STRASSE		:= "Ulricistrasse 25"
	dbFirma		:ORT			:= "Berlin"
	dbFirma		:PLZ			:= "14109"
	dbFirma		:LAND			:= "DE"
	dbFirma		:NAME			:= "Deutschsprachige Xbase-Entwickler e.V."
	dbFirma		:USTID		:= "DE213342322"
	dbFirma		:KONTAKT		:= "Vorstand"
	dbFirma		:TELNR		:= "+49 30 54908741"
	dbFirma		:EMAIL		:= "vorstand@xbaseentwickler.de"
	dbFirma		:IBAN			:= "DE64200400600200400600"

	// D: Käufer, Auftrag
	// US: buyer, order
	dbOrderpos	:ARTBEZ		:= "Xbase++ Foundation Subscription"
	dbOrderpos	:PREIS		:= 1995
	dbOrderpos	:GELIEFERT	:= 1
	dbOrderpos	:POS			:= 1

	dbOrder		:RENR			:= invoice->billno
	dbOrder		:REDAT		:= invoice->date
	dbOrder		:BST			:= "9889432"
	dbOrder		:STRASSE		:= invoice->street
	dbOrder		:ORT			:= invoice->city
	dbOrder		:PLZ			:= "65760"
	dbOrder		:LAND			:= "DE"
	dbOrder		:NAME			:= invoice->name
	dbOrder		:MWSTSATZ	:= 19
	dbOrder		:FRACHT		:= 12.50
	dbOrder		:NETTO		:= dbOrderpos:PREIS  //+ dbOrder:FRACHT
	dbOrder		:MWST			:= round(dbOrder:NETTO * dbOrder:MWSTSATZ / 100,2)
	dbOrder		:BRUTTO		:= dbOrder:NETTO + dbOrder:MWST
	dbOrder		:USTID		:= "DE123456789"

	cDate	:=  set (_SET_DATEFORMAT, "yyyy-mm-dd")

	oRoot	:= XmlNode():CreateDocument("rsm:CrossIndustryInvoice","1.0","UTF-8")
	oLine := NIL
	oItem := NIL

	oRoot:addattribute("a"	,"urn:un:unece:uncefact:data:standard:QualifiedDataType:100", "xmlns" )
	oRoot:addattribute("rsm","urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100", "xmlns" )
	oRoot:addattribute("qdt","urn:un:unece:uncefact:data:standard:QualifiedDataType:10", "xmlns" )
	oRoot:addattribute("ram","urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100", "xmlns" )
	oRoot:addattribute("xs"	,"http://www.w3.org/2001/XMLSchema", "xmlns" )
	oRoot:addattribute("udt","urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100", "xmlns" )

	// ExchangedDocumentContext
	oRoot:addchild(oRoot:CreateElement("rsm:ExchangedDocumentContext");							// BG 2
		:addchild(oRoot:CreateElement("ram:GuidelineSpecifiedDocumentContextParameter" );   // BT 24
			:addchild(oRoot:CreateElement("ram:ID", "urn:cen.eu:en16931:2017" ))))

	// ExchangedDocument
	oRoot:addchild(oRoot:CreateElement("rsm:ExchangedDocument");
		:addchild(oRoot:CreateElement("ram:ID", alltrim(dbOrder:RENR) ));                   // BT 1
		:addchild(oRoot:CreateElement("ram:TypeCode", "380" ));                             // BT 3  380 : Handelsrechnung
		:addchild(oRoot:CreateElement("ram:IssueDateTime" );
			:addchild(oRoot:CreateElement("udt:DateTimeString", dtos(dbOrder:REDAT), {{ "format", "102"}})));  // BT 2
		:addchild(oRoot:CreateElement("ram:IncludedNote" );                           		// BG 1
			:addchild(oRoot:CreateElement("ram:Content", alltrim(dbOrder:BST))));      		// BT 22
		:addchild(oRoot:CreateElement("ram:IncludedNote" );
			:addchild(oRoot:CreateElement("ram:Content", alltrim(dbOrder:STRASSE) +CRLF+ alltrim(dbOrder:PLZ) +" "+ alltrim(dbOrder:ORT)));
			:addchild(oRoot:CreateElement("ram:SubjectCode", "REG" ))))                		// BT 21

	oRoot:addchild(;
		oLine	:= oRoot:CreateElement("rsm:SupplyChainTradeTransaction"))              		//

	// beginn Posten
	oLine:addchild(;
			oItem		:= oRoot:CreateElement("ram:IncludedSupplyChainTradeLineItem" ))  		// BG 25

	// IncludedSupplyChainTradeLineItem
	oItem	:addchild(oRoot:CreateElement("ram:AssociatedDocumentLineDocument" );
				:addchild(oRoot:CreateElement("ram:LineID", ntrim(dbOrderpos:POS ))))   		// BT 126

	oItem	:addchild(oRoot:CreateElement("ram:SpecifiedTradeProduct" );
				:addchild(oRoot:CreateElement("ram:GlobalID", dbOrderpos:ARTNR ,{{"schemeID", "0160"}}));
				:addchild(oRoot:CreateElement("ram:SellerAssignedID", dbOrderPos:KDARTNR));
				:addchild(oRoot:CreateElement("ram:Name", dbOrderPos:ARTBEZ)))

	oItem	:addchild(oRoot:CreateElement("ram:SpecifiedLineTradeAgreement" );         		// BG 29
				:addchild(oRoot:CreateElement("ram:GrossPriceProductTradePrice");
					:addchild(oRoot:CreateElement("ram:ChargeAmount", ntrim(dbOrderPos:PREIS))));		// BT 148
				:addchild(oRoot:CreateElement("ram:NetPriceProductTradePrice");
					:addchild(oRoot:CreateElement("ram:ChargeAmount", ntrim(dbOrderPos:PREIS)))))		// BT 146

	oItem	:addchild(oRoot:CreateElement("ram:SpecifiedLineTradeDelivery" );
			:addchild(oRoot:CreateElement("ram:BilledQuantity", ntrim(dbOrderPos:GELIEFERT), {{"unitCode", "H87"}})))           // BT 129

	oItem	:addchild(oRoot:CreateElement("ram:SpecifiedLineTradeSettlement" );
			:addchild(oRoot:CreateElement("ram:ApplicableTradeTax" );								// BG 30
				:addchild(oRoot:CreateElement("ram:TypeCode", "VAT" ));     						// BT 151-0
				:addchild(oRoot:CreateElement("ram:CategoryCode", "S" ));   						// BT 151
				:addchild(oRoot:CreateElement("ram:RateApplicablePercent", "19.00" )));  		// BT 152
			:addchild(oRoot:CreateElement("ram:SpecifiedTradeSettlementLineMonetarySummation" );
				:addchild(oRoot:CreateElement("ram:LineTotalAmount", ntrim(round(dbOrderPos:PREIS * (100 + dbOrder:MWSTSATZ) / 100,2)) ))))      // BT 131

	// ende 1ter postem

	oLine:addchild(;
			oItem		:= oRoot:CreateElement("ram:ApplicableHeaderTradeAgreement" ))

	// SellerTradeParty
	oItem:addchild(oRoot:CreateElement("ram:SellerTradeParty");                     			// BG 4
			:addchild(oRoot:CreateElement("ram:ID", "737237" ));                      			// BT 29
			:addchild(oRoot:CreateElement("ram:GlobalID", "4000001123452", {{"schemeID" ,"0088"}}));  // BT 29-0
			:addchild(oRoot:CreateElement("ram:Name", dbFirma:name));								// BT 27
			:addchild(oRoot:CreateElement("ram:PostalTradeAddress" );            				// BG 5
				:addchild(oRoot:CreateElement("ram:PostcodeCode", dbFirma:PLZ )); 				// BT 38
				:addchild(oRoot:CreateElement("ram:LineOne", dbFirma:STRASSE ));  				// BT 35
				:addchild(oRoot:CreateElement("ram:CityName", dbFirma:ORT ));     				// BT 37
				:addchild(oRoot:CreateElement("ram:CountryID", dbFirma:LAND )));  				// BT 40
			:addchild(oRoot:CreateElement("ram:SpecifiedTaxRegistration", dbFirma:name);
				:addchild(oRoot:CreateElement("ram:ID", dbFirma:USTID , {{ "schemeID", "VA"}}))))  // BT 48

	// BuyerTradeParty
	oItem:addchild(oRoot:CreateElement("ram:BuyerTradeParty");                 				// BG 7
			:addchild(oRoot:CreateElement("ram:ID", "737237" ));                 				// BT 46
			:addchild(oRoot:CreateElement("ram:GlobalID", "4000001123452", {{"schemeID" ,"0088"}}));  // BT 46-0
			:addchild(oRoot:CreateElement("ram:Name", dbFirma:name));            				// BT 44
			:addchild(oRoot:CreateElement("ram:PostalTradeAddress" );            				// BG 8
				:addchild(oRoot:CreateElement("ram:PostcodeCode", alltrim(dbOrder:PLZ) ));    // BT 53
				:addchild(oRoot:CreateElement("ram:LineOne", alltrim(dbOrder:STRASSE) ));     // BT 50
				:addchild(oRoot:CreateElement("ram:CityName", alltrim(dbOrder:ORT) ));        // BT 52
				:addchild(oRoot:CreateElement("ram:CountryID", alltrim(dbOrder:LAND) )));     // BT 55
			:addchild(oRoot:CreateElement("ram:SpecifiedTaxRegistration", dbFirma:name);
				:addchild(oRoot:CreateElement("ram:ID", alltrim(dbOrder:USTID) , {{ "schemeID", "VA"}}))))  // BT 48


	// ApplicableHeaderTradeDelivery
	oLine:addchild(oRoot:CreateElement("ram:ApplicableHeaderTradeDelivery" );
		:addchild(oRoot:CreateElement("ram:ActualDeliverySupplyChainEvent" );
			:addchild(oRoot:CreateElement("ram:OccurrenceDateTime" );
				:addchild(oRoot:CreateElement("udt:DateTimeString", dtos(dbOrder:REDAT), {{"format", "102"}})))))  // BT 72

	// ApplicableHeaderTradeSettlement
	oLine:addchild(oRoot:CreateElement("ram:ApplicableHeaderTradeSettlement" );
		:addchild(oRoot:CreateElement("ram:InvoiceCurrencyCode", "EUR" ));            		// BT 5
		:addchild(oRoot:CreateElement("ram:ApplicableTradeTax");
			:addchild(oRoot:CreateElement("ram:CalculatedAmount", ntrim(dbOrder:MWST) )); 	// BT 117
			:addchild(oRoot:CreateElement("ram:TypeCode", "VAT" ));                    		// BT 118
			:addchild(oRoot:CreateElement("ram:BasisAmount", ntrim(dbOrder:NETTO) ));  		// BT 116
			:addchild(oRoot:CreateElement("ram:CategoryCode", "S"));                   		// BT 118
			:addchild(oRoot:CreateElement("ram:RateApplicablePercent", ntrim(dbOrder:MWSTSATZ) )));
		:addchild(oRoot:CreateElement("ram:SpecifiedTradePaymentTerms");
			:addchild(oRoot:CreateElement("ram:Description", "Zahlbar innerhalb 30 Tagen netto bis 04.04.2018, 3% Skonto innerhalb 10 Tagen bis 15.03.2018" )));  // BT 20
		:addchild(oRoot:CreateElement("ram:SpecifiedTradeSettlementHeaderMonetarySummation");  // BG 22
			:addchild(oRoot:CreateElement("ram:LineTotalAmount", ntrim(dbOrder:NETTO) ));  		// BT 106
			:addchild(oRoot:CreateElement("ram:TaxBasisTotalAmount", ntrim(dbOrder:NETTO) ,{{"currencyID", "EUR"}}));  // BT 109
			:addchild(oRoot:CreateElement("ram:TaxTotalAmount", ntrim(dbOrder:MWST) , {{"currencyID", "EUR"}}));  // BT 110
			:addchild(oRoot:CreateElement("ram:GrandTotalAmount", ntrim(dbOrder:BRUTTO), {{"currencyID", "EUR"}}));
			:addchild(oRoot:CreateElement("ram:DuePayableAmount", ntrim(dbOrder:BRUTTO)))))

	ferase(cXRechnung)
	hHandle	:= fcreate(cXRechnung)
	fwrite(hHandle, '<?xml version="1.0" encoding="UTF-8"?>' +CRLF+ Char2UTF8(oRoot:toXml()))
	fclose(hHandle)

	set( _SET_DATEFORMAT	, cDate )

RETURN NIL

//=========================================
STATIC FUNC _crtXrechnung(cXRechnung)
	LOCAL oRoot, oNode, oParty, oTax, oTaxSubtotal, oLine, oPayment, oTotal
	LOCAL dbOrder		:= dataObject():New()
	LOCAL dbOrderpos	:= dataObject():New()
	LOCAL dbFirma		:= dataObject():New()
	LOCAL hHandle
	LOCAL cDate

	// D: Verkäufer
	// US: seller
	dbFirma		:STRASSE		:= "Ulricistrasse 25"
	dbFirma		:ORT			:= "Berlin"
	dbFirma		:PLZ			:= "14109"
	dbFirma		:LAND			:= "DE"
	dbFirma		:NAME			:= "Deutschsprachige Xbase-Entwickler e.V."
	dbFirma		:USTID		:= "DE213342322"
	dbFirma		:KONTAKT		:= "Vorstand"
	dbFirma		:TELNR		:= "+49 30 54908741"
	dbFirma		:EMAIL		:= "vorstand@xbaseentwickler.de"
	dbFirma		:IBAN			:= "DE64200400600200400600"

	// D: Käufer, Auftrag
	// US: buyer, order
	dbOrderpos	:UMSGRUPPE	:= "Xbase++"
	dbOrderpos	:PREIS		:= 995
	dbOrderpos	:GELIEFERT	:= 1
	dbOrderpos	:POS			:= 1

	dbOrder		:RENR			:= invoice->billno
	dbOrder		:REDAT		:= invoice->date
	dbOrder		:BST			:= "9889432"
	dbOrder		:RESTRASSE	:= invoice->street
	dbOrder		:REORT		:= invoice->city
	dbOrder		:REPLZ		:= "65760"
	dbOrder		:RELAND		:= "DE"
	dbOrder		:NAME			:= invoice->name
	dbOrder		:MWSTSATZ	:= 19
	dbOrder		:FRACHT		:= 12.50
	dbOrder		:RENETTO		:= dbOrderpos:PREIS * dbOrderpos:GELIEFERT + dbOrder:FRACHT
	dbOrder		:MWST			:= round(dbOrder:RENETTO * dbOrder:MWSTSATZ / 100,2)
	dbOrder		:RESUMME		:= dbOrder:RENETTO + dbOrder:MWST
	dbOrder		:USTID		:= "DE123456789"

	oNode				:= NIL
	oParty			:= NIL
	oTax				:= NIL
	oTaxSubtotal	:= NIL
	oLine				:= NIL
	oPayment			:= NIL
	oTotal			:= NIL

	cDate	:=  set (_SET_DATEFORMAT, "yyyy-mm-dd")

	oRoot	:= XmlNode():CreateDocument("ubl:Invoice","1.0","UTF-8")

	oRoot:addattribute("ubl", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2", "xmlns")
	oRoot:addattribute("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", "xmlns")
	oRoot:addattribute("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", "xmlns")
	oRoot:addattribute("xsi", "http://www.w3.org/2001/XMLSchema-instance", "xmlns")
	oRoot:addattribute("schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2 http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd", "xsi")

	oRoot:addchild(;
		oRoot:CreateElement("cbc:CustomizationID", "urn:cen.eu:en16931:2017#compliant#urn:xoev-de:kosit:standard:xrechnung_2.0"))

	oRoot:addchild(;
		oRoot:CreateElement("cbc:ID", alltrim(dbOrder:RENR)))                  			// BT-1
	oRoot:addchild(;
		oRoot:CreateElement("cbc:IssueDate", dtoc(ifempty(dbOrder:REDAT, date()))))   // BT-2
	oRoot:addchild(;
		oRoot:CreateElement("cbc:DueDate", dtoc(ifempty(dbOrder:REDAT, date())+30)))  // BT-2
	oRoot:addchild(;
		oRoot:CreateElement("cbc:InvoiceTypeCode", "380"))                        		// BT-3
	oRoot:addchild(;
		oRoot:CreateElement("cbc:DocumentCurrencyCode", "EUR" ))                      // BT-5
	oRoot:addchild(;
		oRoot:CreateElement("cbc:BuyerReference", alltrim(dbOrder:BST) ))             // BT-10

	//=========================================
	// D: Verkäufer
	// US: seller

	oRoot:addchild(;
		oRoot:CreateElement("cac:AccountingSupplierParty"):addchild(;   		         // BG-4
		oParty	:= oRoot:CreateElement("cac:Party")))

	oParty:addchild(;
		oRoot:CreateElement("cac:PostalAddress");                                 		// BG-5
		:addchild(;
			oRoot:CreateElement("cbc:StreetName", alltrim(dbFirma:STRASSE )));        	// BT-35
		:addchild(;
			oRoot:CreateElement("cbc:CityName", alltrim(dbFirma:ORT )));              	// BT-37
		:addchild(;
			oRoot:CreateElement("cbc:PostalZone", alltrim(dbFirma:PLZ )));         		// BT-38
		:addchild(;
			oRoot:CreateElement("cac:Country"):addchild(;                              // BT-40
				oRoot:CreateElement("cbc:IdentificationCode", alltrim(dbFirma:LAND )))))

	oParty:addchild(;
		oRoot:CreateElement("cac:PartyTaxScheme");
			:addchild(;
				oRoot:CreateElement("cbc:CompanyID", alltrim(dbFirma:USTID )));         // BT-32
			:addchild(;
				oRoot:CreateElement("cac:TaxScheme" ):AddChild(;
					oRoot:CreateElement("cbc:ID", "VAT"))));
		:addchild(;
			oRoot:CreateElement("cac:PartyLegalEntity");                               // BT-47
			:addchild(;
				oRoot:CreateElement("cbc:RegistrationName", alltrim( dbFirma:NAME ))))

	oParty:addchild(;
		oRoot:CreateElement("cac:Contact");            											// BG-6
		:addchild(;
			oRoot:CreateElement("cbc:Name", dbFirma:KONTAKT));            					// BT-41
		:addchild(;
			oRoot:CreateElement("cbc:Telephone",dbFirma:TELNR)); 								// BT-42
		:addchild(;
			oRoot:CreateElement("cbc:ElectronicMail",dbFirma:EMAIL )))             		// BT-43

	//=========================================
	// D: Käufer, Auftrag
	// US: buyer, order
	oRoot:addchild(;
		oRoot:CreateElement("cac:AccountingCustomerParty"):addchild(;   		      	// BG-7
		oParty	:= oRoot:CreateElement("cac:Party")))

	oParty:addchild(;
		oRoot:CreateElement("cac:PostalAddress");                                		// BG-8
		:addchild(;
			oRoot:CreateElement("cbc:StreetName", alltrim(dbOrder:RESTRASSE )));    	// BT-50
		:addchild(;
			oRoot:CreateElement("cbc:CityName", alltrim(dbOrder:REORT )));          	// BT-52
		:addchild(;
			oRoot:CreateElement("cbc:PostalZone", alltrim(dbOrder:REPLZ )));        	// BT-53
		:addchild(;
			oRoot:CreateElement("cac:Country"):addchild(;                        		// BT-55
				oRoot:CreateElement("cbc:IdentificationCode", alltrim(dbOrder:RELAND )))))

	oParty:addchild(;
		oRoot:CreateElement("cac:PartyTaxScheme");
			:addchild(;
				oRoot:CreateElement("cbc:CompanyID", alltrim(dbOrder:USTID )));          // BT-
			:addchild(;
				oRoot:CreateElement("cac:TaxScheme" ):AddChild(;
					oRoot:CreateElement("cbc:ID", "VAT"))));
		:addchild(;
			oRoot:CreateElement("cac:PartyLegalEntity");                               // BT-47
			:addchild(;
				oRoot:CreateElement("cbc:RegistrationName", alltrim( dbOrder:NAME ))))

	//=========================================
	// Zahlung
	oRoot:addchild(;
		oPayment	:= oRoot:CreateElement("cac:PaymentMeans"))                          // BG-16

	oPayment:addchild(;
		oRoot:CreateElement("cbc:PaymentMeansCode", "30" ))                       		// BT-81 Credit transfer

	oPayment:addchild(;
		oRoot:CreateElement("cbc:PaymentID", "Credit transfer" ))                     // BT-82

	oPayment:addchild(;
		oNode	:= oRoot:CreateElement("cac:PayeeFinancialAccount"))                    // BG-17

	oNode:addchild(;
     oRoot:CreateElement("cbc:ID", dbFirma:IBAN ))                      				// BT-84

	oNode:addchild(;
     oRoot:CreateElement("cbc:Name", alltrim( dbFIRMA:NAME )))  // BT-85

	//=========================================
	// D: Steuern
	// US: tax
	oRoot:addchild(;
		oTax	:= oRoot:CreateElement("cac:TaxTotal"))                                 // BG-23

	oTax:addchild(;
		oRoot:CreateElement("cbc:TaxAmount", ntrim(dbOrder:MWST,2));                  // BT-117
		:addAttribute("currencyID", "EUR"))

	oTax:addchild(;
		oTaxSubtotal	:= oRoot:CreateElement("cac:TaxSubtotal"))                     // BT-117

	oTaxSubtotal:addchild(;
		oRoot:CreateElement("cbc:TaxableAmount", ntrim(dbOrder:RENETTO,2));           // BT-116
		:addAttribute("currencyID", "EUR"))

	oTaxSubtotal:addchild(;
		oRoot:CreateElement("cbc:TaxAmount", ntrim(dbOrder:MWST,2));
		:addAttribute("currencyID", "EUR"))

	oTaxSubtotal:addchild(;
		oRoot:CreateElement("cac:TaxCategory");
			:addchild(;
				oRoot:CreateElement("cbc:ID", "S" ));
			:addchild(;
				oRoot:CreateElement("cbc:Percent", ntrim(dbOrder:MWSTSATZ,2)));
			:addchild(;
				oRoot:CreateElement("cac:TaxScheme"):addchild(;
					oRoot:CreateElement("cbc:ID", "VAT" ))))

	//=========================================
	// Total
	oRoot:addchild(;
		oTotal	:= oRoot:CreateElement("cac:LegalMonetaryTotal"))                    // BG-22

	oTotal:addchild(;
		oRoot:CreateElement("cbc:LineExtensionAmount", ntrim(dbOrder:RENETTO,2));     // BT-106
		:addAttribute("currencyID", "EUR"))

	oTotal:addchild(;
		oRoot:CreateElement("cbc:TaxExclusiveAmount", ntrim(dbOrder:RENETTO,2));      // BT-109
		:addAttribute("currencyID", "EUR"))

	oTotal:addchild(;
		oRoot:CreateElement("cbc:TaxInclusiveAmount", ntrim(dbOrder:RESUMME,2));      // BT-112
		:addAttribute("currencyID", "EUR"))

	oTotal:addchild(;
		oRoot:CreateElement("cbc:PayableAmount", ntrim(dbOrder:RESUMME,2));           // BT-115,
		:addAttribute("currencyID", "EUR"))

	//=========================================
	// DE: Liste Auftrags-Positionen,
	// US: list order pos,
	// do while ...
	oRoot:addchild(;
		oLine	:= oRoot:CreateElement("cac:InvoiceLine"))

	oLine:addchild(;
		oRoot:CreateElement("cbc:ID", ntrim(dbOrderpos:POS,0)))                     	// BT-126

	oLine:addchild(;
		oRoot:CreateElement("cbc:InvoicedQuantity", ntrim(dbOrderpos:GELIEFERT,0)); 	// BT-129
		:addAttribute("unitCode", "XPP" ))                                         	// BT-130

	oLine:addchild(;
		oRoot:CreateElement("cbc:LineExtensionAmount", ntrim(dbOrderpos:PREIS * dbOrderpos:GELIEFERT,2));  // BT-131
		:addAttribute("currencyID", "EUR" ))

	oLine:addchild(;
		oRoot:CreateElement("cac:Item");                                  				// BG-31
		:addchild(;
			oRoot:CreateElement("cbc:Description"));                                	// BT-154
		:addchild(;
			oRoot:CreateElement("cbc:Name", alltrim(dbOrderpos:UMSGRUPPE)));        	// BT-153
		:addchild(;                                                              		// BG-30
			oRoot:CreateElement("cac:ClassifiedTaxCategory" );
			:addchild(;
				oRoot:CreateElement("cbc:ID", "S" ));                                	// BT-151
			:addchild(;
				oRoot:CreateElement("cbc:Percent", ntrim(dbOrder:MWSTSATZ,2)));      	// BT-152
			:addchild(;
				oRoot:CreateElement("cac:TaxScheme" ):Addchild(;
					oRoot:CreateElement("cbc:ID", "VAT" )))))

	oLine:addchild(;
		oRoot:CreateElement("cac:Price" );                                				// BG-29
		:addchild(;
			oRoot:CreateElement("cbc:PriceAmount", ntrim(dbOrderpos:PREIS,2));      	// BT-146
			:addAttribute("currencyID", "EUR" )))

	// enddo   // order pos

	if dbOrder:FRACHT  > 0
		oRoot:addchild(;
			oLine	:= oRoot:CreateElement("cac:InvoiceLine"))

		oLine:addchild(;
			oRoot:CreateElement("cbc:ID", ntrim(dbOrderpos:POS + 1 ,0)))            	// BT-126

		oLine:addchild(;
			oRoot:CreateElement("cbc:InvoicedQuantity", ntrim(1,0));  // BT-129
			:addAttribute("unitCode", "XPP" ))                                      	// BT-130

		oLine:addchild(;
			oRoot:CreateElement("cbc:LineExtensionAmount", ntrim(dbOrder:FRACHT ,2));	// BT-131
			:addAttribute("currencyID", "EUR" ))

		oLine:addchild(;
			oRoot:CreateElement("cac:Item");                                  			// BG-31
			:addchild(;
				oRoot:CreateElement("cbc:Description"));                                // BT-154
			:addchild(;
				oRoot:CreateElement("cbc:Name", if(dbOrder:FRACHT > 0, "Fracht,", "")));// BT-153
			:addchild(;                                                              	// BG-30
				oRoot:CreateElement("cac:ClassifiedTaxCategory" );
				:addchild(;
					oRoot:CreateElement("cbc:ID", "S" ));                                // BT-151
				:addchild(;
					oRoot:CreateElement("cbc:Percent", ntrim(dbOrder:MWSTSATZ,2)));      // BT-152
				:addchild(;                                                            	// access
					oRoot:CreateElement("cac:TaxScheme" ):Addchild(;
						oRoot:CreateElement("cbc:ID", "VAT" )))))

		oLine:addchild(;
			oRoot:CreateElement("cac:Price" );                                			// BG-29
			:addchild(;
				oRoot:CreateElement("cbc:PriceAmount", ntrim(dbOrder:FRACHT,2));       	// BT-146
				:addAttribute("currencyID", "EUR" )))
	endif

	ferase(cXRechnung)
	hHandle	:= fcreate(cXRechnung)
	fwrite(hHandle, '<?xml version="1.0" encoding="UTF-8"?>' +CRLF+ Char2UTF8(oRoot:toXml()))
	fclose(hHandle)

	set( _SET_DATEFORMAT	, cDate )

RETURN cXRechnung


