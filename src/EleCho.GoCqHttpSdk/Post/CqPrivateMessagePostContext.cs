using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 私聊消息上报上下文 (可能是好友, 也有可能是临时会话)
    /// </summary>
    public partial record class CqPrivateMessagePostContext : CqMessagePostContext
    {
        /// <summary>
        /// 消息类型: 私聊
        /// </summary>
        public override CqMessageType MessageType => CqMessageType.Private;

        /// <summary>
        /// 消息
        /// </summary>
        public CqPrivateMessageType PrivateMessageType { get; internal set; }

        /// <summary>
        /// 临时会话来源
        /// </summary>
        public CqTempSource TempSource { get; internal set; }
        
        internal CqPrivateMessagePostContext() { }

        /// <summary>
        /// 快速操作
        /// </summary>
        public CqPrivateMessagePostQuickOperation QuickOperation { get; }
            = new CqPrivateMessagePostQuickOperation();

        internal override object? QuickOperationModel => QuickOperation.GetModel();
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