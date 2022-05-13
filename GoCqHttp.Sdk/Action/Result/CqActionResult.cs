using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Action.Result.Model.Data;
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

                _ => throw new ArgumentException("Invalid action type", nameof(actionType))
            };

            rst.ReadDataModel(dataModel);

            return rst;
        }
    }
}