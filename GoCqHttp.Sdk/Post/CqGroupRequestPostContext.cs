using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupRequestPostContext : CqRequestPostContext
    {
        public override CqRequestType RequestType => CqRequestType.Group;

        internal CqGroupRequestPostContext()
        { }

        public CqGroupRequestType RequestSubType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
        public string Flag { get; set; }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqRequestGroupPostModel requestModel)
                return;

            RequestSubType = CqEnum.GetGroupRequestType(requestModel.sub_type);
            GroupId = requestModel.group_id;
            UserId = requestModel.user_id;
            Comment = requestModel.comment;
            Flag = requestModel.flag;
        }
    }
}