
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群管理员变更
    /// </summary>
    public class CqGroupAdministratorChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupAdmin;

        public CqGroupAdminChangeType ChangeType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }

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