using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqUploadGroupFileAction : CqAction
    {
        public CqUploadGroupFileAction(long groupId, string file, string name)
        {
            GroupId = groupId;
            File = file;
            Name = name;
        }

        public CqUploadGroupFileAction(long groupId, string file, string name, string folder)
        {
            GroupId = groupId;
            File = file;
            Name = name;
            Folder = folder;
        }

        public override CqActionType ActionType => CqActionType.UploadGroupFile;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 本地文件路径
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// 存储名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父目录 ID
        /// </summary>
        public string? Folder { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqUploadGroupFileActionParamsModel(GroupId, File, Name, Folder);
        }
    }
}