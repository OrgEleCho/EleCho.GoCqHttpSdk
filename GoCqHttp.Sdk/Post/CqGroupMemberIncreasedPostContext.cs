
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMemberIncreasedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupIncrease;

        public CqGroupIncreaseChangeType ChangeType { get; set; }

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long OperatorId { get; set; }

        internal CqGroupMemberIncreasedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupIncreasePostModel postModel)
                return;

            ChangeType = CqEnum.GetGroupIncreaseChangeType(postModel.sub_type);
            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            OperatorId = postModel.operator_id;
        }
    }
}