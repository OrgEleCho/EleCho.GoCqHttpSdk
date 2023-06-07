using EleCho.GoCqHttpSdk.Utils;
using System;
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
            packet_received = srcData.PacketReceived;
            packet_sent = srcData.PacketSent;
            packet_lost = srcData.PacketLost;
            message_received = srcData.MessageReceived;
            message_sent = srcData.MessageSent;
            disconnect_times = srcData.DisconnectTimes;
            lost_times = srcData.LostTimes;
            last_message_time = new DateTimeOffset(srcData.LastMessageTime).ToUnixTimeSeconds();
        }

        [JsonConstructor]
        public CqStatusStatisticsModel(ulong packet_received, ulong packet_sent, ulong packet_lost, ulong message_received, ulong message_sent, uint disconnect_times, uint lost_times, long last_message_time)
        {
            this.packet_received = packet_received;
            this.packet_sent = packet_sent;
            this.packet_lost = packet_lost;
            this.message_received = message_received;
            this.message_sent = message_sent;
            this.disconnect_times = disconnect_times;
            this.lost_times = lost_times;
            this.last_message_time = last_message_time;
        }

        public ulong packet_received { get; }
        public ulong packet_sent { get; }
        public ulong packet_lost { get; }
        public ulong message_received { get; }
        public ulong message_sent { get; }
        public uint disconnect_times { get; }
        public uint lost_times { get; }
        public long last_message_time { get; }
    }
}