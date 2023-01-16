
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMemberCardChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupCard;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string NewCard { get; set; } = string.Empty;
        public string OldCard { get; set; } = string.Empty;
        
        internal CqGroupMemberCardChangedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupCardPostModel postModel)
                return;

            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            NewCard = postModel.card_new;
            OldCard = postModel.card_old;
        }
    }
}