using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqPrivateMessagePostContext : CqMessagePostContext
    {
        public override CqMessageType MessageType => CqMessageType.Private;
        public CqMessagePrivateType MessageSubType { get; set; }
        public CqTempSource TempSource { get; set; }
        public CqMessageSender Sender { get; set; }

        internal CqPrivateMessagePostContext()
        { }

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