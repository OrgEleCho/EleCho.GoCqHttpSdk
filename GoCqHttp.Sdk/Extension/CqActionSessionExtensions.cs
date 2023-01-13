using System;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;

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

        public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, params CqMsg[] message)
             => session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, message));
        public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, long groupId, params CqMsg[] message)
            => session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, groupId, message));
        public static Task<CqSendGroupMessageActionResult?> SendGroupMessageAsync(this ICqActionSession session, long groupId, params CqMsg[] message)
            => session.InvokeActionAsync<CqSendGroupMessageAction, CqSendGroupMessageActionResult>(new CqSendGroupMessageAction(groupId, message));
        public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, params CqMsg[] message)
            => session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(messageType, userId, groupId, message));
        public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, long? userId, long? groupId, params CqMsg[] message)
            => session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(userId, groupId, message));
        public static Task<CqRecallMessageActionResult?> RecallMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqRecallMessageAction, CqRecallMessageActionResult>(new CqRecallMessageAction(messageId));
        public static Task<CqSendGroupForwardMessageActionResult?> SendGroupForwardMessageAsync(this ICqActionSession session, long groupId, params CqForwardMessageNode[] messages)
            => session.InvokeActionAsync<CqSendGroupForwardMsgAction, CqSendGroupForwardMessageActionResult>(new CqSendGroupForwardMsgAction(groupId, messages));
        public static Task<CqGetMessageActionResult?> GetMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqGetMessageAction, CqGetMessageActionResult>(new CqGetMessageAction(messageId));
        public static Task<CqGetForwardMessageActionResult?> GetForwardMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqGetForwardMessageAction, CqGetForwardMessageActionResult>(new CqGetForwardMessageAction(messageId));
        public static Task<CqGetImageActionResult?> GetImageAsync(this ICqActionSession session, string filename)
            => session.InvokeActionAsync<CqGetImageAction, CqGetImageActionResult>(new CqGetImageAction(filename));
        public static Task<CqBanGroupMemberActionResult?> BanGroupMemberAsync(this ICqActionSession session, long groupId, long userId, TimeSpan duration)
            => session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, duration));
        public static Task<CqBanGroupMemberActionResult?> CancelBanGroupMemberAsync(this ICqActionSession session, long groupId, long userId)
            => session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, TimeSpan.Zero));
        public static Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous, TimeSpan duration)
            => session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, duration));
        public static Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag, TimeSpan duration)
            => session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, duration));
        public static Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous)
            => session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, TimeSpan.Zero));
        public static Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag)
            => session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, TimeSpan.Zero));
        public static Task<CqBanGroupAllMembersActionResult?> BanGroupAllMembersAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, true));
        public static Task<CqBanGroupAllMembersActionResult?> CancelBanGroupAllMembersAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, false));
        public static Task<CqKickGroupMemberActionResult?> KickGroupMemberAsync(this ICqActionSession session, long groupId, long userId, bool rejectRequest)
            => session.InvokeActionAsync<CqKickGroupMemberAction, CqKickGroupMemberActionResult>(new CqKickGroupMemberAction(groupId, userId, rejectRequest));
        public static Task<CqHandleFriendRequestActionResult?> HandleFriendRequestAsync(this ICqActionSession session, string flag, bool approve, string? remark)
            => session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, approve, remark));
        public static Task<CqHandleFriendRequestActionResult?> ApproveFriendRequestAsync(this ICqActionSession session, string flag, string? remark)
            => session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, true, remark));
        public static Task<CqHandleFriendRequestActionResult?> RejectFriendRequestAsync(this ICqActionSession session, string flag)
            => session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, false, null));
        public static Task<CqHandleGroupRequestActionResult?> HandleGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason)
            => session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, approve, reason));
        public static Task<CqHandleGroupRequestActionResult?> ApproveGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType)
            => session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, true, null));
        public static Task<CqHandleGroupRequestActionResult?> RejectGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason)
            => session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, false, reason));
        public static Task<CqGetLoginInformationActionResult?> GetLoginInformationAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetLoginInformationAction, CqGetLoginInformationActionResult>(new CqGetLoginInformationAction());
        public static Task<CqGetStrangerInformationActionResult?> GetStrangerInformationAsync(this ICqActionSession session, long userId, bool noCache)
            => session.InvokeActionAsync<CqGetStrangerInformationAction, CqGetStrangerInformationActionResult>(new CqGetStrangerInformationAction(userId, noCache));
        public static Task<CqMarkMessageAsReadActionResult?> MarkMessageAsRead(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqMarkMessageAsReadAction, CqMarkMessageAsReadActionResult>(new CqMarkMessageAsReadAction(messageId));
        public static Task<CqSetGroupAnonymousActionResult?> SetGroupAnonymous(this ICqActionSession session, long groupId, bool enable)
            => session.InvokeActionAsync<CqSetGroupAnonymousAction, CqSetGroupAnonymousActionResult>(new CqSetGroupAnonymousAction(groupId, enable));
        public static Task<CqSetGroupNameActionResult?> SetGroupName(this ICqActionSession session, long groupId, string groupName)
            => session.InvokeActionAsync<CqSetGroupNameAction, CqSetGroupNameActionResult>(new CqSetGroupNameAction(groupId, groupName));
        public static Task<CqSetGroupNicknameActionResult?> SetGroupNickname(this ICqActionSession session, long groupId, long userId, string nickname)
            => session.InvokeActionAsync<CqSetGroupNicknameAction, CqSetGroupNicknameActionResult>(new CqSetGroupNicknameAction(groupId, userId, nickname));
        public static Task<CqLeaveGroupActionResult?> LeaveGroup(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId));
        public static Task<CqLeaveGroupActionResult?> LeaveGroup(this ICqActionSession session, long groupId, bool dismissGroup)
            => session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId, dismissGroup));
        public static Task<CqSetGroupSpecialTitleActionResult?> SetGroupSpecialTitle(this ICqActionSession session, long groupId, long userId, string specialTitle)
            => session.InvokeActionAsync<CqSetGroupSpecialTitleAction, CqSetGroupSpecialTitleActionResult>(new CqSetGroupSpecialTitleAction(groupId, userId, specialTitle));
        public static Task<CqGroupSignInActionResult?> GroupSignIn(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqGroupSignInAction, CqGroupSignInActionResult>(new CqGroupSignInAction(groupId));
        public static Task<CqSetAccountProfileActionResult?> SetAccountProfile(this ICqActionSession session, string nickname, string company, string email, string college, string personalNote)
            => session.InvokeActionAsync<CqSetAccountProfileAction, CqSetAccountProfileActionResult>(new CqSetAccountProfileAction(nickname, company, email, college, personalNote));

    }
}