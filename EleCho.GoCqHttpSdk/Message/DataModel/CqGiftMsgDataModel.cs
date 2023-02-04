#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqGiftMsgDataModel : CqMsgDataModel
    {
        public CqGiftMsgDataModel()
        { }

        public CqGiftMsgDataModel(long qq, int id)
        {
            this.qq = qq;
            this.id = id;
        }

        public long qq { get; set; }
        public int id { get; set; }

        public static CqGiftMsgDataModel FromCqCode(CqCode code)
        {
            return new CqGiftMsgDataModel(
                code.GetLong(nameof(qq)).GetValueOrDefault(0),
                code.GetInt(nameof(id)).GetValueOrDefault(0));
        }
    }
}