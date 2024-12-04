using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 删除群文件操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
/// <param name="fileId"></param>
/// <param name="busid"></param>
public class CqDeleteGroupFileAction(long groupId, string fileId, int busid) : CqAction
{

    /// <summary>
    /// 操作类型: 删除群文件
    /// </summary>
    public override CqActionType ActionType => CqActionType.DeleteGroupFile;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 文件 ID, 参考 <see cref="CqGroupFile"/>
    /// </summary>
    public string FileId { get; set; } = fileId;

    /// <summary>
    /// 文件类型, 参考 <see cref="CqGroupFile"/>
    /// </summary>
    public int Busid { get; set; } = busid;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDeleteGroupFileActionParamsModel(GroupId, FileId, Busid);
    }
}