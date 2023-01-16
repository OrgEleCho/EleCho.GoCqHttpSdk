using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public partial class CqPrivateMessagePostContext : CqMessagePostContext
    {
        public override CqMessageType MessageType => CqMessageType.Private;
        public CqMessagePrivateType MessageSubType { get; set; }
        public CqTempSource TempSource { get; set; }
        public CqMessageSender Sender { get; set; } = new CqMessageSender();
        
        internal CqPrivateMessagePostContext() { }

        public CqPrivateMessagePostQuickOperation QuickOperation { get; }
            = new CqPrivateMessagePostQuickOperation();

        internal override object? QuickOperationModel => QuickOperation.GetModel();
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqPrivateMessagePostModel msgModel)
                return;

            MessageSubType = CqEnum.GetMessagePrivateType(msgModel.sub_type);
            TempSource = (CqTempSource)msgModel.temp_source;
            Sender = new CqMessageSender(msgModel.sender);
        }
    }
}