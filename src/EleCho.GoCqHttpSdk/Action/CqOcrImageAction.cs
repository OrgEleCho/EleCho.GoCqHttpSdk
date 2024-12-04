using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 图片 OCR
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="image"></param>
public class CqOcrImageAction(string image) : CqAction
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override CqActionType ActionType => CqActionType.OcrImage;

    /// <summary>
    /// 图片 ID
    /// </summary>
    public string Image { get; set; } = image;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqOcrImageActionParamsModel(Image);
    }
}