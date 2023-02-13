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
        /// <summary>
        /// 执行一个动作
        /// </summary>
        /// <typeparam name="TAction"></typeparam>
        /// <typeparam name="TActionResult"></typeparam>
        /// <param name="session"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task<TActionResult?> InvokeActionAsync<TAction, TActionResult>(this ICqActionSession session, TAction action)
            where TAction : CqAction
            where TActionResult : CqActionResult
        {
            CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
            return rst as TActionResult;
        }

        #region 异步方法
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
        public static Task<CqSendGroupForwardMessageActionResult?> SendGroupForwardMessageAsync(this ICqActionSession session, long groupId, CqForwardMessage forwardMessage)
            => session.InvokeActionAsync<CqSendGroupForwardMessageAction, CqSendGroupForwardMessageActionResult>(new CqSendGroupForwardMessageAction(groupId, forwardMessage));
        public static Task<CqSendPrivateForwardMessageActionResult?> SendPrivateForwardMessageAsync(this ICqActionSession session, long userId, CqForwardMessage forwardMessage)
            => session.InvokeActionAsync<CqSendPrivateForwardMessageAction, CqSendPrivateForwardMessageActionResult>(new CqSendPrivateForwardMessageAction(userId, forwardMessage));
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
        public static Task<CqMarkMessageAsReadActionResult?> MarkMessageAsReadAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqMarkMessageAsReadAction, CqMarkMessageAsReadActionResult>(new CqMarkMessageAsReadAction(messageId));
        public static Task<CqSetGroupAnonymousActionResult?> SetGroupAnonymousAsync(this ICqActionSession session, long groupId, bool enable)
            => session.InvokeActionAsync<CqSetGroupAnonymousAction, CqSetGroupAnonymousActionResult>(new CqSetGroupAnonymousAction(groupId, enable));
        public static Task<CqSetGroupNameActionResult?> SetGroupNameAsync(this ICqActionSession session, long groupId, string groupName)
            => session.InvokeActionAsync<CqSetGroupNameAction, CqSetGroupNameActionResult>(new CqSetGroupNameAction(groupId, groupName));
        public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatarAsync(this ICqActionSession session, long groupId, string file)
            => session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file));
        public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatarAsync(this ICqActionSession session, long groupId, string file, bool useCache)
            => session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file, useCache));
        public static Task<CqSetGroupNicknameActionResult?> SetGroupNicknameAsync(this ICqActionSession session, long groupId, long userId, string nickname)
            => session.InvokeActionAsync<CqSetGroupNicknameAction, CqSetGroupNicknameActionResult>(new CqSetGroupNicknameAction(groupId, userId, nickname));
        public static Task<CqLeaveGroupActionResult?> LeaveGroupAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId));
        public static Task<CqLeaveGroupActionResult?> LeaveGroupAsync(this ICqActionSession session, long groupId, bool dismissGroup)
            => session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId, dismissGroup));
        public static Task<CqSetGroupSpecialTitleActionResult?> SetGroupSpecialTitleAsync(this ICqActionSession session, long groupId, long userId, string specialTitle)
            => session.InvokeActionAsync<CqSetGroupSpecialTitleAction, CqSetGroupSpecialTitleActionResult>(new CqSetGroupSpecialTitleAction(groupId, userId, specialTitle));
        public static Task<CqGroupSignInActionResult?> GroupSignInAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqGroupSignInAction, CqGroupSignInActionResult>(new CqGroupSignInAction(groupId));
        public static Task<CqSetAccountProfileActionResult?> SetAccountProfileAsync(this ICqActionSession session, string nickname, string company, string email, string college, string personalNote)
            => session.InvokeActionAsync<CqSetAccountProfileAction, CqSetAccountProfileActionResult>(new CqSetAccountProfileAction(nickname, company, email, college, personalNote));
        public static Task<CqGetFriendListActionResult?> GetFriendListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetFriendListAction, CqGetFriendListActionResult>(new CqGetFriendListAction());
        public static Task<CqGetGroupListActionResult?> GetGroupListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetGroupListAction, CqGetGroupListActionResult>(new CqGetGroupListAction());
        public static Task<CqGetUnidirectionalFriendListActionResult?> GetUnidirectionalFriendListAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetUnidirectionalFriendListAction, CqGetUnidirectionalFriendListActionResult>(new CqGetUnidirectionalFriendListAction());
        public static Task<CqDeleteFriendActionResult?> DeleteFriendAsync(this ICqActionSession session, long userId)
            => session.InvokeActionAsync<CqDeleteFriendAction, CqDeleteFriendActionResult>(new CqDeleteFriendAction(userId));
        public static Task<CqDeleteUnidirectionalFriendActionResult?> DeleteUnidirectionalFriendAsync(this ICqActionSession session, long userId)
            => session.InvokeActionAsync<CqDeleteUnidirectionalFriendAction, CqDeleteUnidirectionalFriendActionResult>(new CqDeleteUnidirectionalFriendAction(userId));
        public static Task<CqCanSendImageActionResult?> CanSendImageAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqCanSendImageAction, CqCanSendImageActionResult>(new CqCanSendImageAction());
        public static Task<CqCanSendRecordActionResult?> CanSendRecordAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqCanSendRecordAction, CqCanSendRecordActionResult>(new CqCanSendRecordAction());

        public static Task<CqGetCookiesActionResult?> GetCookiesAsync(this ICqActionSession session, string domain)
            => session.InvokeActionAsync<CqGetCookiesAction, CqGetCookiesActionResult>(new CqGetCookiesAction(domain));
        public static Task<CqGetCsrfTokenActionResult?> GetCsrfTokenAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetCsrfTokenAction, CqGetCsrfTokenActionResult>(new CqGetCsrfTokenAction());

        public static Task<CqDownloadFileActionResult?> DownloadFileAsync(this ICqActionSession session, string url, int threadCount, Dictionary<string, string> headers)
            => session.InvokeActionAsync<CqDownloadFileAction, CqDownloadFileActionResult>(new CqDownloadFileAction(url, threadCount, headers));
        public static Task<CqGetOnlineClientsActionResult?> GetOnlineClientsAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction());
        public static Task<CqGetOnlineClientsActionResult?> GetOnlineClientsAsync(this ICqActionSession session, bool noCache)
            => session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction(noCache));

        public static Task<CqSetEssenceMessageActionResult?> SetEssenceMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqSetEssenceMessageAction, CqSetEssenceMessageActionResult>(new CqSetEssenceMessageAction(messageId));
        public static Task<CqDeleteEssenceMessageActionResult?> DeleteEssenceMessageAsync(this ICqActionSession session, long messageId)
            => session.InvokeActionAsync<CqDeleteEssenceMessageAction, CqDeleteEssenceMessageActionResult>(new CqDeleteEssenceMessageAction(messageId));
        public static Task<CqGetEssenceMessageListActionResult?> GetEssenceMessageListAsync(this ICqActionSession session, long groupId)
            => session.InvokeActionAsync<CqGetEssenceMessageListAction, CqGetEssenceMessageListActionResult>(new CqGetEssenceMessageListAction(groupId));

        public static Task<CqGetModelShowActionResult?> GetModelShowAsync(this ICqActionSession session, string model)
            => session.InvokeActionAsync<CqGetModelShowAction, CqGetModelShowActionResult>(new CqGetModelShowAction(model));
        public static Task<CqSetModelShowActionResult?> SetModelShowAsync(this ICqActionSession session, string model, string modelShow)
            => session.InvokeActionAsync<CqSetModelShowAction, CqSetModelShowActionResult>(new CqSetModelShowAction(model, modelShow));
        public static Task<CqCheckUrlSafetyActionResult?> CheckUrlSafetyAsync(this ICqActionSession session, string url)
            => session.InvokeActionAsync<CqCheckUrlSafetyAction, CqCheckUrlSafetyActionResult>(new CqCheckUrlSafetyAction(url));
        public static Task<CqGetVersionInformationActionResult?> GetVersionInformationAsync(this ICqActionSession session)
            => session.InvokeActionAsync<CqGetVersionInformationAction, CqGetVersionInformationActionResult>(new CqGetVersionInformationAction());

        public static Task<CqReloadEventFilterActionResult?> ReloadEventFilterAsync(this ICqActionSession session, string file)
            => session.InvokeActionAsync<CqReloadEventFilterAction, CqReloadEventFilterActionResult>(new CqReloadEventFilterAction(file));

        #endregion













        #region 同步包装
        public static CqSendPrivateMessageActionResult? SendPrivateMessage(this ICqActionSession session, long userId, CqMessage message)
            => SendPrivateMessageAsync(session, userId, message).Result;
        public static CqSendPrivateMessageActionResult? SendPrivateMessage(this ICqActionSession session, long userId, long groupId, CqMessage message)
            => SendPrivateMessageAsync(session, userId, groupId, message).Result;
        public static CqSendGroupMessageActionResult? SendGroupMessage(this ICqActionSession session, long groupId, CqMessage message)
            => SendGroupMessageAsync(session, groupId, message).Result;
        public static CqSendMessageActionResult? SendMessage(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, CqMessage message)
            => SendMessageAsync(session, messageType, userId, groupId, message).Result;
        public static CqSendMessageActionResult? SendMessage(this ICqActionSession session, long? userId, long? groupId, CqMessage message)
            => SendMessageAsync(session, userId, groupId, message).Result;
        public static CqRecallMessageActionResult? RecallMessage(this ICqActionSession session, long messageId)
            => RecallMessageAsync(session, messageId).Result;
        public static CqSendGroupForwardMessageActionResult? SendGroupForwardMessage(this ICqActionSession session, long groupId, CqForwardMessage forwardMessage)
            => SendGroupForwardMessageAsync(session, groupId, forwardMessage).Result;
        public static CqSendPrivateForwardMessageActionResult? SendPrivateForwardMessage(this ICqActionSession session, long userId, CqForwardMessage forwardMessage)
            => SendPrivateForwardMessageAsync(session, userId, forwardMessage).Result;
        public static CqGetMessageActionResult? GetMessage(this ICqActionSession session, long messageId)
            => GetMessageAsync(session, messageId).Result;
        public static CqGetForwardMessageActionResult? GetForwwardMessage(this ICqActionSession session, long messageId)
            => GetForwardMessageAsync(session, messageId).Result;
        public static CqGetImageActionResult? GetImage(this ICqActionSession session, string filename)
            => GetImageAsync(session, filename).Result;
        public static CqBanGroupMemberActionResult? BanGroupMember(this ICqActionSession session, long groupId, long userId, TimeSpan duration)
            => BanGroupMemberAsync(session, groupId, userId, duration).Result;
        public static CqBanGroupMemberActionResult? CancelBanGroupMember(this ICqActionSession session, long groupId, long userId)
            => CancelBanGroupMemberAsync(session, groupId, userId).Result;
        public static CqBanGroupAnonymousMemberActionResult? BanGroupAnonymousMember(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous, TimeSpan duration)
            => BanGroupAnonymousMemberAsync(session, groupId, anonymous, duration).Result;
        public static CqBanGroupAnonymousMemberActionResult? BanGroupAnonymousMember(this ICqActionSession session, long groupId, string anonymousFlag, TimeSpan duration)
            => BanGroupAnonymousMemberAsync(session, groupId, anonymousFlag, duration).Result;
        public static CqBanGroupAnonymousMemberActionResult? CancelBanGroupAnonymousMember(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous)
            => CancelBanGroupAnonymousMemberAsync(session, groupId, anonymous).Result;
        public static CqBanGroupAnonymousMemberActionResult? CancelBanGroupAnonymousMember(this ICqActionSession session, long groupId, string anonymousFlag)
            => CancelBanGroupAnonymousMemberAsync(session, groupId, anonymousFlag).Result;
        public static CqKickGroupMemberActionResult? KickGroupMember(this ICqActionSession session, long groupId, long userId, bool rejectRequest)
            => KickGroupMemberAsync(session, groupId, userId, rejectRequest).Result;
        public static CqHandleFriendRequestActionResult? HandleFriendRequest(this ICqActionSession session, string flag, bool approve, string? remark)
            => HandleFriendRequestAsync(session, flag, approve, remark).Result;
        public static CqHandleFriendRequestActionResult? ApproveFriendRequest(this ICqActionSession session, string flag, string? remark)
            => ApproveFriendRequestAsync(session, flag, remark).Result;
        public static CqHandleFriendRequestActionResult? RejectFriendRequest(this ICqActionSession session, string flag)
            => RejectFriendRequestAsync(session, flag).Result;
        public static CqHandleGroupRequestActionResult? HandleGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason)
            => HandleGroupRequestAsync(session, flag, requestType, approve, reason).Result;
        public static CqHandleGroupRequestActionResult? ApproveGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType)
            => ApproveGroupRequestAsync(session, flag, requestType).Result;
        public static CqHandleGroupRequestActionResult? RejectGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason)
            => RejectGroupRequestAsync(session, flag, requestType, reason).Result;
        public static CqGetLoginInformationActionResult? GetLoginInformation(this ICqActionSession session)
            => GetLoginInformationAsync(session).Result;
        public static CqGetStrangerInformationActionResult? GetStrangerInformation(this ICqActionSession session, long userId)
            => GetStrangerInformationAsync(session, userId).Result;
        public static CqGetStrangerInformationActionResult? GetStrangerInformation(this ICqActionSession session, long userId, bool noCache)
            => GetStrangerInformationAsync(session, userId, noCache).Result;
        public static CqGetGroupInformationActionResult? GetGroupInformation(this ICqActionSession session, int groupId)
            => GetGroupInformationAsync(session, groupId).Result;
        public static CqGetGroupInformationActionResult? GetGroupInformation(this ICqActionSession session, int groupId, bool noCache)
            => GetGroupInformationAsync(session, groupId, noCache).Result;
        public static CqGetGroupMemberInformationActionResult? GetGroupMemberInformation(this ICqActionSession session, long groupId, long userId)
            => GetGroupMemberInformationAsync(session, groupId, userId).Result;
        public static CqGetGroupMemberInformationActionResult? GetGroupMemberInformation(this ICqActionSession session, long groupId, long userId, bool noCache)
            => GetGroupMemberInformationAsync(session, groupId, userId, noCache).Result;
        public static CqMarkMessageAsReadActionResult? MarkMessageAsRead(this ICqActionSession session, long messageId)
            => MarkMessageAsReadAsync(session, messageId).Result;
        public static CqSetGroupAnonymousActionResult? SetGroupAnonymous(this ICqActionSession session, long groupId, bool enable)
            => SetGroupAnonymousAsync(session, groupId, enable).Result;
        public static CqSetGroupNameActionResult? SetGroupName(this ICqActionSession session, long groupId, string file)
            => SetGroupNameAsync(session, groupId, file).Result;
        public static CqSetGroupAvatarActionResult? SetGroupAvatar(this ICqActionSession session, long groupId, string file)
            => SetGroupAvatarAsync(session, groupId, file).Result;
        public static CqSetGroupAvatarActionResult? SetGroupAvatar(this ICqActionSession session, long groupId, string file, bool noCache)
            => SetGroupAvatarAsync(session, groupId, file, noCache).Result;
        public static CqSetGroupNicknameActionResult? SetGroupNickname(this ICqActionSession session, long groupId, long userId, string nickname)
            => SetGroupNicknameAsync(session, groupId, userId, nickname).Result;
        public static CqLeaveGroupActionResult? LeaveGroup(this ICqActionSession session, long groupId)
            => LeaveGroupAsync(session, groupId).Result;
        public static CqLeaveGroupActionResult? LeaveGroup(this ICqActionSession session, long groupId, bool dismissGroup)
            => LeaveGroupAsync(session, groupId, dismissGroup).Result;
        public static CqSetGroupSpecialTitleActionResult? SetGroupSpecialTitle(this ICqActionSession session, long groupId, long userId, string specialTitle)
            => SetGroupSpecialTitleAsync(session, groupId, userId, specialTitle).Result;
        public static CqGroupSignInActionResult? GroupSignIn(this ICqActionSession session, long groupId)
            => GroupSignInAsync(session, groupId).Result;
        public static CqSetAccountProfileActionResult? SetAccountProfile(this ICqActionSession session, string nickname, string company, string email, string college, string personalNote)
            => SetAccountProfileAsync(session, nickname, company, email, college, personalNote).Result;
        public static CqGetFriendListActionResult? GetFriendList(this ICqActionSession session)
            => GetFriendListAsync(session).Result;
        public static CqGetGroupListActionResult? GetGroupList(this ICqActionSession session)
            => GetGroupListAsync(session).Result;
        public static CqGetUnidirectionalFriendListActionResult? GetUnidirectionalFriendList(this ICqActionSession session)
            => GetUnidirectionalFriendListAsync(session).Result;
        public static CqDeleteFriendActionResult? DeleteFriend(this ICqActionSession session, long userId)
            => DeleteFriendAsync(session, userId).Result;
        public static CqDeleteUnidirectionalFriendActionResult? DeleteUnidirectionalFriend(this ICqActionSession session, long userId)
            => DeleteUnidirectionalFriendAsync(session, userId).Result;
        public static CqCanSendImageActionResult CandSendImage(this ICqActionSession session)
            => CanSendImageAsync(session).Result;
        public static CqCanSendRecordActionResult CandSendRecord(this ICqActionSession session)
            => CanSendRecordAsync(session).Result;

        public static CqGetCookiesActionResult? GetCookies(this ICqActionSession session, string domain)
            => GetCookiesAsync(session, domain).Result;
        public static CqGetCsrfTokenActionResult? GetCsrfToken(this ICqActionSession session)
            => GetCsrfTokenAsync(session).Result;

        public static CqDownloadFileActionResult? DownloadFile(this ICqActionSession session, string url, int threadCount, Dictionary<string, string> headers)
            => DownloadFileAsync(session, url, threadCount, headers).Result;
        public static CqGetOnlineClientsActionResult? GetOnlineClients(this ICqActionSession session)
            => GetOnlineClientsAsync(session).Result;
        public static CqGetOnlineClientsActionResult? GetOnlineClients(this ICqActionSession session, bool noCache)
            => GetOnlineClientsAsync(session, noCache).Result;

        public static CqSetEssenceMessageActionResult? SetEssenceMessage(this ICqActionSession session, long messageId)
            => SetEssenceMessageAsync(session, messageId).Result;
        public static CqDeleteEssenceMessageActionResult? DeleteEssenceMessage(this ICqActionSession session, long messageId)
            => DeleteEssenceMessageAsync(session, messageId).Result;
        public static CqGetEssenceMessageListActionResult? GetEssenceMessageList(this ICqActionSession session, long groupId)
            => GetEssenceMessageListAsync(session, groupId).Result;

        public static CqGetModelShowActionResult? GetModelShow(this ICqActionSession session, string model)
            => GetModelShowAsync(session, model).Result;
        public static CqSetModelShowActionResult? SetModelShow(this ICqActionSession session, string model, string modelShow)
            => SetModelShowAsync(session, model, modelShow).Result;
        public static CqCheckUrlSafetyActionResult? CheckUrlSafety(this ICqActionSession session, string url)
            => CheckUrlSafetyAsync(session, url).Result;
        public static CqGetVersionInformationActionResult? GetVersionInformation(this ICqActionSession session)
            => GetVersionInformationAsync(session).Result;

        public static CqReloadEventFilterActionResult? ReloadEventFilter(this ICqActionSession session, string file)
            => ReloadEventFilterAsync(session, file).Result;
        #endregion
    }
}