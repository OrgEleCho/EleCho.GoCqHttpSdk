using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群文件系统信息操作
    /// </summary>
    public class CqGetGroupFileSystemInformationAction : CqAction
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        public CqGetGroupFileSystemInformationAction(long groupId)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// 操作类型: 获取群文件系统信息
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupFileSystemInformation;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupFileSystemInformationActionParamsModel(GroupId);
        }
    }
}