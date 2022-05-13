namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeGroupCardPostModel : CqNoticePostModel
    {
        public override string notice_type => "group_card";

        public long group_id { get; set; }
        public long user_id { get; set; }
        public string card_new { get; set; }
        public string card_old { get; set; }
    }
}