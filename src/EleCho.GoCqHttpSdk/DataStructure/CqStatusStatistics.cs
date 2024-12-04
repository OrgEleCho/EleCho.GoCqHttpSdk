using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 客户端状态统计信息
/// </summary>
public record class CqStatusStatistics
{
    /// <summary>
    /// 篝构建客户端状态统计信息
    /// </summary>
    public CqStatusStatistics()
    {
    }

    internal CqStatusStatistics(CqStatusStatisticsModel model)
    {
        PacketReceived = model.packet_received;
        PacketSent = model.packet_sent;
        PacketLost = model.packet_lost;
        MessageReceived = model.message_received;
        MessageSent = model.message_sent;
        DisconnectTimes = model.disconnect_times;
        LostTimes = model.lost_times;
        LastMessageTime = DateTimeOffset.FromUnixTimeSeconds(model.last_message_time).DateTime;
    }

    /// <summary>
    /// 构建客户端状态统计信息
    /// </summary>
    /// <param name="packetReceived"></param>
    /// <param name="packetSent"></param>
    /// <param name="packetLost"></param>
    /// <param name="messageReceived"></param>
    /// <param name="messageSent"></param>
    /// <param name="disconnectTimes"></param>
    /// <param name="lostTimes"></param>
    /// <param name="lastMessageTime"></param>
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

    /// <summary>
    /// 收包数
    /// </summary>
    public ulong PacketReceived { get; }

    /// <summary>
    /// 发包数
    /// </summary>
    public ulong PacketSent { get; }

    /// <summary>
    /// 丢包数
    /// </summary>
    public ulong PacketLost { get; }

    /// <summary>
    /// 消息接收数
    /// </summary>
    public ulong MessageReceived { get; }

    /// <summary>
    /// 消息发送数
    /// </summary>
    public ulong MessageSent { get; }

    /// <summary>
    /// 断连次数
    /// </summary>
    public uint DisconnectTimes { get; }

    /// <summary>
    /// 丢失次数
    /// </summary>
    public uint LostTimes { get; }

    /// <summary>
    /// 最后一次消息时间
    /// </summary>
    public DateTime LastMessageTime { get; }
}