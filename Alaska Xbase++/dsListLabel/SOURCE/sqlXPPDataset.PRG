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
	LOCAL oDataSet1 			// Clientes
	LOCAL oDataSet2         // articles
	LOCAL oListLabel
	LOCAL nError
	LOCAL aFieldlist


	// DEMO CODE starts here
   // define SqlDataSet
	oDataSet1 := SqlDataSet():New()

	oDataSet1:AddColumn( "codigo"   , { ||  0 } )
	oDataSet1:AddColumn( "nombre"   , { || "" } )
	oDataSet1:AddColumn( "direccion", { || "" } )
	oDataSet1:AddColumn( "telefono" , { || "" } )
	oDataSet1:AddColumn( "cod_pos"  , { ||  0 } )
	oDataSet1:AddColumn( "saldo"    , { ||  0 } )
	oDataSet1:AddColumn( "importe"  , { ||  0 } )

	aFieldlist	:= {;
		{"codigo"   , "N", 10,0 },;
		{"nombre"   , "C", 20,0 },;
		{"direccion", "C", 20,0 },;
		{"telefono" , "C", 20,0 },;
		{"cod_pos"  , "N", 10,0 },;
		{"saldo"    , "N", 10,0 },;
		{"importe"  , "N", 10,0 }}


	oDataSet1:Append()
	oDataSet1:RecordPut( { 1, "Martín Compañia" , "Pelegrini 1234", "12345678" , 2000, 185225.56, 680.00 } )
	oDataSet1:Append()
	oDataSet1:RecordPut( { 2, "Ernesto", "Mendoza 1234"  , "654321", 2000, 87562.25, 540.00 } )
	oDataSet1:Append()
	oDataSet1:RecordPut( { 3, "Pepe", "Tupungato 145"  , "64321", 2000, 6762.25, 250.00 } )
	oDataSet1:Append()
	oDataSet1:RecordPut( { 4, "Silvio", "Segui 14"  , "4568925", 2000, 7562.25, 150.00 } )


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


	oListLabel:connect( oDataSet1, "Clientes" )
	oListLabel:DataSetField( oDataSet1,"Clientes",,aFieldlist )


	oDataSet2 := SqlDataSet():New()

	oDataSet2:AddColumn( "article"  , { ||  0 } )
	oDataSet2:AddColumn( "nombre"   , { || "" } )
	oDataSet2:AddColumn( "amount"   , { || 0 } )
	oDataSet2:AddColumn( "price" 	  , { || 0 } )

	aFieldlist	:= {;
		{"article"   , "N", 10,0 },;
		{"nombre"   , "C", 20,0 },;
		{"amount"  , "N", 10,0 },;
		{"price"  , "N", 10,0 }}


	oDataSet2:Append()
	oDataSet2:RecordPut( { 1, "Coffee" , 111, 12.80 } )
	oDataSet2:Append()
	oDataSet2:RecordPut( { 1, "Tea" , 222, 5.80 } )
	oDataSet2:Append()
	oDataSet2:RecordPut( { 1, "Whiskey" , 333, 22.80 } )
	oDataSet2:Append()
	oDataSet2:RecordPut( { 1, "Rum" , 444, 32.80 } )

	oListLabel:DataSetField( oDataSet2,"Articles",,aFieldlist )


	oListLabel:DefineVariable("Empresa", "Martin Y Martin", LL_TEXT)

	// D: Dateiauswahldialog oeffnen
	// US: Call file open dialog
	oListLabel:SetProperty(, LL_PROJECT_LIST, "Select File" )

	// AddTable() initializes report container
	oListLabel	:AddTable("Clientes")         		// same name as oListLabel:DataSetField( oDataSet1,"Clientes",,aFieldlist )
	oListLabel	:AddTable("Articles")					// same name as oListLabel:DataSetField( oDataSet1,"Articles",,aFieldlist )

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
   oDataSet1:destroy()
   oDataSet2:destroy()
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


