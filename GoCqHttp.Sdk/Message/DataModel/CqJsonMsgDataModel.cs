#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqJsonMsgDataModel : CqMsgDataModel
    {
        public string data { get; set; }
        public int resid { get; set; }

        internal CqJsonMsgDataModel()
        { }

        public CqJsonMsgDataModel(string data, int resid)
        {
            this.data = data;
            this.resid = resid;
        }

        public static CqJsonMsgDataModel FromCqCode(CqCode code)
        {
            return new CqJsonMsgDataModel(
                code.GetString(nameof(data))!,
                code.GetInt(nameof(resid)).GetValueOrDefault(0));
        }
    }
}