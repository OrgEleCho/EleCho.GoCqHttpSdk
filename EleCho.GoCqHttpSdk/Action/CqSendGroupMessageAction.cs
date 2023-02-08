using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendGroupMessageAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.SendGroupMessage;

        public CqSendGroupMessageAction(long groupId, CqMessage message)
        {
            GroupId = groupId;
            Message = message;
        }

        public long GroupId { get; set; }
        public CqMessage Message { get; set; }

        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel()
#pragma warning disable CS0618 // Type or member is obsolete
            => new CqSendGroupMessageActionParamsModel(GroupId, Message.Select(CqMsg.ToModel).ToArray(), AutoEscape);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}