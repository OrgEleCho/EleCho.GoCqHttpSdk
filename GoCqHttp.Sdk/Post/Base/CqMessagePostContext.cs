using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqMsgPostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Message;
        public abstract CqMessageType MessageType { get; }

        public int MessageId { get; set; }
        public long UserId { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }
        public int Font { get; set; }
        public CqMsgSender Sender { get; set; }

        internal CqMsgPostContext()
        { }

        protected CqMsgPostContext(int messageId, long userId, CqMsg[] message, string rawMessage, int font, CqMsgSender sender)
        {
            MessageId = messageId;
            UserId = userId;
            Message = message;
            RawMessage = rawMessage;
            Font = font;
            Sender = sender;
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMessagePostModel msgModel)
                return;

            MessageId = msgModel.message_id;
            UserId = msgModel.user_id;
            Message = Array.ConvertAll(msgModel.message ?? Array.Empty<CqMsgModel>(), CqMsg.FromModel);
            RawMessage = msgModel.raw_message;
            Font = msgModel.font;
            Sender = new CqMsgSender(msgModel.sender);
        }
    }
}