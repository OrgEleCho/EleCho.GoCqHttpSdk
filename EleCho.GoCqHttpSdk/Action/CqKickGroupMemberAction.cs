using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 踢出群成员
    /// </summary>
    public class CqKickGroupMemberAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.KickGroupMember;

        public CqKickGroupMemberAction(long groupId, long userId, bool rejectRequest)
        {
            GroupId = groupId;
            UserId = userId;
            RejectRequest = rejectRequest;
        }

        /// <summary>
        /// 群 ID
        /// </summary>
        public long GroupId { get; set; }
        /// <summary>
        /// 用户 ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 拒绝该用户的加群请求
        /// </summary>
        public bool RejectRequest { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqKickGroupMemberActionParamsModel(GroupId, UserId, RejectRequest);
        }
    }
}