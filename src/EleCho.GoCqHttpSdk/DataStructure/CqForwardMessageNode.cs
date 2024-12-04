using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Linq;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 转发消息节点
/// </summary>
public record class CqForwardMessageNode : CqMsg
{
    /// <summary>
    /// 消息类型: 节点
    /// </summary>
    public override string MsgType => Consts.MsgType.Node;

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long? Id { get; private set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; private set; }

    /// <summary>
    /// QQ 号
    /// </summary>
    public long? UserId { get; private set; }

    /// <summary>
    /// 内容
    /// </summary>
    public CqMessage? Content { get; private set; }

    /// <summary>
    /// 暂时不确定
    /// </summary>
    public CqMessage? Seq { get; private set; }

    internal CqForwardMessageNode()
    { }


    /// <summary>
    /// 构建转发消息节点
    /// </summary>
    /// <param name="id"></param>
    public CqForwardMessageNode(long id)
    {
        Id = id;
    }

    /// <summary>
    /// 构建转发消息节点
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="content">内容</param>
    public CqForwardMessageNode(string name, long userId, CqMessage content)
    {
        Name = name;
        UserId = userId;
        Content = content;
    }


    /// <summary>
    /// 构建转发消息节点
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="content">内容</param>
    /// <param name="seq">不知道啥玩意儿</param>
    public CqForwardMessageNode(string name, long userId, CqMessage content, CqMessage seq)
    {
        Name = name;
        UserId = userId;
        Content = content;
        Seq = seq;
    }

    internal override CqMsgDataModel? GetDataModel() =>
        new CqForwardMsgNodeDataModel(Id, Name, UserId,
            Content?.Select(ToModel).ToArray(),
            Seq?.Select(ToModel).ToArray());

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqForwardMsgNodeDataModel ?? throw new ArgumentException("model必须是CqForwardMsgNodeDataModel");

        Id = m.id;
        Name = m.name;
        UserId = m.uin;
        Content = m.content == null ? null : new CqMessage(m.content.Select(FromModel));
        Seq = m.seq == null ? null : new CqMessage(m.seq.Select(FromModel));
    }
}