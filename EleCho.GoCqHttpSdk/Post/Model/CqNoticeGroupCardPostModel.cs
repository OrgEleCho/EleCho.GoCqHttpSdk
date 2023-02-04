#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model
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