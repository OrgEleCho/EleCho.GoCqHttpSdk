using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群头像操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="file">文件</param>
/// <param name="useCache">使用缓存</param>
public class CqSetGroupAvatarAction(long groupId, string file, bool useCache) : CqAction
{
    /// <summary>
    /// 实例化对象 (UseCache = false)
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    public CqSetGroupAvatarAction(long groupId, string file) : this(groupId, file, false) { }

    /// <summary>
    /// 操作类型: 设置群头像
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetGroupAvatar;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 文件
    /// </summary>
    public string File { get; set; } = file;

    /// <summary>
    /// 使用缓存
    /// </summary>
    public bool UseCache { get; set; } = useCache;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetGroupAvatarActionParamsModel(GroupId, File, UseCache ? 1 : 0);
    }
}
