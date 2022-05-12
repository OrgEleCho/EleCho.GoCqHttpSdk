using NullLib.GoCqHttpSdk.Action;
using NullLib.GoCqHttpSdk.Action.Result;
using NullLib.GoCqHttpSdk.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public static class CqActionSenderExtensions
    {
        public static async Task<TActionResult?> Send<TAction, TActionResult>(this ICqActionSession session, TAction action)
            where TAction : CqAction
            where TActionResult : CqActionResult
        {
            CqActionResult? rst = await session.ActionSender.SendActionAsync(action);
            return rst as TActionResult;
        }

        public static async Task<CqSendPrivateMsgActionResult?> SendPrivateMsg(this ICqActionSession session, long userId, params CqMsg[] message)
        {
            return await session.Send<CqSendPrivateMsgAction, CqSendPrivateMsgActionResult>(new CqSendPrivateMsgAction(userId, 0, message));
        }
        public static async Task<CqSendPrivateMsgActionResult?> SendPrivateMsg(this ICqActionSession session, long userId, long groupId, params CqMsg[] message)
        {
            return await session.Send<CqSendPrivateMsgAction, CqSendPrivateMsgActionResult>(new CqSendPrivateMsgAction(userId, groupId, message));
        }
        public static async Task<CqSendGroupMsgActionResult?> SendGroupMsg(this ICqActionSession session, long groupId, params CqMsg[] message)
        {
            return await session.Send<CqSendGroupMsgAction, CqSendGroupMsgActionResult>(new CqSendGroupMsgAction(groupId, message));
        }
    }
}
