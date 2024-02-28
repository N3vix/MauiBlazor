using Microsoft.EntityFrameworkCore;
using Models;

namespace RESTfulAPI;

public class ChannelsContext : ApplicationContext
{
    public DbSet<ChannelDetails> ChannelsDetails => Set<ChannelDetails>();


    public ChannelsContext(DbContextOptions options)
        : base(options)
    { }
}
