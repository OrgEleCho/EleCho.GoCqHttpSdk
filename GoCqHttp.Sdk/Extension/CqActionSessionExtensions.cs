using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action.Result;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
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

        public static async Task<CqSendGroupForwardMsgActionResult?> SendGroupForwardMsg(this ICqActionSession session, long groupId, params CqForwardMsgNode[] messages)
        {
            return await session.SendAsync<CqSendGroupForwardMsgAction, CqSendGroupForwardMsgActionResult>(new CqSendGroupForwardMsgAction(groupId, messages));
        }
        public static async Task<CqGetMsgActionResult?> GetMsg(this ICqActionSession session, int messageId)
        {
            return await session.SendAsync<CqGetMsgAction, CqGetMsgActionResult>(new CqGetMsgAction(messageId));
        }
    }
}