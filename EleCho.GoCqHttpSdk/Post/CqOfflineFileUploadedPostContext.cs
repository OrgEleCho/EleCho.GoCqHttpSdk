using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 离线文件上传
    /// </summary>
    public class CqOfflineFileUploadedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.OfflineFile;

        public long UserId { get; set; }
        public CqOfflineFile File { get; set; } = new CqOfflineFile();
        
        internal CqOfflineFileUploadedPostContext() { }

        internal override object? QuickOperationModel => null;
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