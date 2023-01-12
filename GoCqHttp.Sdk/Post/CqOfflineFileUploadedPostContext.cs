using EleCho.GoCqHttpSdk.DataStructure;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqOfflineFileUploadedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.OfflineFile;

        public long UserId { get; set; }
        public CqOfflineFile File { get; set; }

        internal CqOfflineFileUploadedPostContext()
        { }

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