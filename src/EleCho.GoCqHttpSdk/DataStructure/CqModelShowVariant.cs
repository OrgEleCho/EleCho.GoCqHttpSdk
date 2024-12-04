using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 展示机型的变体
/// </summary>
public record class CqModelShowVariant
{
    internal CqModelShowVariant(CqModelShowVariantModel model)
    {
        ModelShow = model.model_show;
        NeedPay = model.need_pay;
    }

    /// <summary>
    /// 构建 '展示机型的变体'
    /// </summary>
    /// <param name="modelShow"></param>
    /// <param name="needPay"></param>
    public CqModelShowVariant(string modelShow, bool needPay)
    {
        ModelShow = modelShow;
        NeedPay = needPay;
    }

    /// <summary>
    /// 展示机型
    /// </summary>
    public string ModelShow { get; }

    /// <summary>
    /// 需要付费
    /// </summary>
    public bool NeedPay { get; }
}