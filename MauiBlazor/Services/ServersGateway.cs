namespace MauiBlazor.Services;

internal class ServersGateway : IServersGateway
{
    private ServerDetails[] Servers { get; set; }

    public ServersGateway()
    {
        Servers = Enumerable.Range(1, 20).Select(x => new ServerDetails()
        {
            Id = $"Server{x}",
            Name = $"Server {x}"
        }).ToArray();
    }

    public async Task<ServerDetails[]> GetServers(string[] ids)
    {
        await Task.Delay(500);

        return ids
            .Select(x => Servers.FirstOrDefault(server => server.Id.Equals(x, StringComparison.Ordinal)))
            .Where(x => x != null)
            .ToArray();
    }

    public async Task<ServerDetails> GetServer(string id)
    {
        await Task.Delay(500);

        return Servers.FirstOrDefault(server => server.Id.Equals(id, StringComparison.Ordinal));
    }
}
