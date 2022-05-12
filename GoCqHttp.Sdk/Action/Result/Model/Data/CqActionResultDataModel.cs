using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Action.Result.Model.Data
{
    internal class CqActionResultDataModel
    {
        internal static CqActionResultDataModel? FromRaw(JsonElement? data, string actionType)
        {
            if (data == null)
                return null;

            JsonElement dataValue = data.Value;
            return actionType switch
            {
                Consts.ActionType.SendPrivateMsg => dataValue.ToObject<CqSendPrivateMsgActionResultDataModel>(null),
                Consts.ActionType.SendGroupMsg => dataValue.ToObject<CqSendGroupMsgActionResultDataModel>(null),

                _ => null
            };
        }
    }
}
