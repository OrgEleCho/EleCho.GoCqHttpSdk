
using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群管理员变更上报上下文
    /// </summary>
    public record class CqGroupAdministratorChangedPostContext : CqNoticePostContext, IGroupPostContext
    {
        /// <summary>
        /// 通知类型: 群管理员
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupAdmin;

        /// <summary>
        /// 变更类型
        /// </summary>
        public CqGroupAdminChangeType ChangeType { get; internal set; }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; internal set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; internal set; }

        internal CqGroupAdministratorChangedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupAdminPostModel postModel)
                return;

            ChangeType = CqEnum.GetGroupAdminChangeType(postModel.sub_type);
            GroupId = postModel.group_id;
            UserId = postModel.user_id;
        }
    }
}