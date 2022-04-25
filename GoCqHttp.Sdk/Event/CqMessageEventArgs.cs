using NullLib.GoCqHttpSdk.Message;

namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqMessageEventArgs : CqEventArgs
    {
        public override CqEventType EventType => CqEventType.Message;
        public abstract CqMessageType MessageType { get; }

        public int MessageId { get; set; }
        public long UserId { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }
        public int Font { get; set; }
        public CqMessageSender Sender { get; set; }

        internal CqMessageEventArgs() { }

        protected CqMessageEventArgs(int messageId, long userId, CqMsg[] message, string rawMessage, int font, CqMessageSender sender)
        {
            MessageId = messageId;
            UserId = userId;
            Message = message;
            RawMessage = rawMessage;
            Font = font;
            Sender = sender;
        }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqMessageEventModel msgModel)
                return;

            MessageId = msgModel.message_id;
            UserId = msgModel.user_id;
            Message = CqMsg.FromModel(msgModel.message);
            RawMessage = msgModel.raw_message;
            Font = msgModel.font;
            Sender = new CqMessageSender(msgModel.sender);
        }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqMessageEventModel msgModel)
                return;

            msgModel.message_id = MessageId;
            msgModel.user_id = UserId;
            msgModel.message = CqMsg.ToModel(Message);
            msgModel.raw_message = RawMessage;
            msgModel.font = Font;
            msgModel.sender = new CqMessageSenderModel(Sender);
        }
    }
}
