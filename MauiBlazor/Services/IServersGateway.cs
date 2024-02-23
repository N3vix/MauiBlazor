namespace MauiBlazor.Services;

internal interface IServersGateway
{
    Task<ServerDetails[]> GetServers(string[] ids);
    Task<ServerDetails> GetServer(string id);
}