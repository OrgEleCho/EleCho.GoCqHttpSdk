
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqPokedPostContext : CqNotifyNoticePostContext
    {
        public override CqNotifyType NotifyType => CqNotifyType.Poke;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long SenderId { get; set; }
        public long TargetId { get; set; }

        internal CqPokedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticePokePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            SenderId = msgModel.sender_id;
            TargetId = msgModel.target_id;
        }
    }
}