using Microsoft.EntityFrameworkCore;
using Models;

namespace RESTfulAPI;

public class ServersGateway : IServersGateway
{
    private ServersContext ServersContext { get; }

    public ServersGateway(ServersContext serversContext)
    {
        ServersContext = serversContext ?? throw new ArgumentNullException(nameof(serversContext));
    }

    public async Task Add(params ServerDetails[] serverDetails)
    {
        if (serverDetails == null) throw new ArgumentNullException(nameof(serverDetails));

        await ServersContext.ServersDetails.AddRangeAsync(serverDetails);
        await ServersContext.SaveChangesAsync();
    }

    public async Task<ServerDetails[]> GetAll()
    {
        return await ServersContext.ServersDetails.ToArrayAsync();
    }

    public async Task<ServerDetails[]> GetByServerId(string[] ids)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));

        return await ServersContext.ServersDetails.Where(x => ids.Contains(x.ServerId)).ToArrayAsync();
    }

    public async Task<ServerDetails> GetByServerId(string id)
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

        var s = await ServersContext.ServersDetails
            .FirstOrDefaultAsync(x => x.ServerId.Equals(id));
        return s;
    }

    public async Task Edit(string id, Action<ServerDetails> editor)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));
        if (editor is null) throw new ArgumentNullException(nameof(editor));

        var details = await GetByServerId(id);
        if (details == null) return;
        editor(details);
        await ServersContext.SaveChangesAsync();
    }
}
