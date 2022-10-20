using combit.Reporting.Repository;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace WebReporting
{

    /// <summary>
    /// DE: Beispiel-Implementierung eines Repositories für ListLabel, das die Dateien mit Hilfe einer SQLite-Datenbankdatei verwaltet.
    ///     Details sind der Dokumentation für das IRepository-Interface zu entnehmen.
    ///     
    /// EN: Demo implementation of a ListLabel file repository which uses a SQLite database file to store the repository items.
    ///     Please check the documentation of the IRepository interface for more details.
    /// </summary>
    public class SQLiteFileRepository : IRepository
    {

        private readonly IDbConnection _db;
        private readonly string _reportLanguage;

        public SQLiteFileRepository(string databasePath, string reportLanguage)
        {
            bool needsDatabaseInit = !File.Exists(databasePath);
            _db = new SqliteConnection("Data Source=" + databasePath);
            _db.Open();

            if (needsDatabaseInit)
                DropAndCreateTables();

            _reportLanguage = reportLanguage;
        }

        #region "IRepository Implementation"

        // See Interface
        public bool ContainsItem(string itemID)
        {
            int result = Convert.ToInt32(_db.CreateCommand(
                "SELECT COUNT(*) FROM RepoItems WHERE ItemID = @ItemID")
                   .SetParameter("ItemID", itemID).ExecuteScalar());

            return (result == 1);
        }

        // See Interface
        public void CreateOrUpdateItem(RepositoryItem item, string userImportData, Stream sourceStream)
        {
            string currentUser = null;
            try
            {
                currentUser = HttpContext.Current.User.Identity.Name;
            }
            catch (NullReferenceException)
            {
            }

            if (string.IsNullOrEmpty(currentUser))
                currentUser = "[Anonymous User]";

            // Convert stream from List & Label to byte array to store it in the DB
            // Warning: sourceStream may be null! In that case, only the metadata should be changed in the database. See the documentation for IRepository.CreateOrUpdateItem() for details.
            byte[] fileContent = null;
            bool setMetadataOnly;
            if (sourceStream != null)
            {
                using (var memStream = new MemoryStream())
                {
                    sourceStream.CopyTo(memStream);
                    fileContent = memStream.ToArray();
                }
                setMetadataOnly = false;
            }
            else
            {
                setMetadataOnly = true;
            }


            CustomizedRepostoryItem itemToInsert;
            bool isUpdate = ContainsItem(item.InternalID);

            // Update of existing item?
            if (isUpdate)
            {
                // The 'item' parameter is always a new instance of the RepositoryItem class. List & Label does not know the custom properties
                // that we have added to the RepositoryItem in the 'CustomizedRepostoryItem' class, so when we want to update an existing item,
                // the already existing item must be updated manually. The 'Type' and 'InternalID' properties never change.

                itemToInsert = GetItemsFromDb(item.InternalID).First();
                itemToInsert.Descriptor = item.Descriptor;
                itemToInsert.LastModificationUTC = item.LastModificationUTC;
                itemToInsert.Author = currentUser;
            }
            else   // New Repository Item
            {
                // Create an object of our own repository item class from the base class object that we got from List & Label.
                bool showInToolbar = RepositoryItemType.IsProjectType(item.Type, false);
                itemToInsert = new CustomizedRepostoryItem(item.InternalID, item.Descriptor, item.Type, item.LastModificationUTC, currentUser, showInToolbar, null, _reportLanguage);
            }

            // Get a suitable SQL query for INSERT / UPDATE and a call with/without the file content.
            // (If sourceStream is null, the file content must not be changed! In that case, only the metadata like descriptor, timestamp etc. should be modified.

            string sqlQuery;
            if (isUpdate)  // UPDATE
            {
                if (setMetadataOnly)
                {
                    sqlQuery = @"UPDATE RepoItems 
                                 SET Descriptor = @Descriptor, TimestampUTC = @TimestampUTC, Author = @Author, ShowInToolbar = @ShowInToolbar, OriginalFileName = @OriginalFileName, Language = @Language
                                 WHERE ItemID = @ItemID";
                }
                else
                {
                    sqlQuery = @"UPDATE RepoItems 
                                 SET Descriptor = @Descriptor, TimestampUTC = @TimestampUTC, Author = @Author, ShowInToolbar = @ShowInToolbar, OriginalFileName = @OriginalFileName, FileContent = @FileContent, Language = @Language
                                 WHERE ItemID = @ItemID";
                }
            }
            else    // INSERT
            {
                if (setMetadataOnly)
                {
                    sqlQuery = @"INSERT INTO RepoItems (ItemID,  Type,  Descriptor,  TimestampUTC,  Author,  ShowInToolbar,  OriginalFileName, Language) 
                                              VALUES  (@ItemID, @Type, @Descriptor, @TimestampUTC, @Author, @ShowInToolbar, @OriginalFileName, @Language)";
                }
                else
                {
                    sqlQuery = @"INSERT INTO RepoItems (ItemID,  Type,  Descriptor,  TimestampUTC,  Author,  ShowInToolbar,  OriginalFileName,  FileContent, Language) 
                                              VALUES  (@ItemID, @Type, @Descriptor, @TimestampUTC, @Author, @ShowInToolbar, @OriginalFileName, @FileContent, @Language)";
                }
            }

            _db.CreateCommand(sqlQuery)
                .SetParameter("ItemID", itemToInsert.InternalID)
                .SetParameter("Type", itemToInsert.Type)
                .SetParameter("Descriptor", itemToInsert.Descriptor)
                .SetParameter("FileContent", fileContent)
                .SetParameter("TimestampUTC", itemToInsert.LastModificationUTC.ToBinary())  // Note that this is always UTC time (convert to local time for the UI)
                .SetParameter("Author", itemToInsert.Author)
                .SetParameter("ShowInToolbar", itemToInsert.ShowInToolbar ? 1 : 0)  // SQLite has no boolean type, so use 1/0 for true/false.
                .SetParameter("OriginalFileName", itemToInsert.OriginalFileName)
                .SetParameter("Language", itemToInsert.Language)
                .ExecuteNonQuery();
        }

        // See Interface
        public void DeleteItem(string itemID)
        {
            _db.CreateCommand("DELETE FROM RepoItems WHERE ItemID = @ItemID")
                .SetParameter("ItemID", itemID)
                .ExecuteNonQuery();
        }

        // See Interface
        public IEnumerable<RepositoryItem> GetAllItems()
        {
            return GetItemsFromDb();
        }

        // See Interface
        public RepositoryItem GetItem(string itemID)
        {
            return GetItemsFromDb(itemID).FirstOrDefault();
        }

        // See Interface
        public void LoadItem(string itemID, Stream destinationStream, CancellationToken cancelToken)
        {
            object fileContent = _db.CreateCommand(
                 "SELECT FileContent FROM RepoItems WHERE ItemID = @ItemID")
                    .SetParameter("ItemID", itemID).ExecuteScalar();

            byte[] content = new byte[0];

            if (fileContent is byte[] byteContent)
            {
                content = byteContent;
            }

            destinationStream.Write(content, 0, content.Length);
        }

        // See Interface
        public bool LockItem(string id)
        {
            // If required, a repository item can be locked when it is loaded for editing. List & Label will call unlock when the designer is closed.
            // IMPORTANT: Always implement a fallback to release the locks (e.g. timeout). Especially when used with the Web Designer, UnlockItem() might not get called due to network problems.

            // Return true, if the lock was acquired or if no locking is implemented.
            // Return false, if the item is locked by an other user. The designer will show an error message and open the item in read-only mode.

            return true;
        }

        // See Interface
        public void UnlockItem(string id)
        {

        }

        #endregion


        #region "Helpers"


        /// <summary>Initialiazes a new repository database file</summary>
        private void DropAndCreateTables()
        {
            _db.CreateCommand(@"
                DROP TABLE IF EXISTS RepoItems;
                CREATE TABLE IF NOT EXISTS RepoItems (
                    ItemID               TEXT,
                    Type                 TEXT,
                    Descriptor           TEXT,
                    TimestampUTC         INT,
                    FileContent          BLOB,
                    Author               TEXT,
                    ShowInToolbar        INT,
                    OriginalFileName     TEXT,
                    Language             TEXT
                );").ExecuteNonQuery();
        }

        /// <summary>Reads one or all items (itemId = null) from the database.</summary>
        private IEnumerable<CustomizedRepostoryItem> GetItemsFromDb(string itemId = null)
        {
            List<CustomizedRepostoryItem> result = new List<CustomizedRepostoryItem>();

            var cmd = _db.CreateCommand("SELECT ItemID, Type, Descriptor, TimestampUTC, Author, ShowInToolbar, OriginalFileName, LENGTH(FileContent), Language FROM RepoItems");

            // Define language for the reports
            cmd.CommandText += " WHERE (Language isnull OR Language=@Language)";
            cmd.SetParameter("Language", _reportLanguage);

            if (itemId != null)   // Optional: select a specific item by it`s ID
            {
                cmd.CommandText += " AND (ItemID = @ItemId)";
                cmd.SetParameter("ItemId", itemId);
            }

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new CustomizedRepostoryItem(
                        /* ItemID */ reader.GetString(0),
                        /* Descriptor */ reader.GetString(2),
                        /* Type */ reader.GetString(1),
                        /* TimestampUTC */ DateTime.FromBinary(reader.GetInt64(3)),
                        /* Author */ reader.GetString(4),
                        /* ShowInToolbar */ reader.GetInt32(5) == 1 ? true : false,
                        /* OriginalFileName */ reader.IsDBNull(6) ? null : reader.GetString(6),
                        /* Language */ reader.IsDBNull(8) ? null : reader.GetString(8))
                    {
                        IsEmpty = reader.IsDBNull(7) ? true : (reader.GetInt32(7) == 0 ? true : false)
                    });
                }
            }

            return result;
        }

        // Helper to update only some of the properties of a repository item.
        public void SetItemMetadata(string itemID, string descriptor, bool showReportInToolbar, string originalFileName)
        {
            _db.CreateCommand(@"
                 UPDATE RepoItems 
                 SET Descriptor = @Descriptor,
                     ShowInToolbar = @ShowInToolbar,
                     OriginalFileName = @OriginalFileName,
                     Language = @Language
                 WHERE ItemID = @ItemID")
                    .SetParameter("Descriptor", descriptor)
                    .SetParameter("ShowInToolbar", showReportInToolbar ? 1 : 0)
                    .SetParameter("OriginalFileName", originalFileName)
                    .SetParameter("Language", _reportLanguage)
                    .SetParameter("ItemID", itemID)
                    .ExecuteNonQuery();
        }

        #endregion

    }


    /// <summary>
    /// Example for a customized repository item class that extends each item with some user-defined properties (Author, Original Filename, ...)
    /// </summary>
    public class CustomizedRepostoryItem : RepositoryItem
    {
        /// <summary>Name of the last user who modified the repository item.</summary>
        public string Author { get; set; }

        /// <summary>
        /// A flag to decide if the repository item is displayed in the report list in the toolbar (header) of the sample.
        /// Note that drilldown projects could also be used as standalone reports, but we want to hide them in the report list in the toolbar.
        /// </summary>
        public bool ShowInToolbar { get; set; }

        /// <summary>Saves the original file name for the download function of the SampleController. Note that the repository itself is not file based and does not need this property.</summary>
        public string OriginalFileName { get; set; }

        /// <summary>Language for the report.</summary>
        public string Language { get; set; }

        public CustomizedRepostoryItem(string itemID, string descriptor, string type, DateTime lastModified, string author, bool showInToolbar, string originalFileName, string language)
            : base(itemID, descriptor, type, lastModified)
        {
            Author = author;
            ShowInToolbar = showInToolbar;
            OriginalFileName = originalFileName;
            Language = language;
        }

    }

    internal static class IDbCommandExtensions
    {

        public static IDbCommand CreateCommand(this IDbConnection connection, string sql)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }

        public static IDbCommand SetParameter(this IDbCommand cmd, string paramName, object paramValue)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            if (paramValue != null)
            {
                param.Value = paramValue;
            }
            else
            {
                param.Value = DBNull.Value;
            }
            cmd.Parameters.Add(param);
            return cmd;
        }
    }
}

