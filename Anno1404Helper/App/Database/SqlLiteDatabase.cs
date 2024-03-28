using SQLite;

namespace Anno1404Helper.App.Database;

public class SqlLiteDatabase
{
    public const string DatabaseFilename = "TodoSQLite.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    SQLiteAsyncConnection Database;

    public SqlLiteDatabase()
    {
        Database = new SQLiteAsyncConnection(DatabasePath, Flags);
    }

    async Task Init()
    {
        

        
        // var result = await Database.CreateTableAsync<TodoItem>();
    }
}