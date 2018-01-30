using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Xamarin.Sqlite
{
    public class Database
    {
        static object locker = new object();
        IDatabaseConnection SQLiteDatabase
        {
            get
            {
                return DependencyService.Get<IDatabaseConnection>();
            }
        }

        readonly SQLiteConnection connection;
        readonly string DatabaseName;

        public Database(string databaseName)
        {
            DatabaseName = databaseName;
            connection = SQLiteDatabase.DbConnection(DatabaseName);
        }

        public long GetSize()
        {
            return SQLiteDatabase.GetSize(DatabaseName);
        }

        public void CreateTable<T>()
        {
            lock (locker)
            {
                connection.CreateTable<T>();
            }
        }

        public int UpdateItem<T>(T item)
        {
            lock (locker)
            {
                return connection.Update(item);
            }
        }

        public int InsertItem<T>(T item) 
        {
            lock (locker)
            {
                return connection.Insert(item);
            }
        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker)
            {
                connection.Execute(query, args);
            }
        }

        public List<T> Query<T>(string query, params object[] args) where T : new()
        {
            lock (locker)
            {
                return connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (locker)
            {
                return (from i in connection.Table<T>() select i).ToList();
            }
        }

        public TableQuery<T> Table<T>() where T : new()
        {
            lock (locker)
            {
                return connection.Table<T>();
            }
        }

        public int DeleteItem<T>(object primaryKey)
        {
            lock (locker)
            {
                return connection.Delete<T>(primaryKey);
            }
        }

        public int DeleteAll<T>()
        {
            lock (locker)
            {
                return connection.DeleteAll<T>();
            }
        }

        public string DatabasePath
        {
            get
            {
                return connection.DatabasePath;
            }
        }

    }
}
