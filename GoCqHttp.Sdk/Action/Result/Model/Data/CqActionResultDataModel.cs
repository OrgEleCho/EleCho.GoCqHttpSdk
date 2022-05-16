using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Util;
using System.Text.Json;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
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
                Consts.ActionType.SendPrivateMsg => JsonSerializer.Deserialize<CqSendPrivateMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),
                Consts.ActionType.SendGroupMsg => JsonSerializer.Deserialize<CqSendGroupMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),
                Consts.ActionType.SendMsg => JsonSerializer.Deserialize<CqSendMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),
                Consts.ActionType.DeleteMsg => JsonSerializer.Deserialize<CqDeleteMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),
                Consts.ActionType.SendGroupForwardMsg => JsonSerializer.Deserialize<CqSendGroupForwardMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),
                Consts.ActionType.GetMsg => JsonSerializer.Deserialize<CqGetMsgActionResultDataModel>(dataValue, JsonHelper.GetOptions()),

                _ => null
            };
        }
    }

    internal class CqSetFriendAddRequestActionResultDataModel : CqActionResultDataModel
    {

    }

    internal class CqGetForwardMsgActionResultDataModel : CqActionResultDataModel
    {
        public CqForwardMsgNodeDataModel[] messages { get; set; }
    }
}