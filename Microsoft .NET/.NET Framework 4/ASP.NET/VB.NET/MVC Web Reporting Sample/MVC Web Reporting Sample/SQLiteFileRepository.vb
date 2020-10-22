Imports combit.Reporting.Repository
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SQLite
Imports System.IO
Imports System.Linq
Imports System.Threading
Imports System.Web
Imports System.Runtime.CompilerServices

Namespace WebReporting

    ''' <summary>
    ''' DE: Beispiel-Implementierung eines Repositories für ListLabel, das die Dateien mit Hilfe einer SQLite-Datenbankdatei verwaltet.
    '''     Details sind der Dokumentation für das IRepository-Interface zu entnehmen.
    '''     
    ''' EN: Demo implementation of a ListLabel file repository which uses a SQLite database file to store the repository items.
    '''     Please check the documentation of the IRepository interface for more details.
    ''' </summary>
    Public Class SQLiteFileRepository
        Implements IRepository

        Private ReadOnly _db As IDbConnection
        Private ReadOnly _reportLanguage As String

        Public Sub New(databasePath As String, reportLanguage As String)
            Dim needsDatabaseInit As Boolean = Not File.Exists(databasePath)
            _db = New SQLiteConnection(Convert.ToString("Data Source=") & databasePath)
            _db.Open()

            If needsDatabaseInit Then
                DropAndCreateTables()
            End If
            _reportLanguage = reportLanguage
        End Sub

#Region "IRepository Implementation"

        ' See Interface
        Public Function ContainsItem(itemID As String) As Boolean Implements IRepository.ContainsItem
            Dim result As Integer = Convert.ToInt32(_db.CreateCommand("SELECT COUNT(*) FROM RepoItems WHERE ItemID = @ItemID").SetParameter("ItemID", itemID).ExecuteScalar())

            Return (result = 1)
        End Function

        ' See Interface
        Public Sub CreateOrUpdateItem(item As RepositoryItem, userImportData As String, sourceStream As Stream) Implements IRepository.CreateOrUpdateItem
            Dim currentUser As String = Nothing
            Try
                currentUser = HttpContext.Current.User.Identity.Name
            Catch generatedExceptionName As NullReferenceException
            End Try

            If String.IsNullOrEmpty(currentUser) Then
                currentUser = "[Anonymous User]"
            End If

            ' Convert stream from List & Label to byte array to store it in the DB
            ' Warning: sourceStream may be null! In that case, only the metadata should be changed in the database. See the documentation for IRepository.CreateOrUpdateItem() for details.
            Dim fileContent As Byte() = Nothing
            Dim setMetadataOnly As Boolean
            If sourceStream IsNot Nothing Then
                Using memStream = New MemoryStream()
                    sourceStream.CopyTo(memStream)
                    fileContent = memStream.ToArray()
                End Using
                setMetadataOnly = False
            Else
                setMetadataOnly = True
            End If


            Dim itemToInsert As CustomizedRepostoryItem
            Dim isUpdate As Boolean = ContainsItem(item.InternalID)

            ' Update of existing item?
            If isUpdate Then
                ' The 'item' parameter is always a new instance of the RepositoryItem class. List & Label does not know the custom properties
                ' that we have added to the RepositoryItem in the 'CustomizedRepostoryItem' class, so when we want to update an existing item,
                ' the already existing item must be updated manually. The 'Type' and 'InternalID' properties never change.

                itemToInsert = GetItemsFromDb(item.InternalID).First()
                itemToInsert.Descriptor = item.Descriptor
                itemToInsert.LastModificationUTC = item.LastModificationUTC
                itemToInsert.Author = currentUser
            Else
                ' New Repository Item
                ' Create an object of our own repository item class from the base class object that we got from List & Label.
                Dim showInToolbar As Boolean = RepositoryItemType.IsProjectType(item.Type, False)
                itemToInsert = New CustomizedRepostoryItem(item.InternalID, item.Descriptor, item.Type, item.LastModificationUTC, currentUser, showInToolbar, Nothing, _reportLanguage)
            End If

            ' Get a suitable SQL query for INSERT / UPDATE and a call with/without the file content.
            ' (If sourceStream is null, the file content must not be changed! In that case, only the metadata like descriptor, timestamp etc. should be modified.

            Dim sqlQuery As String
            If isUpdate Then
                ' UPDATE
                If setMetadataOnly Then
                    sqlQuery = "UPDATE RepoItems " & vbCr & vbLf & " SET Descriptor = @Descriptor, TimestampUTC = @TimestampUTC, Author = @Author, ShowInToolbar = @ShowInToolbar, OriginalFileName = @OriginalFileName, Language = @Language" & vbCr & vbLf & " WHERE ItemID = @ItemID"
                Else
                    sqlQuery = "UPDATE RepoItems " & vbCr & vbLf & " SET Descriptor = @Descriptor, TimestampUTC = @TimestampUTC, Author = @Author, ShowInToolbar = @ShowInToolbar, OriginalFileName = @OriginalFileName, FileContent = @FileContent, Language = @Language" & vbCr & vbLf & " WHERE ItemID = @ItemID"
                End If
            Else
                ' INSERT
                If setMetadataOnly Then
                    sqlQuery = "INSERT INTO RepoItems (ItemID, Type, Descriptor, TimestampUTC, Author, ShowInToolbar, OriginalFileName, Language) " & vbCr & vbLf & " VALUES (@ItemID, @Type, @Descriptor, @TimestampUTC, @Author, @ShowInToolbar, @OriginalFileName, @Language)"
                Else
                    sqlQuery = "INSERT INTO RepoItems (ItemID, Type, Descriptor, TimestampUTC, Author, ShowInToolbar, OriginalFileName, FileContent, Language) " & vbCr & vbLf & " VALUES (@ItemID, @Type, @Descriptor, @TimestampUTC, @Author, @ShowInToolbar, @OriginalFileName, @FileContent, @Language)"
                End If
            End If

            ' Note that this is always UTC time (convert to local time for the UI)
            ' SQLite has no boolean type, so use 1/0 for true/false.
            _db.CreateCommand(sqlQuery).SetParameter("ItemID", itemToInsert.InternalID).SetParameter("Type", itemToInsert.Type).SetParameter("Descriptor", itemToInsert.Descriptor).SetParameter("FileContent", fileContent).SetParameter("TimestampUTC", itemToInsert.LastModificationUTC.ToBinary()).SetParameter("Author", itemToInsert.Author).SetParameter("ShowInToolbar", If(itemToInsert.ShowInToolbar, 1, 0)).SetParameter("OriginalFileName", itemToInsert.OriginalFileName).SetParameter("Language", itemToInsert.Language).ExecuteNonQuery()
        End Sub

        ' See Interface
        Public Sub DeleteItem(itemID As String) Implements IRepository.DeleteItem
            _db.CreateCommand("DELETE FROM RepoItems WHERE ItemID = @ItemID").SetParameter("ItemID", itemID).ExecuteNonQuery()
        End Sub

        ' See Interface
        Public Function GetAllItems() As IEnumerable(Of RepositoryItem) Implements IRepository.GetAllItems
            Return GetItemsFromDb()
        End Function

        ' See Interface
        Public Function GetItem(itemID As String) As RepositoryItem Implements IRepository.GetItem
            Return GetItemsFromDb(itemID).FirstOrDefault()
        End Function

        ' See Interface
        Public Sub LoadItem(itemID As String, destinationStream As Stream, cancelToken As CancellationToken) Implements IRepository.LoadItem
            Dim content As Byte() = DirectCast(_db.CreateCommand("SELECT FileContent FROM RepoItems WHERE ItemID = @ItemID").SetParameter("ItemID", itemID).ExecuteScalar(), Byte())

            destinationStream.Write(content, 0, content.Length)
        End Sub

        ' See Interface
        Public Function LockItem(id As String) As Boolean Implements IRepository.LockItem
            ' If required, a repository item can be locked when it is loaded for editing. List & Label will call unlock when the designer is closed.
            ' IMPORTANT: Always implement a fallback to release the locks (e.g. timeout). Especially when used with the Web Designer, UnlockItem() might not get called due to network problems.

            ' Return true, if the lock was acquired or if no locking is implemented.
            ' Return false, if the item is locked by an other user. The designer will show an error message and open the item in read-only mode.

            Return True
        End Function

        ' See Interface
        Public Sub UnlockItem(id As String) Implements IRepository.UnlockItem

        End Sub

#End Region


#Region "Helpers"


        ''' <summary>Initialiazes a new repository database file</summary>
        Private Sub DropAndCreateTables()
            _db.CreateCommand(vbCr & vbLf & "DROP TABLE IF EXISTS RepoItems;" & vbCr & vbLf & "CREATE TABLE IF NOT EXISTS RepoItems (" & vbCr & vbLf & "ItemID TEXT," & vbCr & vbLf & "Type TEXT," & vbCr & vbLf & "Descriptor TEXT," & vbCr & vbLf & "TimestampUTC INT," & vbCr & vbLf & "FileContent BLOB," & vbCr & vbLf & "Author TEXT," & vbCr & vbLf & "ShowInToolbar INT," & vbCr & vbLf & "OriginalFileName TEXT," & vbCr & vbLf & "Language TEXT" & vbCr & vbLf & ");").ExecuteNonQuery()
        End Sub

        ''' <summary>Reads one or all items (itemId = null) from the database.</summary>
        Private Function GetItemsFromDb(Optional itemId As String = Nothing) As IEnumerable(Of CustomizedRepostoryItem)
            Dim result As New List(Of CustomizedRepostoryItem)()

            Dim cmd = _db.CreateCommand("SELECT ItemID, Type, Descriptor, TimestampUTC, Author, ShowInToolbar, OriginalFileName, LENGTH(FileContent), Language FROM RepoItems")

            ' Define language for the reports
            cmd.CommandText += " WHERE (Language isnull OR Language=@Language)"
            cmd.SetParameter("Language", _reportLanguage)

            If itemId IsNot Nothing Then
                ' Optional: select a specific item by it`s ID
                cmd.CommandText += " AND ItemID = @ItemId"
                cmd.SetParameter("ItemId", itemId)
            End If

            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    ' ItemID 
                    ' Descriptor 
                    ' Type 
                    ' TimestampUTC 
                    ' Author 
                    ' ShowInToolbar 
                    ' OriginalFileName
                    ' Language
                    result.Add(New CustomizedRepostoryItem(reader.GetString(0), reader.GetString(2), reader.GetString(1), DateTime.FromBinary(reader.GetInt64(3)), reader.GetString(4), If(reader.GetInt32(5) = 1, True, False),
                        If(reader.IsDBNull(6), Nothing, reader.GetString(6)),
                        If(reader.IsDBNull(8), Nothing, reader.GetString(8))) With {
                        .IsEmpty = If(reader.IsDBNull(7), True, (If(reader.GetInt32(7) = 0, True, False)))
                    })
                End While
            End Using

            Return result
        End Function

        ' Helper to update only some of the properties of a repository item.
        Public Sub SetItemMetadata(itemID As String, descriptor As String, showReportInToolbar As Boolean, originalFileName As String)
            _db.CreateCommand(vbCr & vbLf & " UPDATE RepoItems " & vbCr & vbLf & " SET Descriptor = @Descriptor," & vbCr & vbLf & " ShowInToolbar = @ShowInToolbar," & vbCr & vbLf & " OriginalFileName = @OriginalFileName," & vbCr & vbLf & " Language = @Language" & vbCr & vbLf & " WHERE ItemID = @ItemID").SetParameter("Descriptor", descriptor).SetParameter("ShowInToolbar", If(showReportInToolbar, 1, 0)).SetParameter("OriginalFileName", originalFileName).SetParameter("Language", _reportLanguage).SetParameter("ItemID", itemID).ExecuteNonQuery()
        End Sub


#End Region

    End Class


    ''' <summary>
    ''' Example for a customized repository item class that extends each item with some user-defined properties (Author, Original Filename, ...)
    ''' </summary>
    Public Class CustomizedRepostoryItem
        Inherits RepositoryItem
        ''' <summary>Name of the last user who modified the repository item.</summary>
        Public Property Author() As String
            Get
                Return m_Author
            End Get
            Set
                m_Author = Value
            End Set
        End Property
        Private m_Author As String

        ''' <summary>
        ''' A flag to decide if the repository item is displayed in the report list in the toolbar (header) of the sample.
        ''' Note that drilldown projects could also be used as standalone reports, but we want to hide them in the report list in the toolbar.
        ''' </summary>
        Public Property ShowInToolbar() As Boolean
            Get
                Return m_ShowInToolbar
            End Get
            Set
                m_ShowInToolbar = Value
            End Set
        End Property
        Private m_ShowInToolbar As Boolean

        ''' <summary>Saves the original file name for the download function of the SampleController. Note that the repository itself is not file based and does not need this property.</summary>
        Public Property OriginalFileName() As String
            Get
                Return m_OriginalFileName
            End Get
            Set
                m_OriginalFileName = Value
            End Set
        End Property
        Private m_OriginalFileName As String

        ''' <summary>Language for the report.</summary>
        Public Property Language() As String
            Get
                Return m_Language
            End Get
            Set
                m_Language = Value
            End Set
        End Property
        Private m_Language As String

        Public Sub New(itemID As String, descriptor As String, type As String, lastModified As DateTime, author__1 As String, showInToolbar__2 As Boolean, originalFileName__3 As String, language__4 As String)
            MyBase.New(itemID, descriptor, type, lastModified)
            Author = author__1
            ShowInToolbar = showInToolbar__2
            OriginalFileName = originalFileName__3
            Language = language__4
        End Sub

    End Class



    Module IDbCommandExtensions

        <Extension>
        Public Function CreateCommand(ByVal connection As IDbConnection, sql As String) As IDbCommand
            Dim cmd = connection.CreateCommand()
            cmd.CommandText = sql
            Return cmd
        End Function

        <Extension>
        Public Function SetParameter(ByVal cmd As IDbCommand, paramName As String, paramValue As Object) As IDbCommand
            Dim param = cmd.CreateParameter()
            param.ParameterName = paramName
            If paramValue IsNot Nothing Then
                param.Value = paramValue
            Else
                param.Value = DBNull.Value
            End If
            cmd.Parameters.Add(param)
            Return cmd
        End Function
    End Module
End Namespace
