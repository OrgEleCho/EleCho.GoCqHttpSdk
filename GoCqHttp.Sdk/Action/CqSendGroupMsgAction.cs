using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendGroupMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.SendGroupMessage;

        public CqSendGroupMsgAction(long groupId, CqMsg[] message)
        {
            GroupId = groupId;
            Message = message;
        }

        public long GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel() => new CqSendGroupMsgActionParamsModel(GroupId, Array.ConvertAll(Message ?? Array.Empty<CqMsg>(), CqMsg.ToModel), AutoEscape);
    }
}