using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqPrivateMsgPostContext : CqMsgPostContext
    {
        public override CqMessageType MessageType => CqMessageType.Private;
        public CqMessagePrivateType MessageSubType { get; set; }
        public CqTempSourceType TempSource { get; set; }


        internal CqPrivateMsgPostContext() { }

        internal static CqMessagePrivateType SubTypeFromString(string str)
        {
            return str switch
            {
                "friend" => CqMessagePrivateType.Friend,
                "group" => CqMessagePrivateType.Group,
                "group_self" => CqMessagePrivateType.GroupSelf,
                "other" => CqMessagePrivateType.Other,

                _ => CqMessagePrivateType.Unknown
            };
        }
        internal static string SubTypeToString(CqMessagePrivateType subType)
        {
            return subType switch
            {
                CqMessagePrivateType.Friend => "friend",
                CqMessagePrivateType.Group => "group",
                CqMessagePrivateType.GroupSelf => "group_self",
                CqMessagePrivateType.Other => "other",

                _ => "unknown"
            };
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqPrivateMessagePostModel msgModel)
                return;

            MessageSubType = SubTypeFromString(msgModel.sub_type);
            TempSource = (CqTempSourceType)int.Parse(msgModel.temp_source);
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqPrivateMessagePostModel msgModel)
                return;

            msgModel.sub_type = SubTypeToString(MessageSubType);
            msgModel.temp_source = ((int)TempSource).ToString();
        }
    }
}
