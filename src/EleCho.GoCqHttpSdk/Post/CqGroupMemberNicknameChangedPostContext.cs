
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员群昵称变更上报上下文
    /// </summary>
    public record class CqGroupMemberNicknameChangedPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupCard;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 新昵称
        /// </summary>
        public string NewNickname { get; set; } = string.Empty;

        /// <summary>
        /// 旧昵称
        /// </summary>
        public string OldNickname { get; set; } = string.Empty;
        
        internal CqGroupMemberNicknameChangedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupCardPostModel postModel)
                return;

            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            NewNickname = postModel.card_new;
            OldNickname = postModel.card_old;
        }
    }
}