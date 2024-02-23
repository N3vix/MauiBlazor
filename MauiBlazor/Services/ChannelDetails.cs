namespace MauiBlazor.Services;

internal class ChannelDetails
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ChannelType Type { get; set; }
}

internal enum ChannelType
{
    Text,
    Voice
}
