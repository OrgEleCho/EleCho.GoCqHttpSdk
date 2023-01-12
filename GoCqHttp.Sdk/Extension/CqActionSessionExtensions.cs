using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action.Result;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Message;
using System;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public static class CqActionSessionExtensions
    {
        public static async Task<TActionResult?> InvokeActionAsync<TAction, TActionResult>(this ICqActionSession session, TAction action)
            where TAction : CqAction
            where TActionResult : CqActionResult
        {
            CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
            return rst as TActionResult;
        }

        public static async Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, params CqMsg[] message)
        {
            return await session.InvokeActionAsync<CqSendPrivateMsgAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMsgAction(userId, 0, message));
        }

        public static async Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, long groupId, params CqMsg[] message)
        {
            return await session.InvokeActionAsync<CqSendPrivateMsgAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMsgAction(userId, groupId, message));
        }

        public static async Task<CqSendGroupMessageActionResult?> SendGroupMessageAsync(this ICqActionSession session, long groupId, params CqMsg[] message)
        {
            return await session.InvokeActionAsync<CqSendGroupMsgAction, CqSendGroupMessageActionResult>(new CqSendGroupMsgAction(groupId, message));
        }

        public static async Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, params CqMsg[] message)
        {
            return await session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(messageType, userId, groupId, message));
        }

        public static async Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, long? userId, long? groupId, params CqMsg[] message)
        {
            return await session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(userId, groupId, message));
        }

        public static async Task<CqRecallMessageActionResult?> RecallMessageAsync(this ICqActionSession session, long messageId)
        {
            return await session.InvokeActionAsync<CqRecallMessageAction, CqRecallMessageActionResult>(new CqRecallMessageAction(messageId));
        }

        public static async Task<CqSendGroupForwardMessageActionResult?> SendGroupForwardMessageAsync(this ICqActionSession session, long groupId, params CqForwardMessageNode[] messages)
        {
            return await session.InvokeActionAsync<CqSendGroupForwardMsgAction, CqSendGroupForwardMessageActionResult>(new CqSendGroupForwardMsgAction(groupId, messages));
        }
        public static async Task<CqGetMessageActionResult?> GetMessageAsync(this ICqActionSession session, long messageId)
        {
            return await session.InvokeActionAsync<CqGetMessageAction, CqGetMessageActionResult>(new CqGetMessageAction(messageId));
        }

        public static async Task<CqGetForwardMessageActionResult?> GetForwardMessageAsync(this ICqActionSession session, long messageId)
        {
            return await session.InvokeActionAsync<CqGetForwardMessageAction, CqGetForwardMessageActionResult>(new CqGetForwardMessageAction(messageId));
        }
        public static async Task<CqGetImageActionResult?> GetImageAsync(this ICqActionSession session, string filename)
        {
            return await session.InvokeActionAsync<CqGetImageAction, CqGetImageActionResult>(new CqGetImageAction(filename));
        }

        public static async Task<CqBanGroupMemberActionResult?> BanGroupMemberAsync(this ICqActionSession session, long groupId, long userId, TimeSpan duration)
        {
            return await session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, duration));
        }

        public static async Task<CqBanGroupMemberActionResult?> CancelBanGroupMemberAsync(this ICqActionSession session, long groupId, long userId)
        {
            return await session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, TimeSpan.Zero));
        }

        public static async Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous, TimeSpan duration)
        {
            return await session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, duration));
        }

        public static async Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag, TimeSpan duration)
        {
            return await session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, duration));
        }

        public static async Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous)
        {
            return await session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, TimeSpan.Zero));
        }

        public static async Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag)
        {
            return await session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, TimeSpan.Zero));
        }

        public static async Task<CqBanGroupAllMembersActionResult?> BanGroupAllMembersAsync(this ICqActionSession session, long groupId)
        {
            return await session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, true));
        }

        public static async Task<CqBanGroupAllMembersActionResult?> CancelBanGroupAllMembersAsync(this ICqActionSession session, long groupId)
        {
            return await session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, false));
        }

        public static async Task<CqKickGroupMemberActionResult?> KickGroupMemberAsync(this ICqActionSession session, long groupId, long userId, bool rejectRequest)
        {
            return await session.InvokeActionAsync<CqKickGroupMemberAction, CqKickGroupMemberActionResult>(new CqKickGroupMemberAction(groupId, userId, rejectRequest));
        }

        public static async Task<CqHandleFriendRequestActionResult?> HandleFriendRequestAsync(this ICqActionSession session, string flag, bool approve, string? remark)
        {
            return await session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, approve, remark));
        }

        public static async Task<CqHandleFriendRequestActionResult?> ApproveFriendRequestAsync(this ICqActionSession session, string flag, string? remark)
        {
            return await session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, true, remark));
        }

        public static async Task<CqHandleFriendRequestActionResult?> RejectFriendRequestAsync(this ICqActionSession session, string flag)
        {
            return await session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, false, null));
        }

        public static async Task<CqHandleGroupRequestActionResult?> HandleGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason)
        {
            return await session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, approve, reason));
        }

        public static async Task<CqHandleGroupRequestActionResult?> ApproveGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType)
        {
            return await session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, true, null));
        }

        public static async Task<CqHandleGroupRequestActionResult?> RejectGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason)
        {
            return await session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, false, reason));
        }
    }
}