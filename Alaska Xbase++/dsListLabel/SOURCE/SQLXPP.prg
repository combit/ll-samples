///////////////////////////////////////////////////////////////////////////////
//
//  SQLXPP.PRG
//
//  Copyright (c) 2000-2020, Xb2.NET inc.
//  All rights reserved.
//
//  Author:   Boris Borzic
//  Email:    support@sqlexpress.net
//  Web:      http://sqlexpress.net
//
//  SQLExpress demo program showing how to create an TBrowse object
//  to browse SQL/ODBC tables.
//
///////////////////////////////////////////////////////////////////////////////

#include "lldemo.ch"

#include "sql.ch"
#include "sqlext.ch"


FUNCTION SQLExpressKey(); Return NIL   // <-- put your SQLExpress license key here (replace NIL with your key)



#ifdef __SQL_SERVER__

  // if you have Microsoft SQL Server installed on your machine you can use
  // these defines to connect to the sample "Northwind" database
  //
  // * Note *
  // The supplied connection string is only a sample. You will likely need to
  // modify this connection string in order to connect to the SQLServer.

  #define __CONNECT_STRING  'DRIVER=SQL Server;SERVER=(local);UID=sa;PWD=;DATABASE=Northwind'
  #define __STATEMENT       'SELECT * FROM Orders ORDER BY CustomerID'

#else

  // this will connect to our MS Access TEST.MDB database:
  #define __CONNECT_STRING  'DBQ=data\test.mdb;Driver={Microsoft Access Driver (*.mdb)};UID=admin;'
  #define __STATEMENT       'SELECT * FROM [customer],[orders] '+;
                            'WHERE [orders].[customer id]=[customer].[customer id] '+;
                            'ORDER BY [customer name]'
#endif


//-----------------------------------------------------------------------------
FUNC sqlxpp(nPrintingTarget, lDesignDocument, cFolder)
   Local oConn, oCursor
	LOCAL oListLabel
	LOCAL nError
	LOCAL aFieldlist


	// DEMO CODE starts here
   // establish the ODBC connection
   oConn := SQLConnection():new()
   oConn:driverConnect(nil, __CONNECT_STRING)

   if ! oConn:isConnected
      MsgBox("Connection error!")
      Return NIL
   endif

   oCursor  := SQLSelect():new(__STATEMENT, oConn, SQL_CONCUR_READ_ONLY)
   oCursor:DateTimeAsDate := .t.
   oCursor:Execute()

	// D: Wichtig: hier Feldliste mit fieldwblock erzeugen
	// US: important, create a fieldlist with fieldwblock
	aFieldlist	:= GetSqlXppFieldList(oCursor)



	// D: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, siehe LlPrintWithBoxStart
	// US: LL_PRINT_NORMAL, LL_PRINT_FILE,LL_PRINT_EXPORT, see LlPrintWithBoxStart
	DEFAULT nPrintingTarget TO LL_PRINT_PREVIEW

	// D: .t. - Druck/Export; .f. - Design
	// US: .t. - print/export; .f. - design document
	DEFAULT lDesignDocument  TO .f.

	// DEMO CODE starts here
	// D: Datenbank sollte bei Applikation liegen...
	//    eine Tabelle mit Xbase++ DBE öffnen und die Workarea in einem Klasseobjekt kapseln (hier XClass++)
	// US: Database should be with application exe...
	//    open a table via Xbase++ DBE and wrap workarea in a class object (using XClass++)

	// D: Klasse initialisieren
	// US:class init
	oListLabel	:= dsListLabel():New(SetAppWindow())
	oListLabel	:AddPath(cFolder)

	// D: aktuelle Workarea anmelden
	// US:register active workarea
	oListLabel:connect(oCursor, "SQLXPP")

	// D: alle Felder der aktuellen Workarea für LLDefineVariable anmelden
	// US:register all columns of active workarea for LLDefineVariable
	oListLabel:DataSetField(oCursor,"SQLxpp",,aFieldlist)                            // SQLXPP pass fieldlist !!!!!

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	if lDesignDocument
		// D: Designer starten
		// US: start designer
		oListLabel:design()
	else
		// D: Preview, Druck oder Export ausführen
		// US: execute preview, print or export
		oListLabel:PrintOption(nPrintingTarget)
		nError	:= oListLabel:print()
		if nError <> 0
			Msgbox(oListLabel:GetLastMessage(), "Error: "+ var2char(oListLabel:GetLastError()))
		endif
	endif
	// D:  aufräumen
	// US: clean up
	oListLabel:destroy()

	// D:  Destroy Objekt, Datei schliessen
	// US: Destroy object, close table
   oConn:destroy()
RETURN NIL


//=========================================
// D: create array { symbolname, fieldwblock() } for each field
// US: create array { symbolname, fieldwblock() } for each field
FUNCTION GetSqlXppFieldList(oCursor)
	LOCAL aFieldList	:= {}
	LOCAL oSqlColumn
	LOCAL i, iCnt

	iCnt	:= oCursor:FCount
   for i := 1 to iCnt
      oSQLColumn := oCursor:GetSQLColumn(i)
		// D: keine Leerstellen in Symbolnamen
		// US: blanks are not allowed in symbols
      aadd( aFieldList, { strtran(oSQLColumn:Name, " "), SQLFieldBlock(oCursor, i)})
   next
	oSqlColumn	:= NIL

RETURN aFieldlist

//-----------------------------------------------------------------------------
FUNCTION SQLFieldBlock( oCursor, nField )	;Return {|x| oCursor:FieldGet(nField) }


