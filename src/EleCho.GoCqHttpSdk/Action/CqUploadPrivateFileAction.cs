using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 上传私聊文件操作
/// </summary>
/// <remarks>
/// 构建 '上传私聊文件操作'
/// </remarks>
/// <param name="userId"></param>
/// <param name="file"></param>
/// <param name="name"></param>
public class CqUploadPrivateFileAction(long userId, string file, string name) : CqAction
{

    /// <summary>
    /// 操作类型: 上传私聊文件
    /// </summary>
    public override CqActionType ActionType => CqActionType.UploadPrivateFile;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 文件
    /// </summary>
    public string File { get; set; } = file;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = name;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqUploadPrivateFileActionParamsModel(UserId, File, Name);
    }
}