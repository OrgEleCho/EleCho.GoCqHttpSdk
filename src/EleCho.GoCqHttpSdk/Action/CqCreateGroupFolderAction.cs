using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 创建群文件文件夹操作
    /// </summary>
    public class CqCreateGroupFolderAction : CqAction
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="name"></param>
        public CqCreateGroupFolderAction(long groupId, string name)
        {
            GroupId = groupId;
            Name = name;
        }

        /// <summary>
        /// 操作类型: 创建群文件夹
        /// </summary>
        public override CqActionType ActionType => CqActionType.CreateGroupFolder;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件夹父 ID (仅能为 / )
        /// </summary>
        public string Parent { get; set; } = "/";

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqCreateGroupFolderParamsModel(GroupId, Name, Parent);
        }
    }
}