using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupAdminChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupAdmin;

        public CqGroupAdminChangeType ChangeType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }

        internal CqGroupAdminChangedPostContext()
        { }

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