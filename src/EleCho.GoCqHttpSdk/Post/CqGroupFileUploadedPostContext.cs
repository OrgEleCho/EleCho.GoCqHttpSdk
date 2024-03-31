using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群文件上传上报上下文
    /// </summary>
    public record class CqGroupFileUploadedPostContext : CqNoticePostContext, IGroupPostContext
    {
        /// <summary>
        /// 通知类型: 群文件上传
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; internal set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; internal set; }
        
        /// <summary>
        /// 群文件
        /// </summary>
        public CqGroupUploadedFile File { get; internal set; } = new CqGroupUploadedFile();
        
        internal CqGroupFileUploadedPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupUploadPostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            File = new CqGroupUploadedFile(msgModel.file);
        }
    }
}