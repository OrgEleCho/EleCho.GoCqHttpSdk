using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqPrivateMsgPostContext : CqMsgPostContext
    {
        public override CqMessageType MessageType => CqMessageType.Private;
        public CqMessagePrivateType MessageSubType { get; set; }
        public CqTempSource TempSource { get; set; }

        internal CqPrivateMsgPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqPrivateMessagePostModel msgModel)
                return;

            MessageSubType = CqEnum.GetMessagePrivateType(msgModel.sub_type);
            TempSource = (CqTempSource)msgModel.temp_source;
        }
    }

    
}