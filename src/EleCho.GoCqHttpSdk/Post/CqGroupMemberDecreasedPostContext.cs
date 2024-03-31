
using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员减少上报上下文
    /// </summary>
    public record class CqGroupMemberDecreasedPostContext : CqNoticePostContext, IGroupPostContext
    {
        /// <summary>
        /// 通知类型: 群成员减少
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupDecrease;

        /// <summary>
        /// 变更类型
        /// </summary>
        public CqGroupDecreaseChangeType ChangeType { get; private set; }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; private set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// 操作者 QQ
        /// </summary>
        public long OperatorId { get; private set; }

        internal CqGroupMemberDecreasedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupDecreasePostModel postModel)
                return;

            ChangeType = CqEnum.GetGroupDecreaseChangeType(postModel.sub_type);
            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            OperatorId = postModel.operator_id;
        }
    }
}