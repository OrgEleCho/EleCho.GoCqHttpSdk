using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// JSON 消息段
/// </summary>
public record class CqJsonMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: JSON 消息
    /// </summary>
    public override string MsgType => Consts.MsgType.Json;

    internal CqJsonMsg()
    { }

    /// <summary>
    /// 构建 JSON 消息段
    /// </summary>
    /// <param name="data"></param>
    public CqJsonMsg(string data)
    {
        Data = data;
    }

    /// <summary>
    /// JSON 数据内容
    /// </summary>
    public string Data { get; set; } = string.Empty;

    /// <summary>
    /// 默认不填为0, 走小程序通道, 填了走富文本通道发送
    /// </summary>
    public int ResId { get; set; }

    internal override CqMsgDataModel? GetDataModel() => new CqJsonMsgDataModel(Data, ResId);

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqJsonMsgDataModel ?? throw new ArgumentException("model必须是CqJsonMsgDataModel");

        Data = m.data;
        ResId = m.resid;
    }
}