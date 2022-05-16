using EleCho.GoCqHttpSdk.Message.CqCodeDef;

#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqRedEnvelopeMsgDataModel : CqMsgDataModel
    {
        public string title { get; set; }

        public CqRedEnvelopeMsgDataModel()
        { }

        public CqRedEnvelopeMsgDataModel(string title) => this.title = title;

        public static CqRedEnvelopeMsgDataModel FromCqCode(CqCode code)
        {
            return new CqRedEnvelopeMsgDataModel(
                code.GetString(nameof(title))!);
        }
    }
}