using EleCho.GoCqHttpSdk.Message.DataModel;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal abstract class CqMessagePostModel : CqPostModel
    {
        public override string post_type => "message";
        public abstract string message_type { get; }

        public string sub_type { get; set; }
        public int message_id { get; set; }
        public long user_id { get; set; }
        public CqMsgModel[] message { get; set; }
        public string raw_message { get; set; }
        public int font { get; set; }
    }
}