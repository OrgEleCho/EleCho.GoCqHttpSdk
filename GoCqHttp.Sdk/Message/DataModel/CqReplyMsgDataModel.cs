#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqReplyMsgDataModel : CqMsgDataModel
    {
        public CqReplyMsgDataModel()
        { }

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

        public static CqReplyMsgDataModel FromCqCode(CqCode code)
        {
            return new CqReplyMsgDataModel(
                code.GetString(nameof(id))!,
                code.GetString(nameof(text))!,
                code.GetLong(nameof(qq)).GetValueOrDefault(0),
                code.GetLong(nameof(time)).GetValueOrDefault(0),
                code.GetLong(nameof(seq)).GetValueOrDefault(0));
        }
    }
}