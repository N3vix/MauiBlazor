using Microsoft.EntityFrameworkCore;
using Models;

namespace RESTfulAPI;

public class ServersContext : DbContext
{
    public DbSet<ServerDetails> ServersDetails => Set<ServerDetails>();

    public ServersContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB.db");
    }
}
