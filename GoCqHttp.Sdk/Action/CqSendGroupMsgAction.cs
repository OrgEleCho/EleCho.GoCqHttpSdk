using NullLib.GoCqHttpSdk.Action.Model.Params;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Action
{
    public class CqSendGroupMsgAction : CqAction
    {
        public override string Type => Consts.ActionType.SendGroupMsg;

        public CqSendGroupMsgAction(long groupId, CqMsg[] message)
        {
            GroupId = groupId;
            Message = message;
        }

        public long GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel() => new CqSendGroupMsgActionParamsModel(GroupId, Array.ConvertAll(Message, CqMsg.ToModel), AutoEscape);
    }
}
