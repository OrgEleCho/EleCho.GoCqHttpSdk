using EleCho.GoCqHttpSdk.Utils;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    /// <summary>
    /// (虽然很奇怪, 但是这里确实是大写)
    /// </summary>
    internal record class CqStatusStatisticsModel
    {
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

        [JsonConstructor]
        public CqStatusStatisticsModel(ulong packetReceived, ulong packetSent, ulong packetLost, ulong messageReceived, ulong messageSent, uint disconnectTimes, uint lostTimes, long lastMessageTime)
        {
            PacketReceived = packetReceived;
            PacketSent = packetSent;
            PacketLost = packetLost;
            MessageReceived = messageReceived;
            MessageSent = messageSent;
            DisconnectTimes = disconnectTimes;
            LostTimes = lostTimes;
            LastMessageTime = lastMessageTime;
        }

        public ulong PacketReceived { get; }
        public ulong PacketSent { get; }
        public ulong PacketLost { get; }
        public ulong MessageReceived { get; }
        public ulong MessageSent { get; }
        public uint DisconnectTimes { get; }
        public uint LostTimes { get; }
        public long LastMessageTime { get; }
    }
}