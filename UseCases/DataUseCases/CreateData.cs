using BankSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace BankSystem.UseCases.DataUseCases;
public class CreateData
{
    public static void DataMigration()
    {
        if (Create())
            Save();
    }
    private static bool Create()
    {
        if (!File.Exists("C:\\Projects\\SqliteDb\\accounts.db"))
        {
            File.Create("C:\\Projects\\SqliteDb\\accounts.db");
            return true;
        }
        return false;
    }

    private static void Save()
    {
        using var db = new DataContext();
        try
        {
            db.Database.OpenConnection();
            db.Database.Migrate();
        }
        finally { db.Database.CloseConnection(); }
    }
}
