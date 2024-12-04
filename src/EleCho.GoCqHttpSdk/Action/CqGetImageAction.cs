using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取图片操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="filename">文件名</param>
public class CqGetImageAction(string filename) : CqAction
{
    /// <summary>
    /// 操作类型: 获取图像
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetImage;

    /// <summary>
    /// 文件名
    /// </summary>
    public string Filename { get; set; } = filename;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetImageActionParamsModel(Filename);
    }
}