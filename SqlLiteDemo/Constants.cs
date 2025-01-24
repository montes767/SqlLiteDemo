using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo
{
    public static class Constants
    {
        public const string DatabaseFileName = "Sqlite.db3";
        public const SQLiteOpenFlags flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {

            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
            }
        }
    }
}
