using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqGroupRequestPostContext : CqRequestPostContext
    {
        public override CqRequestType RequestType => CqRequestType.Group;

        internal CqGroupRequestPostContext()
        { }

        public CqRequestGroupType RequestSubType { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
        public string Flag { get; set; }

        internal static CqRequestGroupType SubTypeFromString(string str)
        {
            return str switch
            {
                "add" => CqRequestGroupType.Add,
                "invite" => CqRequestGroupType.Invite,

                _ => CqRequestGroupType.Unknown
            };
        }

        internal static string SubTypeToString(CqRequestGroupType type)
        {
            return type switch
            {
                CqRequestGroupType.Add => "add",
                CqRequestGroupType.Invite => "invite",

                _ => "unknown"
            };
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqRequestGroupPostModel requestModel)
                return;

            RequestSubType = SubTypeFromString(requestModel.sub_type);
            GroupId = requestModel.group_id;
            UserId = requestModel.user_id;
            Comment = requestModel.comment;
            Flag = requestModel.flag;
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqRequestGroupPostModel requestModel)
                return;

            requestModel.sub_type = SubTypeToString(RequestSubType);
            requestModel.group_id = GroupId;
            requestModel.user_id = UserId;
            requestModel.comment = Comment;
            requestModel.flag = Flag;
        }
    }
}