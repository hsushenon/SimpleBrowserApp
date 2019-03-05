

namespace SimpleBrowserApp
{
    public class ChannelItem
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string Address { get; set; }


        public ChannelItem(string channelId, string channelName, string address)
        {
            this.ChannelId = channelId;
            this.ChannelName = channelName;
            this.Address = address;
        }
    }
}
