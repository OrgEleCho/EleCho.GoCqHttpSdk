using NullLib.GoCqHttpSdk.Util;

namespace NullLib.GoCqHttpSdk.Post
{
    internal class CqStatusStatisticsModel
    {
        public CqStatusStatisticsModel() { }
        public CqStatusStatisticsModel(CqStatusStatistics srcData)
        {
            PacketReceived = srcData.PacketReceived;
            PacketSent = srcData.PacketSent;
            PacketLost = srcData.PacketLost;
            MessageReceived = srcData.MessageReceived;
            MessageSent = srcData.MessageSent;
            DisconnectTimes = srcData.DisconnectTimes;
            LostTimes = srcData.LostTimes;
            LastMessageTime = UnixTime.DateToUnix(srcData.LastMessageTime);
        }

        public ulong PacketReceived { get; set; }
        public ulong PacketSent { get; set; }
        public ulong PacketLost { get; set; }
        public ulong MessageReceived { get; set; }
        public ulong MessageSent { get; set; }
        public uint DisconnectTimes { get; set; }
        public uint LostTimes { get; set; }
        public long LastMessageTime { get; set; }
    }
}
