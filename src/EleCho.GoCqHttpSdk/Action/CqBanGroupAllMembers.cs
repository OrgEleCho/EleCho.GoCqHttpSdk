using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 群全体禁言操作
    /// </summary>
    public class CqBanGroupAllMembersAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="enable">是否启用禁言</param>
        public CqBanGroupAllMembersAction(long groupId, bool enable)
        {
            GroupId = groupId;
            Enable = enable;
        }

        /// <summary>
        /// 操作类型: 群全体禁言
        /// </summary>
        public override CqActionType ActionType => CqActionType.BanGroupAllMembers;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 是否启用禁言
        /// </summary>
        public bool Enable { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqBanGroupAllMembersActionParamsModel(GroupId, Enable);
        }
    }
}