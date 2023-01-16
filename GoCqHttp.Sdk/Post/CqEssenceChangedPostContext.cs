
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqEssenceChangedPostContext : CqNoticePostContext
    {
        internal CqEssenceChangedPostContext() { }

        public override CqNoticeType NoticeType => CqNoticeType.Essence;

        public CqEssenceChangeType ChangeType { get; set; }
        public long SenderId { get; set; }
        public long OperatorId { get; set; }
        public long MessageId { get; set; }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeEssencePostModel noticeModel)
                return;

            ChangeType = CqEnum.GetEssenceChangeType(noticeModel.sub_type);
            SenderId = noticeModel.sender_id;
            OperatorId = noticeModel.operator_id;
            MessageId = noticeModel.message_id;
        }
    }
}