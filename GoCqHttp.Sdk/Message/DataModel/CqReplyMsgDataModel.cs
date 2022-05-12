namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqReplyMsgDataModel
    {
        internal CqReplyMsgDataModel() { }
        public CqReplyMsgDataModel(string id, string text, long qq, long time, long seq)
        {
            this.id = id;
            this.text = text;
            this.qq = qq;
            this.time = time;
            this.seq = seq;
        }

        public string id { get; set; }
        public string text { get; set; }
        public long qq { get; set; }
        public long time { get; set; }
        public long seq { get; set; }
    }
}
