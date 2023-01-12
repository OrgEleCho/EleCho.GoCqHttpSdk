using System;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Action.Model.Data;

using EleCho.GoCqHttpSdk.Utils;
using static EleCho.GoCqHttpSdk.Utils.Consts.ActionType;

namespace EleCho.GoCqHttpSdk.Action
{
    public abstract class CqActionResult
    {
        public CqActionStatus Status { get; set; }
        public CqActionRetCode RetCode { get; set; }
        /// <summary>
        /// 回声数据, 仅在请求指定了 EchoData 时有效
        /// </summary>
        public string? EchoData { get; set; }
        /// <summary>
        /// 错误消息, 仅在调用失败时有效
        /// 对应源数据中 msg 字段
        /// </summary>
        public string? ErrorMsg { get; set; }
        /// <summary>
        /// 错误信息, 仅在调用失败时有效
        /// 对应源数据中 wording 字段
        /// </summary>
        public string? ErrorInfo { get; set; }

        internal abstract void ReadDataModel(CqActionResultDataModel? model);

        internal static CqActionResult? FromRaw(CqActionResultRaw? raw, string actionType)
        {
            if (raw == null)
                return null;

            CqActionResultDataModel? dataModel =
                CqActionResultDataModel.FromRaw(raw.data, actionType);

            CqActionResult? rst = actionType switch
            {
                SendPrivateMsg => new CqSendPrivateMessageActionResult(),
                SendGroupMsg => new CqSendGroupMessageActionResult(),
                SendMsg => new CqSendMessageActionResult(),
                DeleteMsg => new CqRecallMessageActionResult(),
                SendGroupForwardMsg => new CqSendGroupForwardMessageActionResult(),
                
                GetMsg => new CqGetMessageActionResult(),
                GetForwardMsg => new CqGetForwardMessageActionResult(),
                GetImage => new CqGetImageActionResult(),
                GetLoginInfo => new CqGetLoginInformationActionResult(),

                SetGroupBan => new CqBanGroupMemberActionResult(),
                SetGroupAnonymousBan => new CqBanGroupAnonymousMemberActionResult(),
                SetGroupWholeBan => new CqBanGroupAllMembersActionResult(),
                SetGroupKick => new CqKickGroupMemberActionResult(),

                SetFriendAddRequest => new CqHandleFriendRequestActionResult(),
                SetGroupAddRequest => new CqHandleGroupRequestActionResult(),

                MarkMsgAsRead => new CqMarkMessageAsReadActionResult(),
                SetGroupAdmin => new CqSetGroupAdministratorActionResult(),
                SetGroupAnonymous => new CqSetGroupAnonymousActionResult(),
                SetGroupCard => new CqSetGroupNicknameActionResult(),
                SetGroupName => new CqSetGroupNameActionResult(),
                SetGroupLeave => new CqLeaveGroupActionResult(),
                SetGroupSpecialTitle => new CqSetGroupSpecialTitleActionResult(),
                
                SendGroupSign => new CqGroupSignInActionResult(),
                

                _ => throw new NotImplementedException()
            };

            if (rst == null)
                return null;

            rst.Status = CqEnum.GetActionStatus(raw.status);
            rst.RetCode = (CqActionRetCode)raw.retcode;
            rst.ErrorMsg = raw.msg;
            rst.ErrorInfo = raw.wording;
            rst.EchoData = raw.echo;
            
            rst.ReadDataModel(dataModel);

            return rst;
        }
    }
}