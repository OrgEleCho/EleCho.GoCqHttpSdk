using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 上传私聊文件操作
    /// </summary>
    public class CqUploadPrivateFileAction : CqAction
    {
        /// <summary>
        /// 构建 '上传私聊文件操作'
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <param name="name"></param>
        public CqUploadPrivateFileAction(long userId, string file, string name)
        {
            UserId = userId;
            File = file;
            Name = name;
        }

        /// <summary>
        /// 操作类型: 上传私聊文件
        /// </summary>
        public override CqActionType ActionType => CqActionType.UploadPrivateFile;

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqUploadPrivateFileActionParamsModel(UserId, File, Name);
        }
    }
}