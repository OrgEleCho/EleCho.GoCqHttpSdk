
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员增加上报上下文
    /// </summary>
    public class CqGroupMemberIncreasedPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 群成员增加
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupIncrease;

        /// <summary>
        /// 变更类型
        /// </summary>
        public CqGroupIncreaseChangeType ChangeType { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 操作者 QQ
        /// </summary>
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