using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using static EleCho.GoCqHttpSdk.Utils.Consts.ActionType;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
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
                SendPrivateMsg => JsonSerializer.Deserialize<CqSendPrivateMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                SendGroupMsg => JsonSerializer.Deserialize<CqSendGroupMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                SendMsg => JsonSerializer.Deserialize<CqSendMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                DeleteMsg => JsonSerializer.Deserialize<CqRecallMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                SendGroupForwardMsg => JsonSerializer.Deserialize<CqSendGroupForwardMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                
                GetMsg => JsonSerializer.Deserialize<CqGetMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                GetForwardMsg => JsonSerializer.Deserialize<CqGetForwardMessageActionResultDataModel>(dataValue, JsonHelper.Options),
                GetImage => JsonSerializer.Deserialize<CqGetImageActionResultDataModel>(dataValue, JsonHelper.Options),
                GetLoginInfo => JsonSerializer.Deserialize<CqGetLoginInformationActionResultDataModel>(dataValue, JsonHelper.Options),
                GetStrangerInfo => JsonSerializer.Deserialize<CqGetStrangerInformationActionResultDataModel>(dataValue, JsonHelper.Options),

                SetGroupBan => JsonSerializer.Deserialize<CqBanGroupMemberActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupAnonymousBan => JsonSerializer.Deserialize<CqBanGroupAnonymousMemberActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupWholeBan => JsonSerializer.Deserialize<CqBanGroupAllMembersActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupKick => JsonSerializer.Deserialize<CqKickGroupMemberActionResultDataModel>(dataValue, JsonHelper.Options),

                SetFriendAddRequest => JsonSerializer.Deserialize<CqHandleFriendRequestActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupAddRequest => JsonSerializer.Deserialize<CqHandleGroupRequestActionResultDataModel>(dataValue, JsonHelper.Options),

                MarkMsgAsRead => JsonSerializer.Deserialize<CqMarkMessageAsReadResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupAdmin => JsonSerializer.Deserialize<CqSetGroupAdministratorActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupAnonymous => JsonSerializer.Deserialize<CqSetGroupAnonymousActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupCard => JsonSerializer.Deserialize<CqSetGroupNicknameActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupName => JsonSerializer.Deserialize<CqSetGroupNameActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupLeave => JsonSerializer.Deserialize<CqLeaveGroupActionResultDataModel>(dataValue, JsonHelper.Options),
                SetGroupSpecialTitle => JsonSerializer.Deserialize<CqSetGroupSpecialTitleActionResultDataModel>(dataValue, JsonHelper.Options),

                SendGroupSign => JsonSerializer.Deserialize<CqGroupSignInActionResultDataModel>(dataValue, JsonHelper.Options),


                _ => throw new NotImplementedException()
            };
        }
    }
}