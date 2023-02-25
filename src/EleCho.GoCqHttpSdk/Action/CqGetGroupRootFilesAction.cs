using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群根目录文件列表操作
    /// </summary>
    public class CqGetGroupRootFilesAction : CqAction
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        public CqGetGroupRootFilesAction(long groupId)
        {
            GroupId = groupId;
        }


        /// <summary>
        /// 操作类型: 获取群根目录文件列表
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupRootFiles;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupRootFilesActionParamsModel(GroupId);
        }
    }
}