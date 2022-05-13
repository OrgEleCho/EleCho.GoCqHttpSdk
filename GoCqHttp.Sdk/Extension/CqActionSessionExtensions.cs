using NullLib.GoCqHttpSdk.Action;
using NullLib.GoCqHttpSdk.Action.Result;
using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public static class CqActionSessionExtensions
    {
        public static async Task<TActionResult?> SendAsync<TAction, TActionResult>(this ICqActionSession session, TAction action)
            where TAction : CqAction
            where TActionResult : CqActionResult
        {
            CqActionResult? rst = await session.ActionSender.SendActionAsync(action);
            return rst as TActionResult;
        }

        public static async Task<CqSendPrivateMsgActionResult?> SendPrivateMsgAsync(this ICqActionSession session, long userId, params CqMsg[] message)
        {
            return await session.SendAsync<CqSendPrivateMsgAction, CqSendPrivateMsgActionResult>(new CqSendPrivateMsgAction(userId, 0, message));
        }

        public static async Task<CqSendPrivateMsgActionResult?> SendPrivateMsgAsync(this ICqActionSession session, long userId, long groupId, params CqMsg[] message)
        {
            return await session.SendAsync<CqSendPrivateMsgAction, CqSendPrivateMsgActionResult>(new CqSendPrivateMsgAction(userId, groupId, message));
        }

        public static async Task<CqSendGroupMsgActionResult?> SendGroupMsgAsync(this ICqActionSession session, long groupId, params CqMsg[] message)
        {
            return await session.SendAsync<CqSendGroupMsgAction, CqSendGroupMsgActionResult>(new CqSendGroupMsgAction(groupId, message));
        }

        public static async Task<CqSendMsgActionResult?> SendMsgAsync(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, params CqMsg[] message)
        {
            return await session.SendAsync<CqSendMsgAction, CqSendMsgActionResult>(new CqSendMsgAction(messageType, userId, groupId, message));
        }

        public static async Task<CqSendMsgActionResult?> SendMsgAsync(this ICqActionSession session, long? userId, long? groupId, params CqMsg[] message)
        {
            return await session.SendAsync<CqSendMsgAction, CqSendMsgActionResult>(new CqSendMsgAction(userId, groupId, message));
        }

        public static async Task<CqDeleteMsgActionResult?> DeleteMsgAsync(this ICqActionSession session, int messageId)
        {
            return await session.SendAsync<CqDeleteMsgAction, CqDeleteMsgActionResult>(new CqDeleteMsgAction(messageId));
        }
    }
}