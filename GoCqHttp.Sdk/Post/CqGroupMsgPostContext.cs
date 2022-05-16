using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMsgPostContext : CqMsgPostContext
    {
        public override CqMessageType MessageType => CqMessageType.Group;

        public long GroupId { get; set; }
        public CqMessageAnonymous? Anonymous { get; set; }

        internal CqGroupMsgPostContext()
        { }

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