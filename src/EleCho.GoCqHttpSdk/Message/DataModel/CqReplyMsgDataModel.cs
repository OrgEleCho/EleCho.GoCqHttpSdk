#pragma warning disable CS8618


namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqReplyMsgDataModel : CqMsgDataModel
    {
        public CqReplyMsgDataModel()
        { }

        public CqReplyMsgDataModel(long id, string text, long qq, long time, long seq)
        {
            this.id = id;
            this.text = text;
            this.qq = qq;
            this.time = time;
            this.seq = seq;
        }

        public long id { get; set; }
        public string text { get; set; }
        public long qq { get; set; }
        public long time { get; set; }
        public long seq { get; set; }

        public static CqReplyMsgDataModel FromCqCode(CqCode code)
        {
            return new CqReplyMsgDataModel(
                code.GetLong(nameof(id)).GetValueOrDefault(0),
                code.GetString(nameof(text)) ?? string.Empty,
                code.GetLong(nameof(qq)).GetValueOrDefault(0),
                code.GetLong(nameof(time)).GetValueOrDefault(0),
                code.GetLong(nameof(seq)).GetValueOrDefault(0));
        }
    }
}