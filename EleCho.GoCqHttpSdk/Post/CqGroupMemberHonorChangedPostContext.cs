
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员群荣誉变更上报上下文
    /// </summary>
    public class CqGroupMemberHonorChangedPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 上报类型: 通知
        /// </summary>
        public override CqPostType PostType => CqPostType.Notice;

        /// <summary>
        /// 通知类型: 通知
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.Notify;

        /// <summary>
        /// 群荣誉类型
        /// </summary>
        public CqHonorType HonorType { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
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