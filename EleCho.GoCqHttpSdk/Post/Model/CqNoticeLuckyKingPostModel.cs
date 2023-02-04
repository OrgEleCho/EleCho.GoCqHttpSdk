#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeLuckyKingPostModel : CqNoticeNotifyPostModel
    {
        public override string sub_type => "lucky_king";

        public long group_id { get; set; }
        public long user_id { get; set; }
        public long target_id { get; set; }
    }
}