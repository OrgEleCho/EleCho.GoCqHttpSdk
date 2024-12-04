using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.DataStructure;

/// <summary>
/// 群员发送者
/// </summary>
public record class CqGroupMessageSender : CqMessageSender
{
    internal CqGroupMessageSender()
    {
    }

    internal CqGroupMessageSender(CqGroupMessageSenderModel model) : base(model)
    {
        Card = model.card;
        Area = model.area;
        Level = model.level;
        Title = model.title;
        Role = CqEnum.GetRole(model.role);
    }

    /// <summary>
    /// 群名片
    /// </summary>
    public string Card { get; } = string.Empty;
    /// <summary>
    /// 地区
    /// </summary>
    public string Area { get; } = string.Empty;
    /// <summary>
    /// 成员等级
    /// </summary>
    public string Level { get; } = string.Empty;
    /// <summary>
    /// 专属头衔
    /// </summary>
    public string Title { get; } = string.Empty;
    /// <summary>
    /// 群角色
    /// </summary>
    public CqRole Role { get; }
}