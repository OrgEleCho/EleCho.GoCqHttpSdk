using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqLuckyKingNoticedPostContext : CqNotifyNoticePostContext
    {
        public override CqNotifyType NotifyType => CqNotifyType.LuckyKing;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long TargetId { get; set; }


        internal CqLuckyKingNoticedPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeLuckyKingPostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            TargetId = msgModel.target_id;
        }
    }
}