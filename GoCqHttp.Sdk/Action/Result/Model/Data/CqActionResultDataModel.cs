using NullLib.GoCqHttpSdk.Util;
using System.Text.Json;

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
                Consts.ActionType.SendPrivateMsg => JsonSerializer.Deserialize<CqSendPrivateMsgActionResultDataModel>(dataValue),
                Consts.ActionType.SendGroupMsg => JsonSerializer.Deserialize<CqSendGroupMsgActionResultDataModel>(dataValue),
                Consts.ActionType.SendMsg => JsonSerializer.Deserialize<CqSendMsgActionResultDataModel>(dataValue),
                Consts.ActionType.DeleteMsg => JsonSerializer.Deserialize<CqDeleteMsgActionResultDataModel>(dataValue),

                _ => null
            };
        }
    }
}