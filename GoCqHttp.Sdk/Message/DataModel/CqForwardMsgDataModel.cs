using EleCho.GoCqHttpSdk.Message.CqCodeDef;

#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqForwardMsgDataModel : CqMsgDataModel
    {
        public string id { get; set; }

        public CqForwardMsgDataModel()
        { }

        public CqForwardMsgDataModel(string id) => this.id = id;

        public static CqForwardMsgDataModel FromCqCode(CqCode code)
        {
            return new CqForwardMsgDataModel(code.GetString(nameof(id))!);
        }
    }
}