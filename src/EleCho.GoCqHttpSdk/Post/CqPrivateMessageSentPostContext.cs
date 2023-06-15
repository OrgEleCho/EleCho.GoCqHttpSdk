using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 私聊消息上报上下文 (可能是好友, 也有可能是临时会话)
    /// </summary>
    public partial record class CqPrivateMessageSentPostContext : CqMessageSentPostContext
    {
        /// <summary>
        /// 消息类型: 私聊
        /// </summary>
        public override CqMessageType MessageType => CqMessageType.Private;

        /// <summary>
        /// 消息
        /// </summary>
        public CqPrivateMessageType PrivateMessageType { get; set; }

        /// <summary>
        /// 临时会话来源
        /// </summary>
        public CqTempSource TempSource { get; set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public CqMessageSender Sender { get; set; } = new CqMessageSender();

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqPrivateMessagePostModel msgModel)
                return;

            PrivateMessageType = CqEnum.GetPrivateMessageType(msgModel.sub_type);
            TempSource = (CqTempSource)msgModel.temp_source;
            Sender = new CqMessageSender(msgModel.sender);
        }
    }
}