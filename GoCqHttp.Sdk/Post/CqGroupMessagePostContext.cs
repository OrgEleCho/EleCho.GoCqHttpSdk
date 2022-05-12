using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqGroupMsgPostContext : CqMsgPostContext
    {
        public override CqMessageType MessageType => CqMessageType.Group;

        public long GroupId { get; set; }
        public CqMessageAnonymous? Anonymous { get; set; }

        internal CqGroupMsgPostContext() { }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqGroupMessagePostModel msgModel)
                return;
            
            msgModel.group_id = GroupId;
            msgModel.anonymous = Anonymous == null ? null : new CqMessageAnonymousModel(Anonymous);
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqGroupMessagePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            Anonymous = msgModel.anonymous == null ? null : new CqMessageAnonymous(msgModel.anonymous);
        }
    }
}
