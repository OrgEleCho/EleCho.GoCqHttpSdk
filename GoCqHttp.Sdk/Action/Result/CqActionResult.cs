using EleCho.GoCqHttpSdk.Action.Result.Model;
using EleCho.GoCqHttpSdk.Action.Result.Model.Data;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public abstract class CqActionResult
    {
        public CqActionStatus Status { get; set; }
        public CqActionRetCode RetCode { get; set; }
        /// <summary>
        /// 回声数据, 尽在请求指定了 EchoData 时有效
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

            CqActionResultDataModel? dataModel = CqActionResultDataModel.FromRaw(raw.data, actionType);
            CqActionResult? rst = actionType switch
            {
                Consts.ActionType.SendPrivateMsg => new CqSendPrivateMsgActionResult(),
                Consts.ActionType.SendGroupMsg => new CqSendGroupMsgActionResult(),
                Consts.ActionType.SendMsg => new CqSendMsgActionResult(),
                Consts.ActionType.DeleteMsg => new CqDeleteMsgActionResult(),
                Consts.ActionType.SendGroupForwardMsg => new CqSendGroupForwardMsgActionResult(),
                Consts.ActionType.GetMsg => new CqGetMsgActionResult(),
                Consts.ActionType.GetForwardMsg => new CqGetForwardMsgActionResult(),
                Consts.ActionType.GetImage => new CqGetImageActionResult(),
                Consts.ActionType.SetGroupBan => new CqBanGroupMemberActionResult(),
                Consts.ActionType.SetGroupKick => new CqKickGroupMemberActionResult(),

                Consts.ActionType.SetFriendAddRequest => new CqHandleFriendRequestActionResult(),
                Consts.ActionType.SetGroupAddRequest => new CqHandleGroupRequestActionResult(),

                _ => null
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

    public class CqHandleGroupRequestActionResult : CqActionResult
    {
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            
        }
    }
}