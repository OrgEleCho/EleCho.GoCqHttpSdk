using EleCho.GoCqHttpSdk.Message;
using System;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 消息上报快速操作
/// </summary>
public abstract class CqMessagePostQuickOperation : CqPostQuickOperation
{
    /// <summary>
    /// 回复消息
    /// </summary>
    public CqMessage? Reply { get; set; }
    /// <summary>
    /// 因为内部不使用 CQ 码, 所以无用
    /// </summary>
    [Obsolete("在本 SDK 中此字段无用")]
    public bool AutoEscape { get; set; }

}