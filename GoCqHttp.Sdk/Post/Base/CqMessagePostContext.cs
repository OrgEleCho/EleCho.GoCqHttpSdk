using EleCho.GoCqHttpSdk.DataStructure;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqMessagePostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Message;
        public abstract CqMessageType MessageType { get; }

        public long MessageId { get; set; }
        public long UserId { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }
        public int Font { get; set; }

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
        }
    }
}