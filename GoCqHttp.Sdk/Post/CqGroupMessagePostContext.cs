using EleCho.GoCqHttpSdk.DataStructure;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMessagePostContext : CqMessagePostContext
    {
        public override CqMessageType MessageType => CqMessageType.Group;

        public long GroupId { get; set; }
        public CqAnonymousInfomation? Anonymous { get; set; }
        public CqGroupMsgSender Sender { get; set; }

        internal CqGroupMessagePostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqGroupMessagePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            Anonymous = msgModel.anonymous == null ? null : new CqAnonymousInfomation(msgModel.anonymous);
            Sender = new CqGroupMsgSender(msgModel.sender);
        }
    }
}