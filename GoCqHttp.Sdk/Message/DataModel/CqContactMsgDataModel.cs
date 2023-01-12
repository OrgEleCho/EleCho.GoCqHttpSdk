#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqContactMsgDataModel : CqMsgDataModel
    {
        public CqContactMsgDataModel()
        {
        }

        public CqContactMsgDataModel(string type, long id)
        {
            this.type = type;
            this.id = id;
        }

        public string type { get; set; }
        public long id { get; set; }

        public static CqContactMsgDataModel FromCqCode(CqCode code)
        {
            return new CqContactMsgDataModel(
                code.GetString(nameof(type))!,
                code.GetLong(nameof(id)).GetValueOrDefault(0));
        }
    }
}