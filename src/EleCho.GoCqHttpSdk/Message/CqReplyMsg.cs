using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 消息回复消息段
/// </summary>
public record class CqReplyMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: 消息回复
    /// </summary>
    public override string MsgType => Consts.MsgType.Reply;


    internal CqReplyMsg()
    { }


    /// <summary>
    /// 实例化回复消息
    /// </summary>
    /// <param name="id"></param>
    public CqReplyMsg(long id)
    {
        Id = id;
    }

    /// <summary>
    /// 实例化自定义回复消息
    /// </summary>
    /// <param name="text"></param>
    /// <param name="userId"></param>
    /// <param name="seq"></param>
    public CqReplyMsg(string text, long userId, long seq)
    {
        Text = text;
        UserId = userId;
        Seq = seq;

        Time = DateTime.Now;
    }

    /// <summary>
    /// 实例化自定义回复消息
    /// </summary>
    /// <param name="text"></param>
    /// <param name="userId"></param>
    /// <param name="seq"></param>
    /// <param name="time"></param>
    public CqReplyMsg(string text, long userId, long seq, DateTime time)
    {
        Text = text;
        UserId = userId;
        Seq = seq;

        Time = time;
    }

    /// <summary>
    /// 回复的消息 ID (必须是当前会话的消息)
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    /// 自定义回复消息内容
    /// </summary>
    public string? Text { get; set; } = string.Empty;

    /// <summary>
    /// 自定义回复消息的 QQ
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 自定义回复消息的事件
    /// </summary>
    public DateTime? Time { get; set; }

    /// <summary>
    /// 起始序列号 (可以通过 <see cref="CqActionSessionExtensions.GetMessage(ICqActionSession, long)"/> 来获取)
    /// </summary>
    public long? Seq { get; set; }

    internal override CqMsgDataModel? GetDataModel()
    {
        if (Id != null)
            return new CqReplyMsgDataModel(Id.Value);
        else if (Text != null && UserId != null && Time != null && Seq != null)
            return new CqReplyMsgDataModel(Text, UserId.Value, new DateTimeOffset(Time.Value).ToUnixTimeMilliseconds(), Seq.Value);

        throw new InvalidOperationException("实例没有被正确初始化");
    }

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqReplyMsgDataModel ?? throw new ArgumentException("model必须是CqReplyMsgDataModel");

        Id = m.id;
        Text = m.text;
        UserId = m.qq;
        Seq = m.seq;

        if (m.time != null)
            Time = DateTimeOffset.FromUnixTimeSeconds(m.time.Value).DateTime;
    }
}