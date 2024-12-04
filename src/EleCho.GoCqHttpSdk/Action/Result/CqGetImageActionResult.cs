using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取图像操作结果
/// </summary>
public record class CqGetImageActionResult : CqActionResult
{
    /// <summary>
    /// 尺寸
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// 文件名
    /// </summary>
    public string Filename { get; private set; } = string.Empty;

    /// <summary>
    /// 链接
    /// </summary>
    public string Url { get; private set; } = string.Empty;
    
    internal CqGetImageActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is CqGetImageActionResultDataModel dataModel)
        {
            Size = dataModel.size;
            Filename = dataModel.filename;
            Url = dataModel.filename;
        }
    }
}