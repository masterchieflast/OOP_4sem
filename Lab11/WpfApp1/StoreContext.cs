using Microsoft.EntityFrameworkCore;

namespace WpfApp1;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-LAFI17U\\MSSQLSERVER06;Database=StoreDb;Encrypt=False;Trusted_Connection=SSPI");
    }
}