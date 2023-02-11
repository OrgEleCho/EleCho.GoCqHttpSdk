using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群昵称操作
    /// </summary>
    public class CqSetGroupNicknameAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="userId">用户 QQ</param>
        /// <param name="nickname">昵称</param>
        public CqSetGroupNicknameAction(long groupId, long userId, string? nickname)
        {
            GroupId = groupId;
            UserId = userId;
            Nickname = nickname;
        }

        /// <summary>
        /// 操作类型: 设置群昵称
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetGroupNickname;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? Nickname { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupNicknameActionParamsModel(GroupId, UserId, Nickname);
        }
    }
}
