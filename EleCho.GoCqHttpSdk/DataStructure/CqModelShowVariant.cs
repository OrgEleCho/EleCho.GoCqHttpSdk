using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqModelShowVariant
    {
        internal CqModelShowVariant(CqModelShowVariantModel model)
        {
            ModelShow = model.model_show;
            NeedPay = model.need_pay;
        }

        public CqModelShowVariant(string modelShow, bool needPay)
        {
            ModelShow = modelShow;
            NeedPay = needPay;
        }

        public string ModelShow { get; }
        public bool NeedPay { get; }
    }
}