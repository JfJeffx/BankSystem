using BankSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace BankSystem.Data;
public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<History> Histories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Projects\\SqliteDb\\accounts.db");
}
