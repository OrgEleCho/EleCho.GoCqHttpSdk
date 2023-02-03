using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal class CqModelShowVariantModel
    {
        public CqModelShowVariantModel(CqModelShowVariant srcData)
        {
            model_show = srcData.ModelShow;
            need_pay = srcData.NeedPay;
        }

        [JsonConstructor]
        public CqModelShowVariantModel(string model_show, bool need_pay)
        {
            this.model_show = model_show;
            this.need_pay = need_pay;
        }
        public string model_show { get; set; }
        public bool need_pay { get; set; }
    }
}