using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// CQ 动作执行会话拓展
/// </summary>
public static class CqActionSessionExtensions
{
    /// <summary>
    /// 执行一个动作
    /// </summary>
    /// <typeparam name="TAction">操作类型</typeparam>
    /// <typeparam name="TActionResult">操作结果类型</typeparam>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="action">操作</param>
    /// <returns>用于等待结果的任务</returns>
    public static async Task<TActionResult?> InvokeActionAsync<TAction, TActionResult>(this ICqActionSession session, TAction action)
        where TAction : CqAction
        where TActionResult : CqActionResult
    {
        CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
        return rst as TActionResult;
    }

    #region 异步方法

    /// <summary>
    /// 异步发送私聊消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="message">消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, CqMessage message) =>
        session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, message));

    /// <summary>
    /// 异步发送私聊消息 (临时会话)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="groupId">临时会话的群</param>
    /// <param name="message">消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendPrivateMessageActionResult?> SendPrivateMessageAsync(this ICqActionSession session, long userId, long groupId, CqMessage message) =>
        session.InvokeActionAsync<CqSendPrivateMessageAction, CqSendPrivateMessageActionResult>(new CqSendPrivateMessageAction(userId, groupId, message));

    /// <summary>
    /// 异步发送群消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendGroupMessageActionResult?> SendGroupMessageAsync(this ICqActionSession session, long groupId, CqMessage message) =>
        session.InvokeActionAsync<CqSendGroupMessageAction, CqSendGroupMessageActionResult>(new CqSendGroupMessageAction(groupId, message));

    /// <summary>
    /// 异步发送消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageType">消息类型</param>
    /// <param name="userId">用户 QQ (如果你要发送私聊消息, 这里不能为空)</param>
    /// <param name="groupId">群号 (如果你要发送群聊消息, 这里不能为空)</param>
    /// <param name="message">消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, CqMessage message) =>
        session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(messageType, userId, groupId, message));

    /// <summary>
    /// 异步发送消息 (自动识别消息类型, 如果用户 QQ 和群号都指定了, 那么发送私聊消息)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ (如果你要发送私聊消息, 这里不能为空)</param>
    /// <param name="groupId">群号 (如果你要发送群聊消息, 这里不能为空)</param>
    /// <param name="message">消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendMessageActionResult?> SendMessageAsync(this ICqActionSession session, long? userId, long? groupId, CqMessage message) =>
        session.InvokeActionAsync<CqSendMessageAction, CqSendMessageActionResult>(new CqSendMessageAction(userId, groupId, message));

    /// <summary>
    /// 异步撤回消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">要撤回的消息的 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqRecallMessageActionResult?> RecallMessageAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqRecallMessageAction, CqRecallMessageActionResult>(new CqRecallMessageAction(messageId));

    /// <summary>
    /// 异步发送群转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="forwardMessage">转发消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendGroupForwardMessageActionResult?> SendGroupForwardMessageAsync(this ICqActionSession session, long groupId, CqForwardMessage forwardMessage) =>
        session.InvokeActionAsync<CqSendGroupForwardMessageAction, CqSendGroupForwardMessageActionResult>(new CqSendGroupForwardMessageAction(groupId, forwardMessage));

    /// <summary>
    /// 异步发送私聊转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="forwardMessage">转发消息</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSendPrivateForwardMessageActionResult?> SendPrivateForwardMessageAsync(this ICqActionSession session, long userId, CqForwardMessage forwardMessage) =>
        session.InvokeActionAsync<CqSendPrivateForwardMessageAction, CqSendPrivateForwardMessageActionResult>(new CqSendPrivateForwardMessageAction(userId, forwardMessage));

    /// <summary>
    /// 异步获取消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetMessageActionResult?> GetMessageAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqGetMessageAction, CqGetMessageActionResult>(new CqGetMessageAction(messageId));

    /// <summary>
    /// 异步获取转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetForwardMessageActionResult?> GetForwardMessageAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqGetForwardMessageAction, CqGetForwardMessageActionResult>(new CqGetForwardMessageAction(messageId));

    /// <summary>
    /// 异步获取图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="filename">文件名</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetImageActionResult?> GetImageAsync(this ICqActionSession session, string filename) =>
        session.InvokeActionAsync<CqGetImageAction, CqGetImageActionResult>(new CqGetImageAction(filename));

    /// <summary>
    /// 异步禁言群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="duration">时长</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupMemberActionResult?> BanGroupMemberAsync(this ICqActionSession session, long groupId, long userId, TimeSpan duration) =>
        session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, duration));

    /// <summary>
    /// 异步解除禁言群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupMemberActionResult?> CancelBanGroupMemberAsync(this ICqActionSession session, long groupId, long userId) =>
        session.InvokeActionAsync<CqBanGroupMemberAction, CqBanGroupMemberActionResult>(new CqBanGroupMemberAction(groupId, userId, TimeSpan.Zero));

    /// <summary>
    /// 异步禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymous">匿名对象</param>
    /// <param name="duration">时长</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous, TimeSpan duration) =>
        session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, duration));
    
    /// <summary>
    /// 异步禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymousFlag">匿名标识</param>
    /// <param name="duration">时长</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAnonymousMemberActionResult?> BanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag, TimeSpan duration) =>
        session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, duration));

    /// <summary>
    /// 异步解除禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymous">匿名对象</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous) =>
        session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymous, TimeSpan.Zero));

    /// <summary>
    /// 异步解除禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymousFlag">匿名标识</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAnonymousMemberActionResult?> CancelBanGroupAnonymousMemberAsync(this ICqActionSession session, long groupId, string anonymousFlag) =>
        session.InvokeActionAsync<CqBanGroupAnonymousMemberAction, CqBanGroupAnonymousMemberActionResult>(new CqBanGroupAnonymousMemberAction(groupId, anonymousFlag, TimeSpan.Zero));

    /// <summary>
    /// 异步开启全体禁言
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAllMembersActionResult?> BanGroupAllMembersAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, true));

    /// <summary>
    /// 异步解除全体禁言
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqBanGroupAllMembersActionResult?> CancelBanGroupAllMembersAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqBanGroupAllMembersAction, CqBanGroupAllMembersActionResult>(new CqBanGroupAllMembersAction(groupId, false));

    /// <summary>
    /// 异步踢出群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="rejectRequest">拒绝此人再次加群</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqKickGroupMemberActionResult?> KickGroupMemberAsync(this ICqActionSession session, long groupId, long userId, bool rejectRequest) =>
        session.InvokeActionAsync<CqKickGroupMemberAction, CqKickGroupMemberActionResult>(new CqKickGroupMemberAction(groupId, userId, rejectRequest));

    /// <summary>
    /// 异步处理好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="approve">是否同意</param>
    /// <param name="remark">备注 (如果拒绝请求, 则此参数无用)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleFriendRequestActionResult?> HandleFriendRequestAsync(this ICqActionSession session, string flag, bool approve, string? remark) =>
        session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, approve, remark));

    /// <summary>
    /// 异步同意好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="remark">备注</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleFriendRequestActionResult?> ApproveFriendRequestAsync(this ICqActionSession session, string flag, string? remark) =>
        session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, true, remark));

    /// <summary>
    /// 异步拒绝好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleFriendRequestActionResult?> RejectFriendRequestAsync(this ICqActionSession session, string flag) =>
        session.InvokeActionAsync<CqHandleFriendRequestAction, CqHandleFriendRequestActionResult>(new CqHandleFriendRequestAction(flag, false, null));

    /// <summary>
    /// 异步处理群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <param name="approve">是否同意</param>
    /// <param name="reason">拒绝原因 (如果同意请求, 则此参数无用)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleGroupRequestActionResult?> HandleGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason) =>
        session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, approve, reason));

    /// <summary>
    /// 异步同意群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleGroupRequestActionResult?> ApproveGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType) =>
        session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, true, null));

    /// <summary>
    /// 异步拒绝群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <param name="reason">拒绝原因</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqHandleGroupRequestActionResult?> RejectGroupRequestAsync(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason) =>
        session.InvokeActionAsync<CqHandleGroupRequestAction, CqHandleGroupRequestActionResult>(new CqHandleGroupRequestAction(flag, requestType, false, reason));

    /// <summary>
    /// 异步获取登陆信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetLoginInformationActionResult?> GetLoginInformationAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetLoginInformationAction, CqGetLoginInformationActionResult>(new CqGetLoginInformationAction());

    /// <summary>
    /// 异步获取陌生人信息 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetStrangerInformationActionResult?> GetStrangerInformationAsync(this ICqActionSession session, long userId) =>
        session.InvokeActionAsync<CqGetStrangerInformationAction, CqGetStrangerInformationActionResult>(new CqGetStrangerInformationAction(userId));

    /// <summary>
    /// 异步获取陌生人信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetStrangerInformationActionResult?> GetStrangerInformationAsync(this ICqActionSession session, long userId, bool noCache) =>
        session.InvokeActionAsync<CqGetStrangerInformationAction, CqGetStrangerInformationActionResult>(new CqGetStrangerInformationAction(userId, noCache));

    /// <summary>
    /// 异步获取群信息 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupInformationActionResult?> GetGroupInformationAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGetGroupInformationAction, CqGetGroupInformationActionResult>(new CqGetGroupInformationAction(groupId));

    /// <summary>
    /// 异步获取群信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupInformationActionResult?> GetGroupInformationAsync(this ICqActionSession session, long groupId, bool noCache) =>
        session.InvokeActionAsync<CqGetGroupInformationAction, CqGetGroupInformationActionResult>(new CqGetGroupInformationAction(groupId, noCache));

    /// <summary>
    /// 异步获取群成员信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupMemberInformationActionResult?> GetGroupMemberInformationAsync(this ICqActionSession session, long groupId, long userId) =>
        session.InvokeActionAsync<CqGetGroupMemberInformationAction, CqGetGroupMemberInformationActionResult>(new CqGetGroupMemberInformationAction(groupId, userId));

    /// <summary>
    /// 异步获取群成员信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupMemberInformationActionResult?> GetGroupMemberInformationAsync(this ICqActionSession session, long groupId, long userId, bool noCache) =>
        session.InvokeActionAsync<CqGetGroupMemberInformationAction, CqGetGroupMemberInformationActionResult>(new CqGetGroupMemberInformationAction(groupId, userId, noCache));

    /// <summary>
    /// 异步标记消息已读
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqMarkMessageAsReadActionResult?> MarkMessageAsReadAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqMarkMessageAsReadAction, CqMarkMessageAsReadActionResult>(new CqMarkMessageAsReadAction(messageId));


    /// <summary>
    /// 异步设置群是否启用匿名聊天
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="enable">是否启用</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupAnonymousActionResult?> SetGroupAnonymousAsync(this ICqActionSession session, long groupId, bool enable) =>
        session.InvokeActionAsync<CqSetGroupAnonymousAction, CqSetGroupAnonymousActionResult>(new CqSetGroupAnonymousAction(groupId, enable));


    /// <summary>
    /// 异步设置群名
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="groupName">群名</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupNameActionResult?> SetGroupNameAsync(this ICqActionSession session, long groupId, string groupName) =>
        session.InvokeActionAsync<CqSetGroupNameAction, CqSetGroupNameActionResult>(new CqSetGroupNameAction(groupId, groupName));


    /// <summary>
    /// 异步设置群头像 (UseCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatarAsync(this ICqActionSession session, long groupId, string file) =>
        session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file));


    /// <summary>
    /// 异步设置群头像
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="useCache">使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupAvatarActionResult?> SetGroupAvatarAsync(this ICqActionSession session, long groupId, string file, bool useCache) =>
        session.InvokeActionAsync<CqSetGroupAvatarAction, CqSetGroupAvatarActionResult>(new CqSetGroupAvatarAction(groupId, file, useCache));


    /// <summary>
    /// 异步设置群昵称
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="nickname">昵称</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupNicknameActionResult?> SetGroupNicknameAsync(this ICqActionSession session, long groupId, long userId, string nickname) =>
        session.InvokeActionAsync<CqSetGroupNicknameAction, CqSetGroupNicknameActionResult>(new CqSetGroupNicknameAction(groupId, userId, nickname));


    /// <summary>
    /// 异步退群 (DismissGroup = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqLeaveGroupActionResult?> LeaveGroupAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId));


    /// <summary>
    /// 异步退群
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="dismissGroup">是否解散群聊 (只有当自己是群主时有效)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqLeaveGroupActionResult?> LeaveGroupAsync(this ICqActionSession session, long groupId, bool dismissGroup) =>
        session.InvokeActionAsync<CqLeaveGroupAction, CqLeaveGroupActionResult>(new CqLeaveGroupAction(groupId, dismissGroup));

    /// <summary>
    /// 异步设置群专属头衔
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="specialTitle">专属头衔</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetGroupSpecialTitleActionResult?> SetGroupSpecialTitleAsync(this ICqActionSession session, long groupId, long userId, string specialTitle) =>
        session.InvokeActionAsync<CqSetGroupSpecialTitleAction, CqSetGroupSpecialTitleActionResult>(new CqSetGroupSpecialTitleAction(groupId, userId, specialTitle));

    /// <summary>
    /// 异步群签到
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGroupSignInActionResult?> GroupSignInAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGroupSignInAction, CqGroupSignInActionResult>(new CqGroupSignInAction(groupId));

    /// <summary>
    /// 异步设置账号信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="nickname">昵称</param>
    /// <param name="company">公司</param>
    /// <param name="email">邮箱</param>
    /// <param name="college">大学</param>
    /// <param name="personalNote">个人签名</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetAccountProfileActionResult?> SetAccountProfileAsync(this ICqActionSession session, string nickname, string company, string email, string college, string personalNote) =>
        session.InvokeActionAsync<CqSetAccountProfileAction, CqSetAccountProfileActionResult>(new CqSetAccountProfileAction(nickname, company, email, college, personalNote));

    /// <summary>
    /// 异步获取好友列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetFriendListActionResult?> GetFriendListAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetFriendListAction, CqGetFriendListActionResult>(new CqGetFriendListAction());

    /// <summary>
    /// 异步获取群列表 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupListActionResult?> GetGroupListAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetGroupListAction, CqGetGroupListActionResult>(new CqGetGroupListAction());

    /// <summary>
    /// 异步获取群列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupListActionResult?> GetGroupListAsync(this ICqActionSession session, bool noCache) =>
        session.InvokeActionAsync<CqGetGroupListAction, CqGetGroupListActionResult>(new CqGetGroupListAction(noCache));

    /// <summary>
    /// 异步获取群成员列表 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupMemberListActionResult?> GetGroupMemberListAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGetGroupMemberListAction, CqGetGroupMemberListActionResult>(new CqGetGroupMemberListAction(groupId));

    /// <summary>
    /// 异步获取群成员列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupMemberListActionResult?> GetGroupMemberListAsync(this ICqActionSession session, long groupId, bool noCache) =>
        session.InvokeActionAsync<CqGetGroupMemberListAction, CqGetGroupMemberListActionResult>(new CqGetGroupMemberListAction(groupId, noCache));

    /// <summary>
    /// 异步获取单向好友列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetUnidirectionalFriendListActionResult?> GetUnidirectionalFriendListAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetUnidirectionalFriendListAction, CqGetUnidirectionalFriendListActionResult>(new CqGetUnidirectionalFriendListAction());

    /// <summary>
    /// 异步删除好友
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDeleteFriendActionResult?> DeleteFriendAsync(this ICqActionSession session, long userId) =>
        session.InvokeActionAsync<CqDeleteFriendAction, CqDeleteFriendActionResult>(new CqDeleteFriendAction(userId));

    /// <summary>
    /// 异步删除单项好友
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDeleteUnidirectionalFriendActionResult?> DeleteUnidirectionalFriendAsync(this ICqActionSession session, long userId) =>
        session.InvokeActionAsync<CqDeleteUnidirectionalFriendAction, CqDeleteUnidirectionalFriendActionResult>(new CqDeleteUnidirectionalFriendAction(userId));

    /// <summary>
    /// 异步判断是否能发送图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqCanSendImageActionResult?> CanSendImageAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqCanSendImageAction, CqCanSendImageActionResult>(new CqCanSendImageAction());

    /// <summary>
    /// 异步判断是否能发送语音
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqCanSendRecordActionResult?> CanSendRecordAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqCanSendRecordAction, CqCanSendRecordActionResult>(new CqCanSendRecordAction());


    /// <summary>
    /// 异步获取 Cookies
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="domain">域名</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetCookiesActionResult?> GetCookiesAsync(this ICqActionSession session, string domain) =>
        session.InvokeActionAsync<CqGetCookiesAction, CqGetCookiesActionResult>(new CqGetCookiesAction(domain));

    /// <summary>
    /// 异步获取 CSRF Token
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetCsrfTokenActionResult?> GetCsrfTokenAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetCsrfTokenAction, CqGetCsrfTokenActionResult>(new CqGetCsrfTokenAction());


    /// <summary>
    /// 异步下载文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="url">链接</param>
    /// <param name="threadCount">线程数</param>
    /// <param name="headers">请求头</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDownloadFileActionResult?> DownloadFileAsync(this ICqActionSession session, string url, int threadCount, Dictionary<string, string> headers) =>
        session.InvokeActionAsync<CqDownloadFileAction, CqDownloadFileActionResult>(new CqDownloadFileAction(url, threadCount, headers));

    /// <summary>
    /// 异步获取在线客户端 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetOnlineClientsActionResult?> GetOnlineClientsAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction());

    /// <summary>
    /// 异步获取在线客户端
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetOnlineClientsActionResult?> GetOnlineClientsAsync(this ICqActionSession session, bool noCache) =>
        session.InvokeActionAsync<CqGetOnlineClientsAction, CqGetOnlineClientsActionResult>(new CqGetOnlineClientsAction(noCache));
    

    /// <summary>
    /// 异步设置精华消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetEssenceMessageActionResult?> SetEssenceMessageAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqSetEssenceMessageAction, CqSetEssenceMessageActionResult>(new CqSetEssenceMessageAction(messageId));

    /// <summary>
    /// 异步删除精华消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDeleteEssenceMessageActionResult?> DeleteEssenceMessageAsync(this ICqActionSession session, long messageId) =>
        session.InvokeActionAsync<CqDeleteEssenceMessageAction, CqDeleteEssenceMessageActionResult>(new CqDeleteEssenceMessageAction(messageId));

    /// <summary>
    /// 异步获取精华消息列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetEssenceMessageListActionResult?> GetEssenceMessageListAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGetEssenceMessageListAction, CqGetEssenceMessageListActionResult>(new CqGetEssenceMessageListAction(groupId));


    /// <summary>
    /// 异步获取显示机型
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="model">机型</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetModelShowActionResult?> GetModelShowAsync(this ICqActionSession session, string model) =>
        session.InvokeActionAsync<CqGetModelShowAction, CqGetModelShowActionResult>(new CqGetModelShowAction(model));
    
    /// <summary>
    /// 异步设置显示机型
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="model">机型</param>
    /// <param name="modelShow">显示机型</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqSetModelShowActionResult?> SetModelShowAsync(this ICqActionSession session, string model, string modelShow) =>
        session.InvokeActionAsync<CqSetModelShowAction, CqSetModelShowActionResult>(new CqSetModelShowAction(model, modelShow));
    
    /// <summary>
    /// 异步检查 URL 安全性
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="url">链接</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqCheckUrlSafetyActionResult?> CheckUrlSafetyAsync(this ICqActionSession session, string url) =>
        session.InvokeActionAsync<CqCheckUrlSafetyAction, CqCheckUrlSafetyActionResult>(new CqCheckUrlSafetyAction(url));

    /// <summary>
    /// 异步获取版本信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetVersionInformationActionResult?> GetVersionInformationAsync(this ICqActionSession session) =>
        session.InvokeActionAsync<CqGetVersionInformationAction, CqGetVersionInformationActionResult>(new CqGetVersionInformationAction());


    /// <summary>
    /// 异步重载事件过滤器
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="file">文件</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqReloadEventFilterActionResult?> ReloadEventFilterAsync(this ICqActionSession session, string file) =>
        session.InvokeActionAsync<CqReloadEventFilterAction, CqReloadEventFilterActionResult>(new CqReloadEventFilterAction(file));

    /// <summary>
    /// 异步获取分词
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="content">内容</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetWordSlicesActionResult?> GetWordSlicesAsync(this ICqActionSession session, string content) =>
        session.InvokeActionAsync<CqGetWordSlicesAction, CqGetWordSlicesActionResult>(new CqGetWordSlicesAction(content));

    /// <summary>
    /// 异步 OCR 识别图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="image">图片 ID</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqOcrImageActionResult?> OcrImageAsync(this ICqActionSession session, string image) =>
        session.InvokeActionAsync<CqOcrImageAction, CqOcrImageActionResult>(new CqOcrImageAction(image));



    /// <summary>
    /// 异步上传群文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <param name="folder">目录</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqUploadGroupFileActionResult?> UploadGroupFileAsync(this ICqActionSession session, long groupId, string file, string name, string folder) =>
        session.InvokeActionAsync<CqUploadGroupFileAction, CqUploadGroupFileActionResult>(new CqUploadGroupFileAction(groupId, file, name, folder));

    /// <summary>
    /// 异步上传群文件 (到根目录)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqUploadGroupFileActionResult?> UploadGroupFileAsync(this ICqActionSession session, long groupId, string file, string name) =>
        session.InvokeActionAsync<CqUploadGroupFileAction, CqUploadGroupFileActionResult>(new CqUploadGroupFileAction(groupId, file, name));

    /// <summary>
    /// 异步删除群文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件 ID (参考 <see cref="CqGroupFile"/>)</param>
    /// <param name="busid">文件类型 (参考 <see cref="CqGroupFile"/>)</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDeleteGroupFileActionResult?> DeleteGroupFileAsync(this ICqActionSession session, long groupId, string fileId, int busid) =>
        session.InvokeActionAsync<CqDeleteGroupFileAction, CqDeleteGroupFileActionResult>(new CqDeleteGroupFileAction(groupId, fileId, busid));

    /// <summary>
    /// 异步创建群文件目录
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="name">名称</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqCreateGroupFolderActionResult?> CreateGroupFolderAsync(this ICqActionSession session, long groupId, string name) =>
        session.InvokeActionAsync<CqCreateGroupFolderAction, CqCreateGroupFolderActionResult>(new CqCreateGroupFolderAction(groupId, name));

    /// <summary>
    /// 异步删除群文件目录
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="folderId">目录</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqDeleteGroupFolderActionResult?> DeleteGroupFolderAsync(this ICqActionSession session, long groupId, string folderId) =>
        session.InvokeActionAsync<CqDeleteGroupFolderAction, CqDeleteGroupFolderActionResult>(new CqDeleteGroupFolderAction(groupId, folderId));

    /// <summary>
    /// 异步获取群文件系统信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupFileSystemInformationActionResult?> GetGroupFileSystemInformationAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGetGroupFileSystemInformationAction, CqGetGroupFileSystemInformationActionResult>(new CqGetGroupFileSystemInformationAction(groupId));

    /// <summary>
    /// 异步获取群根目录文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupRootFilesActionResult?> GetGroupRootFilesAsync(this ICqActionSession session, long groupId) =>
        session.InvokeActionAsync<CqGetGroupRootFilesAction, CqGetGroupRootFilesActionResult>(new CqGetGroupRootFilesAction(groupId));

    /// <summary>
    /// 异步获取群指定目录文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="folderId">目录</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqGetGroupFilesByFolderActionResult?> GetGroupFilesByFolderAsync(this ICqActionSession session, long groupId, string folderId) =>
        session.InvokeActionAsync<CqGetGroupFilesByFolderAction, CqGetGroupFilesByFolderActionResult>(new CqGetGroupFilesByFolderAction(groupId, folderId));

    /// <summary>
    /// 异步上传私聊文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <returns>用于等待结果的任务</returns>
    public static Task<CqUploadPrivateFileActionResult?> UploadPrivateFileAsync(this ICqActionSession session, long userId, string file, string name) =>
        session.InvokeActionAsync<CqUploadPrivateFileAction, CqUploadPrivateFileActionResult>(new CqUploadPrivateFileAction(userId, file, name));


    /// <summary>
    /// 异步设置群管理员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="enable">是否设置为管理员</param>
    /// <returns></returns>
    public static Task<CqSetGroupAdministratorActionResult?> SetGroupAdministratorAsync(this ICqActionSession session, long groupId, long userId, bool enable) =>
        session.InvokeActionAsync<CqSetGroupAdministratorAction, CqSetGroupAdministratorActionResult>(new CqSetGroupAdministratorAction(groupId, userId, enable));

    /// <summary>
    /// 获取群文件资源链接
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件 ID (参考 <see cref="CqGroupFile"/>)</param>
    /// <param name="busid">文件类型 (参考 <see cref="CqGroupFile"/>)</param>
    /// <returns></returns>
    public static Task<CqGetGroupFileUrlActionResult?> GetGroupFileUrlAsync(this ICqActionSession session, long groupId, string fileId, int busid) =>
        session.InvokeActionAsync<CqGetGroupFileUrlAction, CqGetGroupFileUrlActionResult>(new CqGetGroupFileUrlAction(groupId, fileId, busid));

    #endregion

































    #region 同步包装

    /// <summary>
    /// 发送私聊消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="message">消息</param>
    /// <returns>操作结果</returns>
    public static CqSendPrivateMessageActionResult? SendPrivateMessage(this ICqActionSession session, long userId, CqMessage message) =>
        SendPrivateMessageAsync(session, userId, message).Result;

    /// <summary>
    /// 发送私聊消息 (临时会话)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    /// <returns>操作结果</returns>
    public static CqSendPrivateMessageActionResult? SendPrivateMessage(this ICqActionSession session, long userId, long groupId, CqMessage message) =>
        SendPrivateMessageAsync(session, userId, groupId, message).Result;

    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    /// <returns>操作结果</returns>
    public static CqSendGroupMessageActionResult? SendGroupMessage(this ICqActionSession session, long groupId, CqMessage message) =>
        SendGroupMessageAsync(session, groupId, message).Result;

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageType">消息类型</param>
    /// <param name="userId">用户 QQ (如果你要发送私聊消息, 这里不能为空)</param>
    /// <param name="groupId">群号 (如果你要发送群聊消息, 这里不能为空)</param>
    /// <param name="message">消息</param>
    /// <returns>操作结果</returns>
    public static CqSendMessageActionResult? SendMessage(this ICqActionSession session, CqMessageType messageType, long? userId, long? groupId, CqMessage message) =>
        SendMessageAsync(session, messageType, userId, groupId, message).Result;

    /// <summary>
    /// 发送消息 (自动识别消息类型, 如果用户 QQ 和群号都指定了, 那么发送私聊消息)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ (如果你要发送私聊消息, 这里不能为空)</param>
    /// <param name="groupId">群号 (如果你要发送群聊消息, 这里不能为空)</param>
    /// <param name="message">消息</param>
    /// <returns>操作结果</returns>
    public static CqSendMessageActionResult? SendMessage(this ICqActionSession session, long? userId, long? groupId, CqMessage message) =>
        SendMessageAsync(session, userId, groupId, message).Result;

    /// <summary>
    /// 撤回消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">要撤回的消息的 ID</param>
    /// <returns>操作结果</returns>
    public static CqRecallMessageActionResult? RecallMessage(this ICqActionSession session, long messageId) =>
        RecallMessageAsync(session, messageId).Result;

    /// <summary>
    /// 发送群转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="forwardMessage">转发消息</param>
    /// <returns>操作结果</returns>
    public static CqSendGroupForwardMessageActionResult? SendGroupForwardMessage(this ICqActionSession session, long groupId, CqForwardMessage forwardMessage) =>
        SendGroupForwardMessageAsync(session, groupId, forwardMessage).Result;

    /// <summary>
    /// 发送私聊转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="forwardMessage">转发消息</param>
    /// <returns>操作结果</returns>
    public static CqSendPrivateForwardMessageActionResult? SendPrivateForwardMessage(this ICqActionSession session, long userId, CqForwardMessage forwardMessage) =>
        SendPrivateForwardMessageAsync(session, userId, forwardMessage).Result;

    /// <summary>
    /// 获取消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>操作结果</returns>
    public static CqGetMessageActionResult? GetMessage(this ICqActionSession session, long messageId) =>
        GetMessageAsync(session, messageId).Result;

    /// <summary>
    /// 获取转发消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>操作结果</returns>
    public static CqGetForwardMessageActionResult? GetForwwardMessage(this ICqActionSession session, long messageId) =>
        GetForwardMessageAsync(session, messageId).Result;

    /// <summary>
    /// 获取图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="filename">文件名</param>
    /// <returns>操作结果</returns>
    public static CqGetImageActionResult? GetImage(this ICqActionSession session, string filename) =>
        GetImageAsync(session, filename).Result;

    /// <summary>
    /// 禁言群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="duration">时长</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupMemberActionResult? BanGroupMember(this ICqActionSession session, long groupId, long userId, TimeSpan duration) =>
        BanGroupMemberAsync(session, groupId, userId, duration).Result;

    /// <summary>
    /// 解除禁言群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupMemberActionResult? CancelBanGroupMember(this ICqActionSession session, long groupId, long userId) =>
        CancelBanGroupMemberAsync(session, groupId, userId).Result;

    /// <summary>
    /// 禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymous">匿名对象</param>
    /// <param name="duration">时长</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupAnonymousMemberActionResult? BanGroupAnonymousMember(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous, TimeSpan duration) =>
        BanGroupAnonymousMemberAsync(session, groupId, anonymous, duration).Result;

    /// <summary>
    /// 禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymousFlag">匿名标识</param>
    /// <param name="duration">时长</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupAnonymousMemberActionResult? BanGroupAnonymousMember(this ICqActionSession session, long groupId, string anonymousFlag, TimeSpan duration) =>
        BanGroupAnonymousMemberAsync(session, groupId, anonymousFlag, duration).Result;

    /// <summary>
    /// 解除禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymous">匿名对象</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupAnonymousMemberActionResult? CancelBanGroupAnonymousMember(this ICqActionSession session, long groupId, CqAnonymousInfomation anonymous) =>
        CancelBanGroupAnonymousMemberAsync(session, groupId, anonymous).Result;

    /// <summary>
    /// 解除禁言群匿名成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="anonymousFlag">匿名标识</param>
    /// <returns>操作结果</returns>
    public static CqBanGroupAnonymousMemberActionResult? CancelBanGroupAnonymousMember(this ICqActionSession session, long groupId, string anonymousFlag) =>
        CancelBanGroupAnonymousMemberAsync(session, groupId, anonymousFlag).Result;

    /// <summary>
    /// 开启全体禁言
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static CqBanGroupAllMembersActionResult? BanGroupAllMembers(this ICqActionSession session, long groupId) =>
        session.BanGroupAllMembersAsync(groupId).Result;

    /// <summary>
    /// 解除全体禁言
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>用于等待结果的任务</returns>
    public static CqBanGroupAllMembersActionResult? CancelBanGroupAllMembers(this ICqActionSession session, long groupId) =>
        session.CancelBanGroupAllMembersAsync(groupId).Result;

    /// <summary>
    /// 踢出群成员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="rejectRequest">拒绝此人再次加群</param>
    /// <returns>操作结果</returns>
    public static CqKickGroupMemberActionResult? KickGroupMember(this ICqActionSession session, long groupId, long userId, bool rejectRequest) =>
        KickGroupMemberAsync(session, groupId, userId, rejectRequest).Result;

    /// <summary>
    /// 处理好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="approve">是否同意</param>
    /// <param name="remark">备注 (如果拒绝请求, 则此参数无用)</param>
    /// <returns>操作结果</returns>
    public static CqHandleFriendRequestActionResult? HandleFriendRequest(this ICqActionSession session, string flag, bool approve, string? remark) =>
        HandleFriendRequestAsync(session, flag, approve, remark).Result;

    /// <summary>
    /// 同意好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="remark">备注</param>
    /// <returns>操作结果</returns>
    public static CqHandleFriendRequestActionResult? ApproveFriendRequest(this ICqActionSession session, string flag, string? remark) =>
        ApproveFriendRequestAsync(session, flag, remark).Result;

    /// <summary>
    /// 拒绝好友请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <returns>操作结果</returns>
    public static CqHandleFriendRequestActionResult? RejectFriendRequest(this ICqActionSession session, string flag) =>
        RejectFriendRequestAsync(session, flag).Result;

    /// <summary>
    /// 处理群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <param name="approve">是否同意</param>
    /// <param name="reason">拒绝原因 (如果同意请求, 则此参数无用)</param>
    /// <returns>操作结果</returns>
    public static CqHandleGroupRequestActionResult? HandleGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, bool approve, string? reason) =>
        HandleGroupRequestAsync(session, flag, requestType, approve, reason).Result;

    /// <summary>
    /// 同意群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <returns>操作结果</returns>
    public static CqHandleGroupRequestActionResult? ApproveGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType) =>
        ApproveGroupRequestAsync(session, flag, requestType).Result;

    /// <summary>
    /// 拒绝群请求
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="flag">请求标识 (在请求上报中取得)</param>
    /// <param name="requestType">请求类型 (在请求上报中取得)</param>
    /// <param name="reason">拒绝原因</param>
    /// <returns>操作结果</returns>
    public static CqHandleGroupRequestActionResult? RejectGroupRequest(this ICqActionSession session, string flag, CqGroupRequestType requestType, string? reason) =>
        RejectGroupRequestAsync(session, flag, requestType, reason).Result;

    /// <summary>
    /// 获取登陆信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetLoginInformationActionResult? GetLoginInformation(this ICqActionSession session) =>
        GetLoginInformationAsync(session).Result;

    /// <summary>
    /// 获取陌生人信息 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>操作结果</returns>
    public static CqGetStrangerInformationActionResult? GetStrangerInformation(this ICqActionSession session, long userId) =>
        GetStrangerInformationAsync(session, userId).Result;

    /// <summary>
    /// 获取陌生人信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetStrangerInformationActionResult? GetStrangerInformation(this ICqActionSession session, long userId, bool noCache) =>
        GetStrangerInformationAsync(session, userId, noCache).Result;

    /// <summary>
    /// 获取群信息 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupInformationActionResult? GetGroupInformation(this ICqActionSession session, long groupId) =>
        GetGroupInformationAsync(session, groupId).Result;

    /// <summary>
    /// 获取群信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupInformationActionResult? GetGroupInformation(this ICqActionSession session, long groupId, bool noCache) =>
        GetGroupInformationAsync(session, groupId, noCache).Result;

    /// <summary>
    /// 获取群成员信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupMemberInformationActionResult? GetGroupMemberInformation(this ICqActionSession session, long groupId, long userId) =>
        GetGroupMemberInformationAsync(session, groupId, userId).Result;

    /// <summary>
    /// 获取群成员信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupMemberInformationActionResult? GetGroupMemberInformation(this ICqActionSession session, long groupId, long userId, bool noCache) =>
        GetGroupMemberInformationAsync(session, groupId, userId, noCache).Result;

    /// <summary>
    /// 标记消息已读
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>操作结果</returns>
    public static CqMarkMessageAsReadActionResult? MarkMessageAsRead(this ICqActionSession session, long messageId) =>
        MarkMessageAsReadAsync(session, messageId).Result;

    /// <summary>
    /// 设置群是否启用匿名聊天
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="enable">是否启用</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupAnonymousActionResult? SetGroupAnonymous(this ICqActionSession session, long groupId, bool enable) =>
        SetGroupAnonymousAsync(session, groupId, enable).Result;

    /// <summary>
    /// 设置群名
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupNameActionResult? SetGroupName(this ICqActionSession session, long groupId, string file) =>
        SetGroupNameAsync(session, groupId, file).Result;

    /// <summary>
    /// 设置群头像 (UseCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupAvatarActionResult? SetGroupAvatar(this ICqActionSession session, long groupId, string file) =>
        SetGroupAvatarAsync(session, groupId, file).Result;

    /// <summary>
    /// 设置群头像
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="useCache">使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupAvatarActionResult? SetGroupAvatar(this ICqActionSession session, long groupId, string file, bool useCache) =>
        SetGroupAvatarAsync(session, groupId, file, useCache).Result;

    /// <summary>
    /// 设置群昵称
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="nickname">昵称</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupNicknameActionResult? SetGroupNickname(this ICqActionSession session, long groupId, long userId, string nickname) =>
        SetGroupNicknameAsync(session, groupId, userId, nickname).Result;

    /// <summary>
    /// 退群 (DismissGroup = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqLeaveGroupActionResult? LeaveGroup(this ICqActionSession session, long groupId) =>
        LeaveGroupAsync(session, groupId).Result;

    /// <summary>
    /// 退群
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="dismissGroup">是否解散群聊 (只有当自己是群主时有效)</param>
    /// <returns>操作结果</returns>
    public static CqLeaveGroupActionResult? LeaveGroup(this ICqActionSession session, long groupId, bool dismissGroup) =>
        LeaveGroupAsync(session, groupId, dismissGroup).Result;

    /// <summary>
    /// 设置群专属头衔
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="specialTitle">专属头衔</param>
    /// <returns>操作结果</returns>
    public static CqSetGroupSpecialTitleActionResult? SetGroupSpecialTitle(this ICqActionSession session, long groupId, long userId, string specialTitle) =>
        SetGroupSpecialTitleAsync(session, groupId, userId, specialTitle).Result;

    /// <summary>
    /// 群签到
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGroupSignInActionResult? GroupSignIn(this ICqActionSession session, long groupId) =>
        GroupSignInAsync(session, groupId).Result;

    /// <summary>
    /// 设置账号信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="nickname">昵称</param>
    /// <param name="company">公司</param>
    /// <param name="email">邮箱</param>
    /// <param name="college">大学</param>
    /// <param name="personalNote">个人签名</param>
    /// <returns>操作结果</returns>
    public static CqSetAccountProfileActionResult? SetAccountProfile(this ICqActionSession session, string nickname, string company, string email, string college, string personalNote) =>
        SetAccountProfileAsync(session, nickname, company, email, college, personalNote).Result;

    /// <summary>
    /// 获取好友列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetFriendListActionResult? GetFriendList(this ICqActionSession session) =>
        GetFriendListAsync(session).Result;

    /// <summary>
    /// 获取群列表 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupListActionResult? GetGroupList(this ICqActionSession session) =>
        GetGroupListAsync(session).Result;

    /// <summary>
    /// 获取群列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupListActionResult? GetGroupList(this ICqActionSession session, bool noCache) =>
        GetGroupListAsync(session, noCache).Result;

    /// <summary>
    /// 获取群成员列表 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupMemberListActionResult? GetGroupMemberList(this ICqActionSession session, long groupId) =>
        GetGroupMemberListAsync(session, groupId).Result;

    /// <summary>
    /// 获取群成员列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupMemberListActionResult? GetGroupMemberList(this ICqActionSession session, long groupId, bool noCache) =>
        GetGroupMemberListAsync(session, groupId, noCache).Result;

    /// <summary>
    /// 获取单向好友列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetUnidirectionalFriendListActionResult? GetUnidirectionalFriendList(this ICqActionSession session) =>
        GetUnidirectionalFriendListAsync(session).Result;

    /// <summary>
    /// 删除好友
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>操作结果</returns>
    public static CqDeleteFriendActionResult? DeleteFriend(this ICqActionSession session, long userId) =>
        DeleteFriendAsync(session, userId).Result;

    /// <summary>
    /// 删除单项好友
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <returns>操作结果</returns>
    public static CqDeleteUnidirectionalFriendActionResult? DeleteUnidirectionalFriend(this ICqActionSession session, long userId) =>
        DeleteUnidirectionalFriendAsync(session, userId).Result;

    /// <summary>
    /// 判断是否能发送图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqCanSendImageActionResult? CanSendImage(this ICqActionSession session) =>
        CanSendImageAsync(session).Result;

    /// <summary>
    /// 判断是否能发送语音
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqCanSendRecordActionResult? CanSendRecord(this ICqActionSession session) =>
        CanSendRecordAsync(session).Result;


    /// <summary>
    /// 获取 Cookies
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="domain">域名</param>
    /// <returns>操作结果</returns>
    public static CqGetCookiesActionResult? GetCookies(this ICqActionSession session, string domain) =>
        GetCookiesAsync(session, domain).Result;

    /// <summary>
    /// 获取 CSRF Token
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetCsrfTokenActionResult? GetCsrfToken(this ICqActionSession session) =>
        GetCsrfTokenAsync(session).Result;


    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="url">链接</param>
    /// <param name="threadCount">线程数</param>
    /// <param name="headers">请求头</param>
    /// <returns>操作结果</returns>
    public static CqDownloadFileActionResult? DownloadFile(this ICqActionSession session, string url, int threadCount, Dictionary<string, string> headers) =>
        DownloadFileAsync(session, url, threadCount, headers).Result;

    /// <summary>
    /// 获取在线客户端 (NoCache = false)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetOnlineClientsActionResult? GetOnlineClients(this ICqActionSession session) =>
        GetOnlineClientsAsync(session).Result;

    /// <summary>
    /// 获取在线客户端
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="noCache">不使用缓存</param>
    /// <returns>操作结果</returns>
    public static CqGetOnlineClientsActionResult? GetOnlineClients(this ICqActionSession session, bool noCache) =>
        GetOnlineClientsAsync(session, noCache).Result;


    /// <summary>
    /// 设置精华消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>操作结果</returns>
    public static CqSetEssenceMessageActionResult? SetEssenceMessage(this ICqActionSession session, long messageId) =>
        SetEssenceMessageAsync(session, messageId).Result;

    /// <summary>
    /// 删除精华消息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="messageId">消息 ID</param>
    /// <returns>操作结果</returns>
    public static CqDeleteEssenceMessageActionResult? DeleteEssenceMessage(this ICqActionSession session, long messageId) =>
        DeleteEssenceMessageAsync(session, messageId).Result;

    /// <summary>
    /// 获取精华消息列表
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGetEssenceMessageListActionResult? GetEssenceMessageList(this ICqActionSession session, long groupId) =>
        GetEssenceMessageListAsync(session, groupId).Result;


    /// <summary>
    /// 获取显示机型
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="model">机型</param>
    /// <returns>操作结果</returns>
    public static CqGetModelShowActionResult? GetModelShow(this ICqActionSession session, string model) =>
        GetModelShowAsync(session, model).Result;

    /// <summary>
    /// 设置显示机型
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="model">机型</param>
    /// <param name="modelShow">显示机型</param>
    /// <returns>操作结果</returns>
    public static CqSetModelShowActionResult? SetModelShow(this ICqActionSession session, string model, string modelShow) =>
        SetModelShowAsync(session, model, modelShow).Result;

    /// <summary>
    /// 检查 URL 安全性
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="url">链接</param>
    /// <returns>操作结果</returns>
    public static CqCheckUrlSafetyActionResult? CheckUrlSafety(this ICqActionSession session, string url) =>
        CheckUrlSafetyAsync(session, url).Result;

    /// <summary>
    /// 获取版本信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <returns>操作结果</returns>
    public static CqGetVersionInformationActionResult? GetVersionInformation(this ICqActionSession session) =>
        GetVersionInformationAsync(session).Result;


    /// <summary>
    /// 重载事件过滤器
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="file">文件</param>
    /// <returns>操作结果</returns>
    public static CqReloadEventFilterActionResult? ReloadEventFilter(this ICqActionSession session, string file) =>
        ReloadEventFilterAsync(session, file).Result;

    /// <summary>
    /// 获取分词
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="content">内容</param>
    /// <returns>操作结果</returns>
    public static CqGetWordSlicesActionResult? GetWordSlices(this ICqActionSession session, string content) =>
        GetWordSlicesAsync(session, content).Result;

    /// <summary>
    /// OCR 识别图片
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="image">图片 ID</param>
    /// <returns>操作结果</returns>
    public static CqOcrImageActionResult? OcrImage(this ICqActionSession session, string image) =>
        OcrImageAsync(session, image).Result;



    /// <summary>
    /// 上传群文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <param name="folder">目录</param>
    /// <returns>操作结果</returns>
    public static CqUploadGroupFileActionResult? UploadGroupFile(this ICqActionSession session, long groupId, string file, string name, string folder) =>
        UploadGroupFileAsync(session, groupId, file, name, folder).Result;

    /// <summary>
    /// 上传群文件 (到根目录)
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <returns>操作结果</returns>
    public static CqUploadGroupFileActionResult? UploadGroupFile(this ICqActionSession session, long groupId, string file, string name) =>
        UploadGroupFileAsync(session, groupId, file, name).Result;

    /// <summary>
    /// 删除群文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件 ID (参考 <see cref="CqGroupFile"/>)</param>
    /// <param name="busid">文件类型 (参考 <see cref="CqGroupFile"/>)</param>
    /// <returns>操作结果</returns>
    public static CqDeleteGroupFileActionResult? DeleteGroupFile(this ICqActionSession session, long groupId, string fileId, int busid) =>
        DeleteGroupFileAsync(session, groupId, fileId, busid).Result;

    /// <summary>
    /// 创建群文件目录
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="name">名称</param>
    /// <returns>操作结果</returns>
    public static CqCreateGroupFolderActionResult? CreateGroupFolder(this ICqActionSession session, long groupId, string name) =>
        CreateGroupFolderAsync(session, groupId, name).Result;

    /// <summary>
    /// 删除群文件目录
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="folderId">目录</param>
    /// <returns>操作结果</returns>
    public static CqDeleteGroupFolderActionResult? DeleteGroupFolder(this ICqActionSession session, long groupId, string folderId) =>
        DeleteGroupFolderAsync(session, groupId, folderId).Result;

    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupFileSystemInformationActionResult? GetGroupFileSystemInformation(this ICqActionSession session, long groupId) =>
        GetGroupFileSystemInformationAsync(session, groupId).Result;

    /// <summary>
    /// 获取群根目录文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupRootFilesActionResult? GetGroupRootFiles(this ICqActionSession session, long groupId) =>
        GetGroupRootFilesAsync(session, groupId).Result;

    /// <summary>
    /// 获取群指定目录文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="folderId">目录</param>
    /// <returns>操作结果</returns>
    public static CqGetGroupFilesByFolderActionResult? GetGroupFilesByFolder(this ICqActionSession session, long groupId, string folderId) =>
        GetGroupFilesByFolderAsync(session, groupId, folderId).Result;

    /// <summary>
    /// 上传私聊文件
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <returns>操作结果</returns>
    public static CqUploadPrivateFileActionResult? UploadPrivateFile(this ICqActionSession session, long userId, string file, string name) =>
        UploadPrivateFileAsync(session, userId, file, name).Result;

    /// <summary>
    /// 设置群管理员
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="enable">是否设置为管理员</param>
    /// <returns></returns>
    public static CqSetGroupAdministratorActionResult? SetGroupAdministrator(this ICqActionSession session, long groupId, long userId, bool enable) =>
        session.SetGroupAdministratorAsync(groupId, userId, enable).Result;

    /// <summary>
    /// 获取群文件资源链接
    /// </summary>
    /// <param name="session">可发送操作的会话</param>
    /// <param name="groupId">群号</param>
    /// <param name="fileId">文件 ID (参考 <see cref="CqGroupFile"/>)</param>
    /// <param name="busid">文件类型 (参考 <see cref="CqGroupFile"/>)</param>
    /// <returns></returns>
    public static CqGetGroupFileUrlActionResult? GetGroupFileUrl(this ICqActionSession session, long groupId, string fileId, int busid) =>
        session.GetGroupFileUrlAsync(groupId, fileId, busid).Result;

    #endregion
}
