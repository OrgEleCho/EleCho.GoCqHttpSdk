using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群文件上传上报上下文
    /// </summary>
    public class CqGroupFileUploadedPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 群文件上传
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 群文件
        /// </summary>
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