using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群文件链接操作
/// </summary>
/// <remarks>
/// 构造 "获取群文件连接操作"
/// </remarks>
/// <param name="groupId"></param>
/// <param name="fileId"></param>
/// <param name="busid"></param>
public class CqGetGroupFileUrlAction(long groupId, string fileId, int busid) : CqAction
{

    /// <summary>
    /// 操作类型: 获取群文件链接
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupFileUrl;


    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 文件 ID
    /// </summary>
    public string FileId { get; set; } = fileId;

    /// <summary>
    /// 文件类型
    /// </summary>
    public int Busid { get; set; } = busid;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupFileUrlActionParamsModel(GroupId, FileId, Busid);
    }
}