Imports System.Collections.Generic
Imports System.Text
Imports combit.ListLabel25.DataProviders
Imports System.IO

' US:  This sample class implements a simple data provider for CSV files (comma separated values).
'      It can be used as template for custom IDataProvider implementations. In order to keep the
'      code as clear as possible, minimal error checking is done.
'  D:  Diese Beispiel-Klasse implementiert einen einfachen Data Provider für CSV-Dateien (kommaseparierte Werte).
'      Es kann als Vorlage fuer eigene IDataProvider-Implementierungen dienen. 
'      Um den Code so uebersichtlich wie moeglich zu halten, erfolgte eine minimale Fehlerpruefung.

Public Class CsvDataProvider
	Implements IDataProvider
	Private _fileName As String
	Public Sub New(fileName As String)
		_fileName = fileName
	End Sub

	#Region "IDataProvider Members"

	Public ReadOnly Property SupportsAnyBaseTable() As Boolean Implements IDataProvider.SupportsAnyBaseTable
		Get
			' US:  this provider just has one table
			'  D:  Dieser Provider hat lediglich eine Tabelle
			Return True
		End Get
	End Property

	Private _tables As List(Of ITable)
	Public ReadOnly Property Tables() As System.Collections.ObjectModel.ReadOnlyCollection(Of ITable) Implements IDataProvider.Tables
		Get
			If _tables Is Nothing Then
				_tables = New List(Of ITable)()

				' US:  build a "list" of tables - for csv there is just one               
				'  D:  Erstellt eine "Liste" von Tabellen - fuer CSV ist es lediglich eine 
				_tables.Add(New CsvTable(_fileName))
			End If
			Return _tables.AsReadOnly()
		End Get
	End Property

	Public ReadOnly Property Relations() As System.Collections.ObjectModel.ReadOnlyCollection(Of ITableRelation) Implements IDataProvider.Relations
		Get
			' US:  this provider just has one table
			'  D:  Dieser Provider hat lediglich eine Tabelle
			Return Nothing
		End Get
	End Property

	Public Function GetTable(tableName As String) As ITable Implements IDataProvider.GetTable
		' US:  Iterate through available tables to find the required one.
		'      As this provider has just one, return Tables[0] would also
		'      do.
		'  D:  Durchlaeuft die verfuegbaren Tabellen, um die erforderliche 
		'      Tabelle zu finden. Wenn der Provider lediglich eine Tabelle 
		'      besitzt, wuerde auch Tables[0] ausreichen.
		For Each table As ITable In Tables
			If table.TableName = tableName Then
				Return table
			End If
		Next

		'''/ US:  should not happen - table not found
		'''/  D:  Sollte nicht passieren - Tabelle nicht gefunden
		'throw new ArgumentException("Unknown table name", "tableName");
		Return Nothing
	End Function

	Public Function GetRelation(relationName As String) As ITableRelation Implements IDataProvider.GetRelation
		' US:  this provider just has one table
		'  D:  Dieser Provider hat lediglich eine Tabelle
		'throw new NotImplementedException();
		Return Nothing

	End Function
	#End Region
End Class

' US:  The table class also supports the IEnumerable interface for ITableRow
'  D:  Die Klasse Table unterstuetzt die IEnumerable Schnittstelle fuer ITableRow
Public Class CsvTable
	Implements ITable
	Implements IEnumerable(Of ITableRow)
	Private _fileName As String
	Public Sub New(fileName As String)
		' US:  If the file doesn't exist exit
		'  D:  Wenn die Datei nicht existiert
		If Not File.Exists(fileName) Then
			Throw New FileNotFoundException("File not found", fileName)
		End If
		_fileName = fileName
	End Sub

	#Region "ITable Members"

	Public ReadOnly Property SupportsCount() As Boolean Implements ITable.SupportsCount
		Get
			' US:  Count is supported
			'  D:  Zaehler wird unterstuetzt
			Return True
		End Get
	End Property

	Public ReadOnly Property SupportsSorting() As Boolean Implements ITable.SupportsSorting
		Get
			' US:  Sorting is not supported
			'  D:  Sortierung wird nicht unterstuetzt
			Return False
		End Get
	End Property

	Public ReadOnly Property SupportsAdvancedSorting() As Boolean Implements ITable.SupportsAdvancedSorting
		Get
			' US:  Sorting is not supported
			'  D:  Sortierung wird nicht unterstuetzt
			Return False
		End Get
	End Property



	Public ReadOnly Property SupportsFiltering() As Boolean Implements ITable.SupportsFiltering
		Get
			' US:  Filtering is not supported
			'  D:  Filter wird nicht unterstuetzt
			Return False
		End Get
	End Property

	Public Sub ApplySort(sortDescription As String) Implements ITable.ApplySort
		Throw New NotImplementedException()
	End Sub

	Public Sub ApplyFilter(filter As String) Implements ITable.ApplyFilter
		' US:  You would receive something like KeyField=KeyValue here and
		'      would have to filter the data accordingly.
		'  D:  Hier wuerden Sie etwas wie KeyField=KeyValue erhalten und 
		'      muessten die Daten danach filtern.
		Throw New NotImplementedException()
	End Sub

	Private _count As Integer = -1
	Public ReadOnly Property Count() As Integer Implements ITable.Count
		Get
			' US:  Has been cached before
			'  D:  Wurde zuvor zwischengespeichert
			If _count <> -1 Then
				Return _count
			End If

			' US:  Iterate the file. As the first line by definition
			'      contains the column headers, starting with -1 yields
			'      the correct result.
			'  D:  Iteration der Datei. Da die erste Zeile die Spaltenueberschrift beinhaltet,
			'      begintt der Zaehler mit -1.
			Using sr As New StreamReader(_fileName)
				While sr.ReadLine() IsNot Nothing
					_count += 1
				End While
			End Using
			Return _count
		End Get
	End Property

	Public ReadOnly Property TableName() As String Implements ITable.TableName
		Get
			' US:  Choose any name you like here
			'  D:  Waehlen Sie hier einen beliebigen Namen
			Return Path.GetFileNameWithoutExtension(_fileName)
		End Get
	End Property

	Public ReadOnly Property Rows() As IEnumerable(Of ITableRow) Implements ITable.Rows
		Get
			Return TryCast(Me, IEnumerable(Of ITableRow))
		End Get
	End Property

	Public ReadOnly Property SortDescriptions() As System.Collections.ObjectModel.ReadOnlyCollection(Of String) Implements ITable.SortDescriptions
		' US:  Sorting is not supported
		'  D:  Sortierung wird nicht unterstuetzt
		Get
			Throw New NotImplementedException()
		End Get
	End Property

	Public ReadOnly Property SchemaRow() As ITableRow Implements ITable.SchemaRow
		' US:  SchemaRow is not supported, will not be called anyway. This function is only called if
		'      the enumerator doesn't return any data rows.
		'  D:  SchemaRow wird nicht unterstuetzt, da es nicht benoetigt wird. Diese Funktion wird
		'      nur aufgerufen, wenn der Enumarator nicht zumindest eine Datenzeile liefert.
		Get
			Throw New NotImplementedException()
		End Get
	End Property

	#End Region

	#Region "IEnumerable<ITableRow> Members"

	Public Function GetEnumerator() As IEnumerator(Of ITableRow) Implements IEnumerable(Of ITableRow).GetEnumerator
		Return New CsvTableRowEnumerator(TableName, _fileName)
	End Function

	#End Region

	#Region "IEnumerable Members"

	Private Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
		Return New CsvTableRowEnumerator(TableName, _fileName)
	End Function

	#End Region

End Class

' US:  Enumerator class for the table rows. This class does the actual work of
'      iterating through the data.
'  D:  Die Klasse Enumerator ist zustaendig fuer die Tabellenzeilen. Diese Klasse nimmt die
'      eigentliche Arbeit der Iteration durch die Daten vor.
Public Class CsvTableRowEnumerator
	Implements IEnumerator(Of ITableRow)
	Private _streamReader As StreamReader
	Private _tableName As String, _headerLine As String, _currentLine As String
	Public Sub New(tableName As String, fileName As String)
		_tableName = tableName

		' US:  Initialize StreamReader to access file
		'  D:  Initialisiert SreamReader fuer den Zugriff auf die Datei
		_streamReader = New StreamReader(fileName)

		' US:  Read first line as header
		'  D:  Liest die erste Zeile als Header
		_headerLine = _streamReader.ReadLine()
	End Sub
	#Region "IEnumerator<ITableRow> Members"

	Public ReadOnly Property Current() As ITableRow Implements IEnumerator(Of ITableRow).Current
		Get
			' US:  _currentLine will contain the right data here
			'  D:  _currentLine beinhaltet die richtigen Daten
			Return New CsvTableRow(_tableName, _headerLine, _currentLine)
		End Get
	End Property

	#End Region

	#Region "IDisposable Members"

	Public Sub Dispose() Implements IDisposable.Dispose
		' US:  Clean up resources
		'  D:  Aufraeumen der Resourcen
		_streamReader.Close()
		_streamReader.Dispose()
	End Sub

	#End Region

	#Region "IEnumerator Members"

	Private ReadOnly Property System_Collections_IEnumerator_Current() As Object Implements System.Collections.IEnumerator.Current
		Get
			Return New CsvTableRow(_tableName, _headerLine, _currentLine)
		End Get
	End Property

	Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
		' US:  Read next line
		'  D:  Auslesen der naechsten Zeile
		_currentLine = _streamReader.ReadLine()

		' US:  Check for end of file
		'  D:  Abpruefen des Zeilenendes
		Return (_currentLine IsNot Nothing)
	End Function

	Public Sub Reset() Implements System.Collections.IEnumerator.Reset
		' US:  Will not be called anyway
		'  D:  Wird nicht aufgerufen
		Throw New NotImplementedException()
	End Sub

	#End Region
End Class

' US:  This class represents a single table row
'  D:  Diese Klasse repraesentiert eine einzelne Tabellenzeile
Public Class CsvTableRow
	Implements ITableRow
	Private _tableName As String, _headerRow As String, _tableRow As String
	Public Sub New(tableName As String, headerRow As String, tableRow As String)
		_tableName = tableName
		_headerRow = headerRow
		_tableRow = tableRow
	End Sub

	#Region "ITableRow Members"

	Public ReadOnly Property SupportsGetParentRow() As Boolean Implements ITableRow.SupportsGetParentRow
		Get
			' US:  No support for reverse 1:1 relations
			'  D:  Keine Unterstuetzung fuer umgekehrte 1:1 Relationen
			Return False
		End Get
	End Property

	Public ReadOnly Property TableName() As String Implements ITableRow.TableName
		Get
			Return _tableName
		End Get
	End Property

	Public ReadOnly Property Columns() As System.Collections.ObjectModel.ReadOnlyCollection(Of ITableColumn) Implements ITableRow.Columns
		Get
			' US:  Build up the column list by splitting the input. This of course is overly simplified
			'      without any error checking, escaping of "," in the contents, type conversions
			'      etc.
			'  D:  Erstellt aus dem Eingabeparameter eine Spaltenliste. Diese Routine ist sehr 
			'      vereinfacht ohne jegliche Fehlerpruefung, keine "," in den Inhalten, Typen-Wandlung
			'      etc.
			Dim columns__1 As New List(Of ITableColumn)()
			Dim columnNames As String() = _headerRow.Split(","C)
			Dim columnValues As String() = _tableRow.Split(","C)

			For colNo As Integer = 0 To columnNames.GetUpperBound(0)
				Dim columnValue As Double

				' US: Very basic type detection
				' D:  Stark vereinfachte Typenerkennung
				If [Double].TryParse(columnValues(colNo), columnValue) Then
					columns__1.Add(New CsvTableColumn(columnNames(colNo), GetType(Double), columnValue))
				Else
					columns__1.Add(New CsvTableColumn(columnNames(colNo), GetType(String), columnValues(colNo)))
				End If
			Next

			Return columns__1.AsReadOnly()
		End Get
	End Property

	Public Function GetChildTable(relation As ITableRelation) As ITable Implements ITableRow.GetChildTable
		' US:  We do not support relations, otherwise we would have to return the child table here
		'  D:  Wir unterstuetzen keine Relationen, sonst wuerden wir hier die Child-Tabelle zurueck-
		'      liefern
		Throw New NotImplementedException()
	End Function

	Public Function GetParentRow(relation As ITableRelation) As ITableRow Implements ITableRow.GetParentRow
		' US:  We do not support relations, otherwise we would have to return the parent row here
		'      if reverse 1:1 relations should be supported.
		'  D:  Wir unterstuetzen keine Relationen, sonst muessten wir hier die Parent-Zeile zurueck-
		'      liefern, wenn wir umgekehrte 1:1 Relationen unterstuetzen wuerden.
		Throw New NotImplementedException()
	End Function
	#End Region
End Class

' US:  Trivial column class
'  D:  Triviale Spalten-Klasse
Public Class CsvTableColumn
	Implements ITableColumn
	#Region "ITableColumn Members"
	Private _columnName As String
	Private _dataType As Type
	Private _content As Object
	Public Sub New(columnName As String, dataType As Type, content As Object)
		_columnName = columnName
		_dataType = dataType
		_content = content
	End Sub
	Public ReadOnly Property ColumnName() As String Implements ITableColumn.ColumnName
		Get
			Return _columnName
		End Get
	End Property

	Public ReadOnly Property DataType() As Type Implements ITableColumn.DataType
		Get
			Return _dataType
		End Get
	End Property

	Public ReadOnly Property Content() As Object Implements ITableColumn.Content
		Get
			Return _content
		End Get
	End Property

	Public ReadOnly Property FieldType() As LlFieldType Implements ITableColumn.FieldType
		Get
			Return LlFieldType.Unknown
		End Get
	End Property
	#End Region
End Class



