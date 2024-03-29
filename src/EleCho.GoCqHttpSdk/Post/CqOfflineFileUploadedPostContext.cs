using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 离线文件上传
    /// </summary>
    public record class CqOfflineFileUploadedPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 离线文件上传
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.OfflineFile;

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; internal set; }

        /// <summary>
        /// 离线文件
        /// </summary>
        public CqOfflineFile File { get; internal set; } = new CqOfflineFile();
        
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