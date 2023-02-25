using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群子目录文件列表操作
    /// </summary>
    public class CqGetGroupFilesByFolderAction : CqAction
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="folderId"></param>
        public CqGetGroupFilesByFolderAction(long groupId, string folderId)
        {
            GroupId = groupId;
            FolderId = folderId;
        }

        /// <summary>
        /// 操作类型: 获取群子目录文件列表
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupFilesByFolder;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 目录 ID
        /// </summary>
        public string FolderId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupFilesByFolderActionParamsModel(GroupId, FolderId);
        }
    }
}