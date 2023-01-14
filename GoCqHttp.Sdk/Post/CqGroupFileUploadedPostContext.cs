using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupFileUploadedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public CqGroupFile File { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CqGroupFileUploadedPostContext() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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