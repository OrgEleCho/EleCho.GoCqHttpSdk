
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员头衔变更上报上下文
    /// </summary>
    public class CqGroupMemberTitleChangeNoticedPostContext : CqNotifyNoticePostContext
    {
        /// <summary>
        /// 通知类型: 群成员头衔
        /// </summary>
        public override CqNotifyType NotifyType => CqNotifyType.Title;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 新荣誉
        /// </summary>
        public string NewTitle { get; set; } = string.Empty;

        internal override object? QuickOperationModel => null;

        internal CqGroupMemberTitleChangeNoticedPostContext() { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if(model is not CqNoticeTitlePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            NewTitle = msgModel.title;
        }
    }
}
