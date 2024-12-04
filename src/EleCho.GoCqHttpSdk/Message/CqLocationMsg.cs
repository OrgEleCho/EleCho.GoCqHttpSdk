using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 消息段: 位置
/// </summary>
[Obsolete(NotSupportedCqCodeTip)]
public record class CqLocationMsg : CqMsg
{
    /// <summary>
    /// 消息段类型: 位置信息
    /// </summary>
    public override string MsgType => Consts.MsgType.Location;

    internal CqLocationMsg()
    { }

    /// <summary>
    /// 构建位置信息消息段
    /// </summary>
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    public CqLocationMsg(double lat, double lon)
    {
        Lat = lat;
        Lon = lon;
    }

    /// <summary>
    /// 纬度
    /// </summary>
    public double Lat { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    public double Lon { get; set; }

    /// <summary>
    /// 发送时可选, 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 发送时可选, 内容描述
    /// </summary>
    public string? Content { get; set; }

    internal override CqMsgDataModel? GetDataModel() => new CqLocationMsgDataModel(Lat, Lon, Title, Content);

    internal override void ReadDataModel(CqMsgDataModel? model)
    {
        var m = model as CqLocationMsgDataModel ?? throw new ArgumentException("model必须是CqLocationMsgDataModel");

        Lat = m.lat;
        Lon = m.lon;
        Title = m.title;
        Content = m.content;
    }
}