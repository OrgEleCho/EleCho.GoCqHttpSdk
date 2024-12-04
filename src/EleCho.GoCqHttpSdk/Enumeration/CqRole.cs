namespace EleCho.GoCqHttpSdk.Enumeration;

/// <summary>
/// 角色
/// </summary>
public enum CqRole
{
    /// <summary>
    /// 成员
    /// </summary>
    Member = 0b0000,

    /// <summary>
    /// 管理员 (群管理员)
    /// </summary>
    Admin  = 0b0001,

    /// <summary>
    /// 所有者 (群主)
    /// </summary>
    Owner  = 0b0011,

    /// <summary>
    /// 未知
    /// </summary>
    Unknown = -1
}