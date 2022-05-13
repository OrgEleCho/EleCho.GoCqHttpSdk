#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqTextMsgDataModel : CqMsgDataModel
    {
        public string text { get; set; }

        public CqTextMsgDataModel()
        { }

        public CqTextMsgDataModel(string text)
        {
            this.text = text;
        }

        public static CqTextMsgDataModel FromCqCode(CqCode code)
        {
            return new CqTextMsgDataModel(
                code.GetString(nameof(text))!);
        }
    }
}