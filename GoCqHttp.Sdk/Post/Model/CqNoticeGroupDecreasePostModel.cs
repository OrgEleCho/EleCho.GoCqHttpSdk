namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeGroupDecreasePostModel : CqNoticePostModel
    {
        public override string notice_type => "group_decrease";

        public long group_id { get; set; }
        public long operator_id { get; set; }
        public long user_id { get; set; }
    }
}