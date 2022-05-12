using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqStatusStatistics
    {
        internal CqStatusStatistics(CqStatusStatisticsModel model)
        {
            PacketReceived = model.PacketReceived;
            PacketSent = model.PacketSent;
            PacketLost = model.PacketLost;
            MessageReceived = model.MessageReceived;
            MessageSent = model.MessageSent;
            DisconnectTimes = model.DisconnectTimes;
            LostTimes = model.LostTimes;
            LastMessageTime = UnixTime.DateFromUnix(model.LastMessageTime);
        }
        public CqStatusStatistics(ulong packetReceived,
                                  ulong packetSent,
                                  ulong packetLost,
                                  ulong messageReceived,
                                  ulong messageSent,
                                  uint disconnectTimes,
                                  uint lostTimes,
                                  DateTime lastMessageTime)
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

        public ulong PacketReceived { get; set; }
        public ulong PacketSent { get; set; }
        public ulong PacketLost { get; set; }
        public ulong MessageReceived { get; set; }
        public ulong MessageSent { get; set; }
        public uint DisconnectTimes { get; set; }
        public uint LostTimes { get; set; }
        public DateTime LastMessageTime { get; set; }
    }
}
