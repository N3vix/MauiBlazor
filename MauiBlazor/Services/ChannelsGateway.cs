using Models;

namespace MauiBlazor.Services;

internal class ChannelsGateway : IChannelsGateway
{
    private ChannelDetails[] Channels { get; set; }

    public ChannelsGateway()
    {
        var textChannels = Enumerable.Range(1, 100).Select(x => new ChannelDetails()
        {
            Id = $"TC{x}",
            Name = $"Text Channel {x}",
            Type = ChannelType.Text,
        });

        var voiceChannels = Enumerable.Range(1, 100).Select(x => new ChannelDetails()
        {
            Id = $"VC{x}",
            Name = $"Voice Channel {x}",
            Type = ChannelType.Voice,
        });

        Channels = textChannels.Union(voiceChannels).ToArray();
    }

    public async Task<ChannelDetails[]> GetChannels(string[] ids)
    {
        await Task.Delay(500);

        return ids?
            .Select(x => Channels.FirstOrDefault(server => server.Id.Equals(x)))
            .Where(x => x != null)
            .ToArray() ?? [];
    }
}
