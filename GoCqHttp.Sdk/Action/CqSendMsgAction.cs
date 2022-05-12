using NullLib.GoCqHttpSdk.Action.Model.Params;
using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Action
{
    public class CqSendMsgAction : CqAction
    {
        public override string Type => Consts.ActionType.SendMsg;

        internal override CqActionParamsModel GetParamsModel() => throw new NotImplementedException();
    }
}