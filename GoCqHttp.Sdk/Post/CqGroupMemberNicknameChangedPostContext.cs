
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员群昵称变更
    /// </summary>
    public class CqGroupMemberNicknameChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupCard;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string NewNickname { get; set; } = string.Empty;
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