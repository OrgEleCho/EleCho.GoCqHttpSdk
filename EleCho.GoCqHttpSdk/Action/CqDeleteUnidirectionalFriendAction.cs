using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 删除单向好友操作
    /// </summary>
    public class CqDeleteUnidirectionalFriendAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="userId">用户 QQ</param>
        public CqDeleteUnidirectionalFriendAction(long userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// 操作类型: 删除单向好友
        /// </summary>
        public override CqActionType ActionType => CqActionType.DeleteUnidirectionalFriend;

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteUnidirectionalFriendActionParamsModel(UserId);
        }
    }
}
