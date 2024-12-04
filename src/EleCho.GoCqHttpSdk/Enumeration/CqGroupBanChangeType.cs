namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 群禁言变更类型
/// </summary>
public enum CqGroupBanChangeType
{
    /// <summary>
    /// 禁言
    /// </summary>
    Ban, 
    
    /// <summary>
    /// 取消禁言
    /// </summary>
    LiftBan,

    /// <summary>
    /// 未知
    /// </summary>
    Unknown = -1
}