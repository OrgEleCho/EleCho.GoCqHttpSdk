using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群文件链接操作
    /// </summary>
    public class CqGetGroupFileUrlAction : CqAction
    {
        /// <summary>
        /// 构造 "获取群文件连接操作"
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fileId"></param>
        /// <param name="busid"></param>
        public CqGetGroupFileUrlAction(long groupId, string fileId, int busid)
        {
            GroupId = groupId;
            FileId = fileId;
            Busid = busid;
        }

        /// <summary>
        /// 操作类型: 获取群文件链接
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupFileUrl;


        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 文件 ID
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int Busid { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupFileUrlActionParamsModel(GroupId, FileId, Busid);
        }
    }
}