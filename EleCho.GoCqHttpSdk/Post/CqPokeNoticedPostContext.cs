
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 戳一戳上报上下文 (如果是群聊, 那么 GroupId 不为空)
    /// </summary>
    public class CqPokedPostContext : CqNotifyNoticePostContext
    {
        /// <summary>
        /// 通知类型: 戳一戳
        /// </summary>
        public override CqNotifyType NotifyType => CqNotifyType.Poke;

        /// <summary>
        /// 群号
        /// </summary>
        public long? GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 发送者 QQ
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// 目标 QQ
        /// </summary>
        public long TargetId { get; set; }

        internal CqPokedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticePokePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            SenderId = msgModel.sender_id;
            TargetId = msgModel.target_id;
        }
    }
}