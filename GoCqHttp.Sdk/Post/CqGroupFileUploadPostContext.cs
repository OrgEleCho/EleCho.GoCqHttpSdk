using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqGroupFileUploadPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public CqGroupUploadFilePostContext File { get; set; }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqNoticeGroupUploadPostModel noticeModel)
                return;

            noticeModel.group_id = GroupId;
            noticeModel.user_id = UserId;
            noticeModel.file = new CqGroupUploadFileModel(File);
        }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupUploadPostModel noticeModel)
                return;

            GroupId = noticeModel.group_id;
            UserId = noticeModel.user_id;
            File = new CqGroupUploadFilePostContext(noticeModel.file);
        }
    }
}
