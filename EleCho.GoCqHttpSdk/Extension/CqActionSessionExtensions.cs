using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// CQ 动作执行会话拓展
    /// </summary>
    public static class CqActionSessionExtensions
    {
        public static async Task<TActionResult?> InvokeActionAsync<TAction, TActionResult>(this ICqActionSession session, TAction action)
            where TAction : CqAction
            where TActionResult : CqActionResult
        {
            CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
            return rst as TActionResult;
        }

        public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, CqMessage message)
             => session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, message));
        public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, long groupId, CqMessage message)
            => session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, groupId, message));
        public static Task<CqSendGroupMessageActionResult?> SendGroupMessageAsync(this ICqActionSession session, long groupId, CqMessage message)
            => session.InvokeActionAsync<CqSendGroupMessageAction, CqSendGroupMessageActionResult>(new CqSendGroupMessageAction(groupId, message));
        public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, CqMessage message)
            => session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(messageType, userId, groupId, message));
        public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, long? userId, long? groupId, CqMessage message)
            => session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(userId, groupId, message));
        public static Task<CqRecallMessageActionResult?> RecallMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqRecallMessageAction, CqRecallMessageActionResult>(new CqRecallMessageAction(messageId));
        public static Task<CqSendGroupForwardMessageActionResult?> SendGroupForwardMessageAsync(this ICqActionSession session, long groupId, params CqForwardMessageNode[] messages)
            => session.InvokeActionAsync<CqSendGroupForwardMessageAction, CqSendGroupForwardMessageActionResult>(new CqSendGroupForwardMessageAction(groupId, messages));
        public static Task<CqSendPrivateForwardMessageActionResult?> SendPrivateForwardMessageAsync(this ICqActionSession session, long userId, params CqForwardMessageNode[] messages)
            => session.InvokeActionAsync<CqSendPrivateForwardMsgAction, CqSendPrivateForwardMessageActionResult>(new CqSendPrivateForwardMsgAction(userId, messages));
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
        public static Task<CqGetStrangerInformationActionResult?> GetStrangerInformationAsync(this ICqActionSession session, long userId)
            => session.InvokeActionAsync<CqGetStrangerInformationAction, CqGetStrangerInformationActionResult>(new CqGetStrangerInformationAction(userId));
        public static Task<CqGetStrangerInformationActionResult?> GetStrangerInformationAsync(this ICqActionSession session, long userId, bool noCache)
            => session.InvokeActionAsync<CqGetStrangerInformationAction, CqGetStrangerInformationActionResult>(new CqGetStrangerInformationAction(userId, noCache));
        public static Task<CqGetGroupInformationActionResult?> GetGroupInformationAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqGetGroupInformationAction, CqGetGroupInformationActionResult>(new CqGetGroupInformationAction(groupId));
        public static Task<CqGetGroupInformationActionResult?> GetGroupInformationAsync(this ICqActionSession session, long groupId, bool noCache)
            => session.InvokeActionAsync<CqGetGroupInformationAction, CqGetGroupInformationActionResult>(new CqGetGroupInformationAction(groupId, noCache));
        public static Task<CqGetGroupMemberInformationActionResult?> GetGroupMemberInformationAsync(this ICqActionSession session, long groupId, long user_id)
            => session.InvokeActionAsync<CqGetGroupMemberInformationAction, CqGetGroupMemberInformationActionResult>(new CqGetGroupMemberInformationAction(groupId, user_id));
        public static Task<CqGetGroupMemberInformationActionResult?> GetGroupMemberInformationAsync(this ICqActionSession session, long groupId, long user_id, bool noCache)
            => session.InvokeActionAsync<CqGetGroupMemberInformationAction, CqGetGroupMemberInformationActionResult>(new CqGetGroupMemberInformationAction(groupId, user_id, noCache));
        public static Task<CqMarkMessageAsReadActionResult?> MarkMessageAsRead(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqMarkMessageAsReadAction, CqMarkMessageAsReadActionResult>(new CqMarkMessageAsReadAction(messageId));
        public static Task<CqSetGroupAnonymousActionResult?> SetGroupAnonymous(this ICqActionSession session, long groupId, bool enable)
            => session.InvokeActionAsync<CqSetGroupAnonymousAction, CqSetGroupAnonymousActionResult>(new CqSetGroupAnonymousAction(groupId, enable));
        public static Task<CqSetGroupNameActionResult?> SetGroupName(this ICqActionSession session, long groupId, string groupName)
            => session.InvokeActionAsync<CqSetGroupNameAction, CqSetGroupNameActionResult>(new CqSetGroupNameAction(groupId, groupName));
        public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatar(this ICqActionSession session, long groupId, string file)
            => session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file));
        public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatar(this ICqActionSession session, long groupId, string file, bool useCache)
            => session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file, useCache));
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
        public static Task<CqGetFriendListActionResult?> GetFriendListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetFriendListAction, CqGetFriendListActionResult>(new CqGetFriendListAction());
        public static Task<CqGetGroupListActionResult?> GetGroupListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetGroupListAction, CqGetGroupListActionResult>(new CqGetGroupListAction());
        public static Task<CqGetUnidirectionalFriendListActionResult?> GetUnidirectionalFriendListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetUnidirectionalFriendListAction, CqGetUnidirectionalFriendListActionResult>(new CqGetUnidirectionalFriendListAction());
        public static Task<CqDeleteFriendActionResult?> DeleteFriend(this ICqActionSession session, long userId)
            => session.InvokeActionAsync<CqDeleteFriendAction, CqDeleteFriendActionResult>(new CqDeleteFriendAction(userId));
        public static Task<CqDeleteUnidirectionalFriendActionResult?> DeleteUnidirectionalFriend(this ICqActionSession session, long userId)
            => session.InvokeActionAsync<CqDeleteUnidirectionalFriendAction, CqDeleteUnidirectionalFriendActionResult>(new CqDeleteUnidirectionalFriendAction(userId));
        public static Task<CqCanSendImageActionResult?> CanSendImage(this ICqActionSession session)
            => session.InvokeActionAsync<CqCanSendImageAction, CqCanSendImageActionResult>(new CqCanSendImageAction());
        public static Task<CqCanSendRecordActionResult?> CanSendRecord(this ICqActionSession session)
            => session.InvokeActionAsync<CqCanSendRecordAction, CqCanSendRecordActionResult>(new CqCanSendRecordAction());
        
        public static Task<CqGetCookiesActionResult?> GetCookies(this ICqActionSession session, string domain)
            => session.InvokeActionAsync<CqGetCookiesAction, CqGetCookiesActionResult>(new CqGetCookiesAction(domain));
        public static Task<CqGetCsrfTokenActionResult?> GetCsrfToken(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetCsrfTokenAction, CqGetCsrfTokenActionResult>(new CqGetCsrfTokenAction());

        public static Task<CqDownloadFileActionResult?> DownloadFile(this ICqActionSession session, string url, int threadCount, Dictionary<string, string> headers)
            => session.InvokeActionAsync<CqDownloadFileAction, CqDownloadFileActionResult>(new CqDownloadFileAction(url, threadCount, headers));
        public static Task<CqGetOnlineClientsActionResult?> GetOnlineClients(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction());
        public static Task<CqGetOnlineClientsActionResult?> GetOnlineClients(this ICqActionSession session, bool noCache)
            => session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction(noCache));

        public static Task<CqSetEssenceMessageActionResult?> SetEssenceMessage(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqSetEssenceMessageAction, CqSetEssenceMessageActionResult>(new CqSetEssenceMessageAction(messageId));
        public static Task<CqDeleteEssenceMessageActionResult?> DeleteEssenceMessage(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqDeleteEssenceMessageAction, CqDeleteEssenceMessageActionResult>(new CqDeleteEssenceMessageAction(messageId));
        public static Task<CqGetEssenceMessageListActionResult?> GetEssenceMessageList(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqGetEssenceMessageListAction, CqGetEssenceMessageListActionResult>(new CqGetEssenceMessageListAction(groupId));

        public static Task<CqGetModelShowActionResult?> GetModelShow(this ICqActionSession session, string model)
            => session.InvokeActionAsync<CqGetModelShowAction, CqGetModelShowActionResult>(new CqGetModelShowAction(model));
        public static Task<CqSetModelShowActionResult?> SetModelShow(this ICqActionSession session, string model, string modelShow)
            => session.InvokeActionAsync<CqSetModelShowAction, CqSetModelShowActionResult>(new CqSetModelShowAction(model, modelShow));
        public static Task<CqCheckUrlSafetyActionResult?> CheckUrlSafety(this ICqActionSession session, string url)
            => session.InvokeActionAsync<CqCheckUrlSafetyAction, CqCheckUrlSafetyActionResult>(new CqCheckUrlSafetyAction(url));
        public static Task<CqGetVersionInformationActionResult?> GetVersionInformation(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetVersionInformationAction, CqGetVersionInformationActionResult>(new CqGetVersionInformationAction());

        public static Task<CqReloadEventFilterActionResult?> ReloadEventFilter(this ICqActionSession session, string file)
            => session.InvokeActionAsync<CqReloadEventFilterAction, CqReloadEventFilterActionResult>(new CqReloadEventFilterAction(file));

    }
}