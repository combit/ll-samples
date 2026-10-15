using System;
using System.Collections.Generic;
using System.Text;
using combit.Reporting.DataProviders;
using System.IO;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace combit.Reporting.Samples
{
    // US:  This sample class implements a simple data provider for CSV files (comma separated values).
    //      It can be used as template for custom IDataProvider implementations. In order to keep the
    //      code as clear as possible, minimal error checking is done.
    //  D:  Diese Beispiel-Klasse implementiert einen einfachen Data Provider für CSV-Dateien (kommaseparierte Werte).
    //      Es kann als Vorlage fuer eigene IDataProvider-Implementierungen dienen. 
    //      Um den Code so uebersichtlich wie moeglich zu halten, erfolgte eine minimale Fehlerpruefung.

    public class CsvDataProvider : IDataProvider, IDisposable, ISerializable
    { 
        #region Fields

        private string _tableName;
        private bool _supportsCount;
        private bool _initialized;
        private bool _firstLineIsHeader;
        private char _separator;
        private char _framingCharacter;
        private int _linesToSkip;
        private List<ITable> _tables = new List<ITable>(1);
        private Stream _csvStream;

        #endregion

        #region Properties

        internal string SeparatorString { get; set; }
        internal List<string> ColumnNames { get; private set; }
        internal bool DisposeStream { get; private set; }
        public string FileName { get; private set; }
        public Encoding ContentEncoding { get; set; }

        [DefaultValue(true)]
        public bool FirstLineIsHeader
        {
            get { return _firstLineIsHeader; }
            set
            {
                ThrowExceptionIfInitialized();
                _firstLineIsHeader = value;
            }
        }

        public string TableName
        {
            get { return _tableName; }
            set
            {
                ThrowExceptionIfInitialized();
                _tableName = value;
            }
        }

        public char Separator
        {
            get { return _separator; }
            set
            {
                ThrowExceptionIfInitialized();
                _separator = value;
            }
        }

        public int LinesToSkip
        {
            get { return _linesToSkip; }
            set
            {
                ThrowExceptionIfInitialized();
                _linesToSkip = value;
            }
        }

        public bool SupportsCount
        {
            get { return _supportsCount; }
            set
            {
                ThrowExceptionIfInitialized();
                _supportsCount = value;
            }
        }

        public char FramingCharacter
        {
            get { return _framingCharacter; }
            set
            {
                ThrowExceptionIfInitialized();
                _framingCharacter = value;
            }
        }

        #endregion

        #region Constructor

        public CsvDataProvider(string fileName)
            : this(fileName, true) { }

        public CsvDataProvider(string fileName, bool firstLineIsHeader)
            : this(fileName, firstLineIsHeader, "") { }

        public CsvDataProvider(string fileName, bool firstLineIsHeader, string tableName)
            : this(fileName, firstLineIsHeader, tableName, ',') { }

        public CsvDataProvider(string fileName, bool firstLineIsHeader, string tableName, char separator)
            : this(fileName, firstLineIsHeader, tableName, separator, 0) { }

        public CsvDataProvider(string fileName, bool firstLineIsHeader, string tableName, char separator, int linesToSkip)
            : this(fileName, firstLineIsHeader, tableName, separator, linesToSkip, true) { }

        public CsvDataProvider(string fileName, bool firstLineIsHeader, string tableName, char separator, int linesToSkip, bool supportsCount)
            : this(File.OpenRead(fileName), firstLineIsHeader, tableName, separator, linesToSkip, supportsCount)
        {
            FileName = fileName;
            DisposeStream = true;
        }

        public CsvDataProvider(Stream stream, bool firstLineIsHeader, string tableName, char separator, int linesToSkip, bool supportsCount)
        {
            _csvStream = stream;
            FirstLineIsHeader = firstLineIsHeader;
            TableName = tableName;
            Separator = separator;
            LinesToSkip = Math.Max(linesToSkip, 0);
            SupportsCount = supportsCount;
            FramingCharacter = Convert.ToChar(0x0);  // null character
            ContentEncoding = Encoding.Default;
        }

        private CsvDataProvider(SerializationInfo info, StreamingContext context)
        {
            int version = info.GetInt32("CsvDataProvider.Version");
            if (version >= 1)
            {
                FileName = info.GetString("CsvDataProvider.FileName");
                DisposeStream = true;
                _csvStream = File.OpenRead(FileName);
                FirstLineIsHeader = info.GetBoolean("CsvDataProvider.FirstLineIsHeader");
                TableName = info.GetString("CsvDataProvider.TableName");
                Separator = info.GetChar("CsvDataProvider.Separator");
                LinesToSkip = info.GetInt32("CsvDataProvider.LinesToSkip");
                FramingCharacter = info.GetChar("CsvDataProvider.FramingCharacter");
                ContentEncoding = Encoding.GetEncoding(info.GetString("CsvDataProvider.ContentEncoding"));
            }
        }

        #endregion

        #region Methods

        private void ThrowExceptionIfInitialized()
        {
            if (_initialized)
                throw new ArgumentException("Please set parameters at an earlier stage.");
        }

        private void Init()
        {
            if (_initialized)
                return;

            if (String.IsNullOrEmpty(TableName))
            {
                if (String.IsNullOrEmpty(FileName))
                {
                    TableName = "CsvTable";
                }
                else
                {
                    TableName = Path.GetFileNameWithoutExtension(FileName);
                }
            }

            if (!_csvStream.CanSeek)
            {
                //we have to create a new one which is seekable
                DisposeStream = true;

                //try to save the original position
                long currentPos = 0;
                try
                {
                    currentPos = _csvStream.Position;
                }
                catch (NotSupportedException) { }

                MemoryStream ms = new MemoryStream();
                byte[] buffer = new byte[32768];
                int read;
                while ((read = _csvStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                _csvStream = ms;
                _csvStream.Position = currentPos;
            }

            if (_csvStream.Length > 0)
            {
                StreamReader reader = new StreamReader(_csvStream, ContentEncoding);
                // lines to skip
                for (int skip = LinesToSkip; skip > 0; skip--)
                    reader.ReadLine();

                // read header
                string line = reader.ReadLine();
                List<string> linesplit = CustomizeSplit(line);

                if (FirstLineIsHeader)
                {
                    ColumnNames = new List<string>(linesplit);
                }
                else
                {
                    ColumnNames = new List<string>(linesplit);
                    for (int i = 1; i <= linesplit.Count; i++)
                        ColumnNames.Add(string.Format("col{0:d}", i));
                }
                // only one table supported
                _tables.Add(new CsvTable(this));
            }

            _initialized = true;
        }

        internal List<string> CustomizeSplit(string currLine)
        {
            if (FramingCharacter == '\0')
            {
                SeparatorString = Separator.ToString();
                return new List<string>(currLine.Split(new string[] { SeparatorString }, StringSplitOptions.None));
            }

            bool colStarted = false;
            bool separatorPassed = true;
            StringBuilder column = new StringBuilder();
            List<string> columns = new List<string>();
            for (int currPos = 0; currPos < currLine.Length; currPos++)
            {
                if (separatorPassed && colStarted)
                {
                    if (currLine[currPos] == FramingCharacter)
                    {
                        if (currPos == currLine.Length - 1 || currLine[currPos + 1] != FramingCharacter)
                        {
                            columns.Add(column.ToString());
                            column = new StringBuilder();
                            colStarted = false;
                            separatorPassed = false;
                        }
                        else
                        {
                            column.Append(currLine[currPos]);
                            currPos++;
                        }
                    }
                    else
                        column.Append(currLine[currPos]);
                }
                else
                {
                    if (currLine[currPos] == FramingCharacter)
                    {
                        colStarted = true;
                    }
                    else if (currLine[currPos] == Separator)
                    {
                        separatorPassed = true;
                    }
                }
            }
            return columns;
        }

        internal StreamReader GetStreamReaderOnDataPosition()
        {
            _csvStream.Position = 0;
            StreamReader reader = new StreamReader(_csvStream, ContentEncoding);
            // lines to skip
            for (int skip = LinesToSkip; skip > 0; skip--)
                reader.ReadLine();

            if (FirstLineIsHeader)
                reader.ReadLine();

            return reader;
        }

        #endregion

        #region IDataProvider Members

        public bool SupportsAnyBaseTable
        {
            get
            {
                // US:  this provider just has one table
                //  D:  Dieser Provider hat lediglich eine Tabelle
                return false;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<ITable> Tables
        {
            get
            {
                Init();
                return _tables.AsReadOnly();
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<ITableRelation> Relations
        {
            get
            {
                // US:  this provider just has one table
                //  D:  Dieser Provider hat lediglich eine Tabelle
                return null;
            }
        }

        public ITable GetTable(string tableName)
        {
            // US:  Iterate through available tables to find the required one.
            //      As this provider has just one, return Tables[0] would also
            //      do.
            //  D:  Durchlaeuft die verfuegbaren Tabellen, um die erforderliche 
            //      Tabelle zu finden. Wenn der Provider lediglich eine Tabelle 
            //      besitzt, wuerde auch Tables[0] ausreichen.
            //foreach (ITable table in Tables)
            //{
            //    if (table.TableName == tableName)
            //        return table;
            //}

            Init();

            if (tableName == TableName && _tables.Count > 0)
                return _tables[0];

            //// US:  should not happen - table not found
            ////  D:  Sollte nicht passieren - Tabelle nicht gefunden
            //throw new ArgumentException("Unknown table name", "tableName");
            return null;
        }

        public ITableRelation GetRelation(string relationName)
        {
            // US:  this provider just has one table
            //  D:  Dieser Provider hat lediglich eine Tabelle
            //throw new NotImplementedException();
            return null;

        }
        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (String.IsNullOrEmpty(FileName))
                throw new InvalidOperationException("CsvDataProvider cannot be serialized if it was initialized with a file stream.");

            info.AddValue("CsvDataProvider.Version", 1);
            info.AddValue("CsvDataProvider.FileName", FileName);
            info.AddValue("CsvDataProvider.FirstLineIsHeader", FirstLineIsHeader);
            info.AddValue("CsvDataProvider.TableName", TableName);
            info.AddValue("CsvDataProvider.Separator", Separator);
            info.AddValue("CsvDataProvider.LinesToSkip", LinesToSkip);
            info.AddValue("CsvDataProvider.FramingCharacter", FramingCharacter);
            info.AddValue("CsvDataProvider.ContentEncoding", ContentEncoding.WebName);
        }

        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~CsvDataProvider()
        {
            Dispose(false);
        }

        private bool disposed;
        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && DisposeStream)
                {
                    _csvStream.Dispose();
                }
                disposed = true;
            }
        }

        #endregion

    }

    // US:  The table class also supports the IEnumerable interface for ITableRow
    //  D:  Die Klasse Table unterstuetzt die IEnumerable Schnittstelle fuer ITableRow
    public class CsvTable : ITable
    {
        private CsvDataProvider _provider;
        private int _count = -1;

        public CsvTable(CsvDataProvider provider)
        {
            _provider = provider;
        }

        #region ITable Members

        public bool SupportsCount
        {
            get
            {
                // US:  User can set count support in provider
                //  D:  Benutzer darf Zaehler unterstuetzung in Data Provider setzen
                return _provider.SupportsCount;
            }
        }

        public bool SupportsSorting
        {
            get
            {
                // US:  Sorting is not supported
                //  D:  Sortierung wird nicht unterstuetzt
                return false;
            }
        }

        public bool SupportsAdvancedSorting
        {
            get
            {
                // US:  Sorting is not supported
                //  D:  Sortierung wird nicht unterstuetzt
                return false;
            }

        }


        public bool SupportsFiltering
        {
            get
            {
                // US:  Filtering is not supported
                //  D:  Filter wird nicht unterstuetzt
                return false;
            }
        }

        public void ApplySort(string sortDescription)
        {
            throw new NotImplementedException();
        }

        public void ApplyFilter(string filter)
        {
            // US:  You would receive something like KeyField=KeyValue here and
            //      would have to filter the data accordingly.
            //  D:  Hier wuerden Sie etwas wie KeyField=KeyValue erhalten und 
            //      muessten die Daten danach filtern.
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                // US:  Has been cached before
                //  D:  Wurde zuvor zwischengespeichert
                if (_count != -1)
                    return _count;

                // US:  Iterate the file. As the first line by definition
                //      contains the column headers, starting with -1 yields
                //      the correct result.
                //  D:  Iteration der Datei. Da die erste Zeile die Spaltenueberschrift beinhaltet,
                //      begintt der Zaehler mit -1.
                _count = 0;
                StreamReader reader = _provider.GetStreamReaderOnDataPosition();
                while (reader.ReadLine() != null)
                {
                    _count++;
                }
                return _count;
            }
        }

        public string TableName
        {
            get
            {
                // US:  Choose any name you like here
                //  D:  Waehlen Sie hier einen beliebigen Namen
                return _provider.TableName;
            }
        }

        public IEnumerable<ITableRow> Rows
        {
            get
            {
                StreamReader reader = _provider.GetStreamReaderOnDataPosition();
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))  // skip empty lines
                        continue;

                    List<string> curLineSplit = _provider.CustomizeSplit(line);
                    yield return new CsvTableRow(_provider, curLineSplit);
                }
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<string> SortDescriptions
        {
            // US:  Sorting is not supported
            //  D:  Sortierung wird nicht unterstuetzt
            get { throw new NotImplementedException(); }
        }

        public ITableRow SchemaRow
        {
            // US:  SchemaRow is not supported, will not be called anyway. This function is only called if
            //      the enumerator doesn't return any data rows.
            //  D:  SchemaRow wird nicht unterstuetzt, da es nicht benoetigt wird. Diese Funktion wird
            //      nur aufgerufen, wenn der Enumarator nicht zumindest eine Datenzeile liefert.
            get { throw new NotImplementedException(); }
        }

        #endregion
    }

    // US:  This class represents a single table row
    //  D:  Diese Klasse repraesentiert eine einzelne Tabellenzeile
    public class CsvTableRow : ITableRow
    {
        public CsvTableRow(CsvDataProvider provider, List<string> columns)
        {
            TableName = provider.TableName;
            List<ITableColumn> tableColumns = new List<ITableColumn>(columns.Count);

            int i = 0;
            foreach (string col in columns)
            {
                if (i < provider.ColumnNames.Count)
                {
                    tableColumns.Add(new CsvTableColumn(provider.ColumnNames[i], typeof(string), col));
                    ++i;
                }
                else
                    break;
            }

            Columns = tableColumns.AsReadOnly();
        }

        #region ITableRow Members

        public bool SupportsGetParentRow
        {
            get
            {
                // US:  No support for reverse 1:1 relations
                //  D:  Keine Unterstuetzung fuer umgekehrte 1:1 Relationen
                return false;
            }
        }

        public string TableName
        {
            get;
            private set;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<ITableColumn> Columns
        {
            get;
            private set;
        }

        public ITable GetChildTable(ITableRelation relation)
        {
            // US:  We do not support relations, otherwise we would have to return the child table here
            //  D:  Wir unterstuetzen keine Relationen, sonst wuerden wir hier die Child-Tabelle zurueck-
            //      liefern
            throw new NotImplementedException();
        }

        public ITableRow GetParentRow(ITableRelation relation)
        {
            // US:  We do not support relations, otherwise we would have to return the parent row here
            //      if reverse 1:1 relations should be supported.
            //  D:  Wir unterstuetzen keine Relationen, sonst muessten wir hier die Parent-Zeile zurueck-
            //      liefern, wenn wir umgekehrte 1:1 Relationen unterstuetzen wuerden.
            throw new NotImplementedException();
        }
        #endregion
    }

    // US:  Trivial column class
    //  D:  Triviale Spalten-Klasse
    public class CsvTableColumn : ITableColumn
    {
        public CsvTableColumn(string columnName, Type dataType, object content)
        {
            ColumnName = columnName;
            DataType = dataType;
            Content = content;
            FieldType = LlFieldType.Text;
        }

        #region ITableColumn Members

        public string ColumnName
        {
            get;
            private set;
        }

        public Type DataType
        {
            get;
            private set;
        }

        public object Content
        {
            get;
            private set;
        }

        public LlFieldType FieldType
        {
            get;
            private set;
        }

        #endregion
    }
}
