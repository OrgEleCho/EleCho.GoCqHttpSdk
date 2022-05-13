using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Action.Result.Model.Data;
using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Action.Result
{
    public abstract class CqActionResult
    {
        public CqActionStatus Status { get; set; }
        public CqActionRetCode RetCode { get; set; }
        public string? EchoData { get; set; }

        internal abstract void ReadDataModel(CqActionResultDataModel? model);

        internal static CqActionResult? FromRaw(CqActionResultRaw? raw, string actionType)
        {
            if (raw == null)
                return null;

            CqActionResultDataModel? dataModel = CqActionResultDataModel.FromRaw(raw.data, actionType);
            CqActionResult rst = actionType switch
            {
                Consts.ActionType.SendPrivateMsg => new CqSendPrivateMsgActionResult(),
                Consts.ActionType.SendGroupMsg => new CqSendGroupMsgActionResult(),
                Consts.ActionType.SendMsg => new CqSendMsgActionResult(),
                Consts.ActionType.DeleteMsg => new CqDeleteMsgActionResult(),

                _ => throw new ArgumentException("Invalid action type", nameof(actionType))
            };

            rst.Status = CqEnum.GetActionStatus(raw.status);
            rst.RetCode = (CqActionRetCode)raw.retcode;
            rst.EchoData = raw.echo;

            rst.ReadDataModel(dataModel);

            return rst;
        }
    }
}