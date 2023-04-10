
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群幸运王通知上下文
    /// </summary>
    public record class CqGroupLuckyKingNoticedPostContext : CqNotifyNoticePostContext
    {
        /// <summary>
        /// 通知类型: 幸运王
        /// </summary>
        public override CqNotifyType NotifyType => CqNotifyType.LuckyKing;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ (红包发送者 QQ)
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 目标 QQ (运气王 QQ)
        /// </summary>
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