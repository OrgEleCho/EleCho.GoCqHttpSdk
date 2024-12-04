#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 链接分享消息段
/// </summary>
public record class CqShareMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: 链接分享
    /// </summary>
    public override string MsgType => Consts.MsgType.Share;

    internal CqShareMsg()
    { }

    /// <summary>
    /// 构建 '链接分享消息段' 
    /// </summary>
    /// <param name="url"></param>
    /// <param name="title"></param>
    public CqShareMsg(string url, string title)
    {
        Url = url;
        Title = title;
    }

    /// <summary>
    /// 说明: URL
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 说明: 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 说明: 发送时可选, 内容描述
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 说明: 发送时可选, 图片 URL
    /// </summary>
    public string? Image { get; set; }

    internal override CqMsgDataModel? GetDataModel() => new CqShareMsgDataModel(Url, Title, Content, Image);

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqShareMsgDataModel ?? throw new ArgumentException("model必须是CqShareMsgDataModel");

        Url = m.url;
        Title = m.title;
        Content = m.content;
        Image = m.image;
    }
}