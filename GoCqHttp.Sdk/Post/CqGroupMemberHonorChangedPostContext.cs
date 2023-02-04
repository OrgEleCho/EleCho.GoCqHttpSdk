
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员群荣誉变更
    /// </summary>
    public class CqGroupMemberHonorChangedPostContext : CqNoticePostContext
    {
        public override CqPostType EventType => CqPostType.Notice;
        public override CqNoticeType NoticeType => CqNoticeType.Notify;

        public CqHonorType HonorType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }

        internal CqGroupMemberHonorChangedPostContext() { }

        internal override object? QuickOperationModel => null;


        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeHonorPostModel msgModel)
                return;

            HonorType = CqEnum.GetHonorType(msgModel.honor_type);
            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
        }
    }
}