
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqFriendRequestPostContext : CqRequestPostContext
    {
        public override CqRequestType RequestType => CqRequestType.Friend;

        public long UserId { get; set; }
        public string Comment { get; set; }
        public string Flag { get; set; }

        internal CqFriendRequestPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqRequestFriendPostModel requestModel)
                return;

            UserId = requestModel.user_id;
            Comment = requestModel.comment;
            Flag = requestModel.flag;
        }
    }
}