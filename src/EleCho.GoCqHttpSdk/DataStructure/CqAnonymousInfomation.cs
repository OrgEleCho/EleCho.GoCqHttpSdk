using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.DataStructure;

/// <summary>
/// 匿名信息
/// </summary>
public record class CqAnonymousInfomation
{
    internal CqAnonymousInfomation(CqAnonymousInformationModel model)
    {
        Id = model.id;
        Name = model.name;
        Flag = model.flag;
    }

    /// <summary>
    /// 构建匿名信息
    /// </summary>
    /// <param name="id">标识符</param>
    /// <param name="name">名称</param>
    /// <param name="flag">标识</param>
    public CqAnonymousInfomation(long id, string name, string flag)
    {
        Id = id;
        Name = name;
        Flag = flag;
    }

    /// <summary>
    /// 标识符
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 标识
    /// </summary>
    public string Flag { get; }
}