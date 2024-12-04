namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 消息类型
/// </summary>
public enum CqMessageType
{
    /// <summary>
    /// 私聊
    /// </summary>
    Private,
    
    /// <summary>
    /// 群聊
    /// </summary>
    Group,

    /// <summary>
    /// 未知
    /// </summary>
    Unknown = -1
}