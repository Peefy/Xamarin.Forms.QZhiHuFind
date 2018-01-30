using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLitePCL;
using SQLite;

namespace Xamarin.Sqlite
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
        SQLiteConnection DbConnection(string dbName);
        long GetSize(string databaseName);
    }
}
