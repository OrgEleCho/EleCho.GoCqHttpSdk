using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk
{
    public record class CqStatusStatistics
    {
        public CqStatusStatistics()
        {
        }

        internal CqStatusStatistics(CqStatusStatisticsModel model)
        {
            PacketReceived = model.PacketReceived;
            PacketSent = model.PacketSent;
            PacketLost = model.PacketLost;
            MessageReceived = model.MessageReceived;
            MessageSent = model.MessageSent;
            DisconnectTimes = model.DisconnectTimes;
            LostTimes = model.LostTimes;
            LastMessageTime = DateTimeOffset.FromUnixTimeSeconds(model.LastMessageTime).DateTime;
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

        public ulong PacketReceived { get; }
        public ulong PacketSent { get; }
        public ulong PacketLost { get; }
        public ulong MessageReceived { get; }
        public ulong MessageSent { get; }
        public uint DisconnectTimes { get; }
        public uint LostTimes { get; }
        public DateTime LastMessageTime { get; }
    }
}