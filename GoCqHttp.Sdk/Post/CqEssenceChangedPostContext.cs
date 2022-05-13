using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqEssenceChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.Essence;

        public CqNoticeEssenceType OperationType { get; set; }
        public long SenderId { get; set; }
        public long OperatorId { get; set; }
        public long MessageId { get; set; }

        internal CqNoticeEssenceType SubTypeFromString(string value)
        {
            return value switch
            {
                "add" => CqNoticeEssenceType.Add,
                "delete" => CqNoticeEssenceType.Delete,

                _ => CqNoticeEssenceType.Unknown
            };
        }

        internal string SubTypeToString(CqNoticeEssenceType value)
        {
            return value switch
            {
                CqNoticeEssenceType.Add => "add",
                CqNoticeEssenceType.Delete => "delete",

                _ => ""
            };
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeEssencePostModel noticeModel)
                return;

            OperationType = SubTypeFromString(noticeModel.sub_type);
            SenderId = noticeModel.sender_id;
            OperatorId = noticeModel.operator_id;
            MessageId = noticeModel.message_id;
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqNoticeEssencePostModel noticeModel)
                return;

            noticeModel.sub_type = SubTypeToString(OperationType);
            noticeModel.sender_id = SenderId;
            noticeModel.operator_id = OperatorId;
            noticeModel.message_id = MessageId;
        }
    }
}