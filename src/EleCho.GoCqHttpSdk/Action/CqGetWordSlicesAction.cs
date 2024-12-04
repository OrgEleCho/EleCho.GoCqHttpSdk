using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取分词
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="content"></param>
public class CqGetWordSlicesAction(string content) : CqAction
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetWordSlices;

    /// <summary>
    /// 分词内容
    /// </summary>
    public string Content { get; set; } = content;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetWordSlicesActionParamsModel(Content);
    }
}