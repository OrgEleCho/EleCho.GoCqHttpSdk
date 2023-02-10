using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 发送群聊消息操作
    /// </summary>
    public class CqSendGroupMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 发送群消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.SendGroupMessage;

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="message">消息</param>
        public CqSendGroupMessageAction(long groupId, CqMessage message)
        {
            GroupId = groupId;
            Message = message;
        }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public CqMessage Message { get; set; }


        /// <summary>
        /// 因为内部不使用 CQ 码, 所以该属性无用
        /// </summary>
        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel()
#pragma warning disable CS0618 // Type or member is obsolete
            => new CqSendGroupMessageActionParamsModel(GroupId, Message.Select(CqMsg.ToModel).ToArray(), AutoEscape);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}