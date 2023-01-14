
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMemberDecreasedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupDecrease;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long OperatorId { get; set; }

        internal CqGroupMemberDecreasedPostContext() { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupDecreasePostModel postModel)
                return;

            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            OperatorId = postModel.operator_id;
        }
    }
}