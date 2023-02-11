using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 发送群转发消息操作
    /// </summary>
    public class CqSendGroupForwardMessageAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        public CqSendGroupForwardMessageAction(long groupId, CqForwardMessage messages)
        {
            GroupId = groupId;
            ForwardMessage = messages;
        }

        /// <summary>
        /// 操作类型: 发送群转发消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.SendGroupForwardMessage;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 转发消息
        /// </summary>
        public CqForwardMessage ForwardMessage { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendGroupForwardMessageActionParamsModel(GroupId, ForwardMessage.Select(CqMsg.ToModel).ToArray());
        }
    }
}