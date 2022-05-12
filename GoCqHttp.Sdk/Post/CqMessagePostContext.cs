using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Post.Model;
using System;

namespace NullLib.GoCqHttpSdk.Post
{
    public abstract class CqMessagePostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Message;
        public abstract CqMessageType MessageType { get; }

        public int MessageId { get; set; }
        public long UserId { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }
        public int Font { get; set; }
        public CqMessageSender Sender { get; set; }

        internal CqMessagePostContext() { }

        protected CqMessagePostContext(int messageId, long userId, CqMsg[] message, string rawMessage, int font, CqMessageSender sender)
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
            Message = Array.ConvertAll(msgModel.message, CqMsg.FromModel);
            RawMessage = msgModel.raw_message;
            Font = msgModel.font;
            Sender = new CqMessageSender(msgModel.sender);
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqMessagePostModel msgModel)
                return;

            msgModel.message_id = MessageId;
            msgModel.user_id = UserId;
            msgModel.message = Array.ConvertAll(Message, CqMsg.ToModel);
            msgModel.raw_message = RawMessage;
            msgModel.font = Font;
            msgModel.sender = new CqMessageSenderModel(Sender);
        }
    }
}
