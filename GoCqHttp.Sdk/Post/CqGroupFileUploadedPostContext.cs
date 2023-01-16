using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupFileUploadedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public CqGroupFile File { get; set; } = new CqGroupFile();
        
        internal CqGroupFileUploadedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupUploadPostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            File = new CqGroupFile(msgModel.file);
        }
    }
}