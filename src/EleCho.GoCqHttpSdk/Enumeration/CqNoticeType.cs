namespace EleCho.GoCqHttpSdk.Enumeration;

/// <summary>
/// 通知类型
/// </summary>
public enum CqNoticeType
{
    /// <summary>
    /// 客户端状态变更
    /// </summary>
    ClientStatus,

    /// <summary>
    /// 群文件上传
    /// </summary>
    GroupUpload,

    /// <summary>
    /// 群管理员变更
    /// </summary>
    GroupAdmin,

    /// <summary>
    /// 群成员减少
    /// </summary>
    GroupDecrease,

    /// <summary>
    /// 群成员增加
    /// </summary>
    GroupIncrease,

    /// <summary>
    /// 群禁言
    /// </summary>
    GroupBan,

    /// <summary>
    /// 群消息撤回
    /// </summary>
    GroupRecall,

    /// <summary>
    /// 好友消息撤回
    /// </summary>
    FriendRecall,

    /// <summary>
    /// 群名片变更
    /// </summary>
    GroupCard,

    /// <summary>
    /// 精华消息变更
    /// </summary>
    Essence,

    /// <summary>
    /// 群通知
    /// </summary>
    Notify,

    /// <summary>
    /// 好友添加
    /// </summary>
    FriendAdd,

    /// <summary>
    /// 离线文件
    /// </summary>
    OfflineFile,
}