using Microsoft.Maui.Controls.PlatformConfiguration;
using Models;
using System.Linq;
using System.Net.Http.Json;

namespace MauiBlazor.Services;

internal class ServersGateway : IServersGateway
{
    private HttpClient HttpClient { get; set; }

    public ServersGateway()
    {
        HttpClient = new HttpClient();
    }

    public async Task<ServerDetails[]> GetServers(string[] ids)
    {
        var url = $"https://localhost:7153/Servers/GetServers?idsCsv={string.Join(',', ids)}";
        return await HttpClient.GetFromJsonAsync<ServerDetails[]>(url) ?? [];
    }

    public async Task<ServerDetails> GetServer(string id)
    {
        var url = $"https://localhost:7153/Servers/GetServer?id={id}";
        return await HttpClient.GetFromJsonAsync<ServerDetails>(url);
    }
}
