using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupRequestPostContext : CqRequestPostContext
    {
        public override CqRequestType RequestType => CqRequestType.Group;

        internal CqGroupRequestPostContext() { }

        public CqGroupRequestType SubRequestType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;

        public CqGroupRequestPostQuickOperation QuickOperation { get; }
            = new CqGroupRequestPostQuickOperation();

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqRequestGroupPostModel requestModel)
                return;

            SubRequestType = CqEnum.GetGroupRequestType(requestModel.sub_type);
            GroupId = requestModel.group_id;
            UserId = requestModel.user_id;
            Comment = requestModel.comment;
            Flag = requestModel.flag;
        }
    }
}