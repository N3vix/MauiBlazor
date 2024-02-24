using Microsoft.AspNetCore.Mvc;
using Models;
using RESTfulAPI.Controllers;

namespace MauiBlazor.Services;

[ApiController]
[Route("[controller]")]
public class ServersController : ControllerBase
{
    private readonly ILogger<ServersController> _logger;


    private ServerDetails[] Servers { get; set; }


    public ServersController(ILogger<ServersController> logger)
    {
        _logger = logger;

        Servers = Enumerable.Range(1, 20).Select(x => new ServerDetails()
        {
            Id = $"Server{x}",
            Name = $"Server {x}",
            ChannelIds = [$"TC{x * 2}", $"TC20{x * 2}", $"VC{x * 2}"]
        }).ToArray();
    }

    [HttpGet("[action]")]
    public IEnumerable<ServerDetails> GetServers([FromQuery] string idsCsv)
    {
        var ids = idsCsv.Split(',');
        return ids
            .Select(x => Servers.FirstOrDefault(server => server.Id.Equals(x, StringComparison.Ordinal)))
            .Where(x => x != null)
            .ToArray();
    }

    [HttpGet("[action]")]
    public ServerDetails GetServer([FromQuery] string id)
    {
        return Servers.FirstOrDefault(server => server.Id.Equals(id, StringComparison.Ordinal));
    }
}
