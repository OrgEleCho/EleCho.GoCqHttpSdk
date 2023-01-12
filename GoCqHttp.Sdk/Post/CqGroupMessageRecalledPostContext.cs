using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMessageRecalledPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupRecall;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long OperatorId { get; set; }
        public long MessageId { get; set; }

        internal CqGroupMessageRecalledPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupRecallPostModel postModel)
                return;

            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            OperatorId = postModel.operator_id;
            MessageId = postModel.message_id;
        }
    }
}