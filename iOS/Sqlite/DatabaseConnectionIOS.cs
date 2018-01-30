using System;
using SQLite;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(QZhihuFind.iOS.Sqlite.DatabaseConnectionIOS))]

namespace QZhihuFind.iOS.Sqlite
{
    public class DatabaseConnectionIOS : Xamarin.Sqlite.IDatabaseConnection
    {

        string GetPath(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentException("Invalid database name", nameof(databaseName));
            }
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, databaseName);
            return path;
        }

        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            return new SQLiteConnection(GetPath(dbName));
        }

        public SQLiteConnection DbConnection(string dbName)
        {
            return new SQLiteConnection(GetPath(dbName));
        }

        public long GetSize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo != null ? fileInfo.Length : 0;
        }

    }
}
