using Microsoft.EntityFrameworkCore;
using Models;

namespace RESTfulAPI;

public class ServersContext : ApplicationContext
{
    public DbSet<ServerDetails> ServersDetails => Set<ServerDetails>();

    public ServersContext(DbContextOptions options)
        : base(options)
    { }
}
