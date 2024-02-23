namespace MauiBlazor.Services;

internal interface IChannelsGateway
{
    Task<ChannelDetails[]> GetChannels(string[] ids);
}
