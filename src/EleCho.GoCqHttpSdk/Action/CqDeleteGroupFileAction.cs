using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 删除群文件操作
    /// </summary>
    public class CqDeleteGroupFileAction : CqAction
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fileId"></param>
        /// <param name="busid"></param>
        public CqDeleteGroupFileAction(long groupId, string fileId, int busid)
        {
            GroupId = groupId;
            FileId = fileId;
            Busid = busid;
        }

        /// <summary>
        /// 操作类型: 删除群文件
        /// </summary>
        public override CqActionType ActionType => CqActionType.DeleteGroupFile;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 文件 ID, 参考 <see cref="CqGroupFile"/>
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件类型, 参考 <see cref="CqGroupFile"/>
        /// </summary>
        public int Busid { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteGroupFileActionParamsModel(GroupId, FileId, Busid);
        }
    }
}