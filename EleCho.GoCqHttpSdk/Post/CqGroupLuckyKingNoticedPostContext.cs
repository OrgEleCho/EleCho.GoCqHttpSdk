
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群幸运王
    /// </summary>
    public class CqGroupLuckyKingNoticedPostContext : CqNotifyNoticePostContext
    {
        public override CqNotifyType NotifyType => CqNotifyType.LuckyKing;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long TargetId { get; set; }


        internal CqGroupLuckyKingNoticedPostContext() { }

        internal override object? QuickOperationModel => null;
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