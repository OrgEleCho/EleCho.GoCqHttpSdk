using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action.Result;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using System;
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

        public static async Task<CqGetForwardMsgActionResult?> GetForwardMsg(this ICqActionSession session, int messageId)
        {
            return await session.SendAsync<CqGetForwardMsgAction, CqGetForwardMsgActionResult>(new CqGetForwardMsgAction(messageId));
        }
        public static async Task<CqGetImageActionResult?> GetImage(this ICqActionSession session, string filename)
        {
            return await session.SendAsync<CqGetImageAction, CqGetImageActionResult>(new CqGetImageAction(filename));
        }

        public static async Task<CqBanGroupMemberActionResult?> BanGroupMember(this ICqActionSession session, long groupId, long userId, TimeSpan duration)
        {
            return await session.SendAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, duration));
        }

        public static async Task<CqKickGroupMemberActionResult?> KickGroupMember(this ICqActionSession session, long groupId, long userId, bool rejectRequest)
        {
            return await session.SendAsync<CqKickGroupMemberAction, CqKickGroupMemberActionResult>(new CqKickGroupMemberAction(groupId, userId, rejectRequest));
        }

        public static async Task<CqHandleFriendRequestActionResult?> HandleFriendRequest(this ICqActionSession session, string flag, bool approve, string? remark)
        {
            return await session.SendAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, approve, remark));
        }

        public static async Task<CqHandleFriendRequestActionResult?> ApproveFriendRequest(this ICqActionSession session, string flag, string? remark)
        {
            return await session.SendAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, true, remark));
        }

        public static async Task<CqHandleFriendRequestActionResult?> RejectFriendRequest(this ICqActionSession session, string flag)
        {
            return await session.SendAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, false, null));
        }

        public static async Task<CqHandleGroupRequestActionResult?> HandleGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason)
        {
            return await session.SendAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, approve, reason));
        }

        public static async Task<CqHandleGroupRequestActionResult?> ApproveGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType)
        {
            return await session.SendAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, true, null));
        }

        public static async Task<CqHandleGroupRequestActionResult?> RejectGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason)
        {
            return await session.SendAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, false, reason));
        }
    }
}