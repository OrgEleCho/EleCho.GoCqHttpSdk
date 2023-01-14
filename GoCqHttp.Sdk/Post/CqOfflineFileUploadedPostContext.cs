using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqOfflineFileUploadedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.OfflineFile;

        public long UserId { get; set; }
        public CqOfflineFile File { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CqOfflineFileUploadedPostContext() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeOfflineFilePostModel postModel)
                return;

            UserId = postModel.user_id;
            File = new CqOfflineFile(postModel.file);
        }
    }
}