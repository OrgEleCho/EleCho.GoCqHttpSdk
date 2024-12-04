using System;
using EleCho.GoCqHttpSdk.Post;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk;

// 注意：这个文件是自动生成的，不要手动修改

/// <summary>
/// 用来处理上报的插件
/// </summary>
public class CqPostPlugin
{
    /// <summary>
    /// 处理上报
    /// </summary>
    /// <param name="context">上报上下文</param>
    /// <param name="next">下一个中间件</param>
    /// <returns>异步任务</returns>
    public async Task Execute(CqPostContext context, Func<Task> next)
    {
        switch (context)
        {
            case CqPrivateMessagePostContext privateMessagePC:
                OnPrivateMessageReceived(privateMessagePC);
                await OnPrivateMessageReceivedAsync(privateMessagePC);
                break;
            case CqGroupMessagePostContext groupMessagePC:
                OnGroupMessageReceived(groupMessagePC);
                await OnGroupMessageReceivedAsync(groupMessagePC);
                break;
            case CqHeartbeatPostContext heartbeatPC:
                OnHeartbeat(heartbeatPC);
                await OnHeartbeatAsync(heartbeatPC);
                break;
            case CqLifecyclePostContext lifecyclePC:
                OnLifecycle(lifecyclePC);
                await OnLifecycleAsync(lifecyclePC);
                break;
            case CqGroupEssenceChangedPostContext essenceChangedPC:
                OnGroupEssenceChanged(essenceChangedPC);
                await OnGroupEssenceChangedAsync(essenceChangedPC);
                break;
            case CqClientStatusChangedPostContext clientStatusChangedPC:
                OnClientStatusChanged(clientStatusChangedPC);
                await OnClientStatusChangedAsync(clientStatusChangedPC);
                break;
            case CqGroupFileUploadedPostContext groupFileUploadedPC:
                OnGroupFileUploaded(groupFileUploadedPC);
                await OnGroupFileUploadedAsync(groupFileUploadedPC);
                break;
            case CqGroupAdministratorChangedPostContext groupAdminChangedPC:
                OnGroupAdminChanged(groupAdminChangedPC);
                await OnGroupAdminChangedAsync(groupAdminChangedPC);
                break;
            case CqGroupMemberIncreasedPostContext groupMemberIncreasedPC:
                OnGroupMemberIncreased(groupMemberIncreasedPC);
                await OnGroupMemberIncreasedAsync(groupMemberIncreasedPC);
                break;
            case CqGroupMemberDecreasedPostContext groupMemberDecreasedPC:
                OnGroupMemberDecreased(groupMemberDecreasedPC);
                await OnGroupMemberDecreasedAsync(groupMemberDecreasedPC);
                break;
            case CqGroupMemberNicknameChangedPostContext groupMemberCardChangedPC:
                OnGroupMemberNicknameChanged(groupMemberCardChangedPC);
                await OnGroupMemberNicknameChangedAsync(groupMemberCardChangedPC);
                break;
            case CqGroupMemberBanChangedPostContext groupBanChangedPC:
                OnGroupBanChanged(groupBanChangedPC);
                await OnGroupBanChangedAsync(groupBanChangedPC);
                break;
            case CqGroupMessageRecalledPostContext groupMessageRecalledPC:
                OnGroupMessageRecalled(groupMessageRecalledPC);
                await OnGroupMessageRecalledAsync(groupMessageRecalledPC);
                break;
            case CqFriendAddedPostContext friendAddedPC:
                OnFriendAdded(friendAddedPC);
                await OnFriendAddedAsync(friendAddedPC);
                break;
            case CqFriendMessageRecalledPostContext friendMessageRecalledPC:
                OnFriendMessageRecalled(friendMessageRecalledPC);
                await OnFriendMessageRecalledAsync(friendMessageRecalledPC);
                break;
            case CqOfflineFileUploadedPostContext offlineFileUploadedPC:
                OnOfflineFileUploaded(offlineFileUploadedPC);
                await OnOfflineFileUploadedAsync(offlineFileUploadedPC);
                break;
            case CqFriendRequestPostContext friendRequestPC:
                OnFriendRequest(friendRequestPC);
                await OnFriendRequestAsync(friendRequestPC);
                break;
            case CqGroupRequestPostContext groupRequestPC:
                OnGroupRequest(groupRequestPC);
                await OnGroupRequestAsync(groupRequestPC);
                break;
            case CqPokedPostContext pokedPC:
                OnPoked(pokedPC);
                await OnPokedAsync(pokedPC);
                break;
            case CqGroupLuckyKingNoticedPostContext luckyKingNoticedPC:
                OnLuckyKingNoticed(luckyKingNoticedPC);
                await OnLuckyKingNoticedAsync(luckyKingNoticedPC);
                break;
            case CqGroupMemberHonorChangedPostContext honorChangedPC:
                OnGroupMemberHonorChanged(honorChangedPC);
                await OnGroupMemberHonorChangedAsync(honorChangedPC);
                break;
            case CqGroupMemberTitleChangeNoticedPostContext memberTitleChangeNoticedPostContext:
                OnGroupMemberTitleChanged(memberTitleChangeNoticedPostContext);
                await OnGroupMemberTitleChangedAsync(memberTitleChangeNoticedPostContext);
                break;
        }

        await next();
    }


    /// <summary>
    /// 当收到私聊消息
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnPrivateMessageReceived(CqPrivateMessagePostContext context) { }

    /// <summary>
    /// 当收到群聊消息
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMessageReceived(CqGroupMessagePostContext context) { }

    /// <summary>
    /// 当收到心跳包
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnHeartbeat(CqHeartbeatPostContext context) { }

    /// <summary>
    /// 当生命周期变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnLifecycle(CqLifecyclePostContext context) { }

    /// <summary>
    /// 当群精华消息变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupEssenceChanged(CqGroupEssenceChangedPostContext context) { }

    /// <summary>
    /// 当客户端状态变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnClientStatusChanged(CqClientStatusChangedPostContext context) { }

    /// <summary>
    /// 当群文件上传
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupFileUploaded(CqGroupFileUploadedPostContext context) { }

    /// <summary>
    /// 当群管理员变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupAdminChanged(CqGroupAdministratorChangedPostContext context) { }

    /// <summary>
    /// 当群成员增加
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMemberIncreased(CqGroupMemberIncreasedPostContext context) { }

    /// <summary>
    /// 当群成员减少
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMemberDecreased(CqGroupMemberDecreasedPostContext context) { }

    /// <summary>
    /// 当群成员昵称变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMemberNicknameChanged(CqGroupMemberNicknameChangedPostContext context) { }

    /// <summary>
    /// 当群禁言状态变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupBanChanged(CqGroupMemberBanChangedPostContext context) { }

    /// <summary>
    /// 当群消息被撤回
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMessageRecalled(CqGroupMessageRecalledPostContext context) { }

    /// <summary>
    /// 当好友添加
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnFriendAdded(CqFriendAddedPostContext context) { }

    /// <summary>
    /// 当好友消息被撤回
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnFriendMessageRecalled(CqFriendMessageRecalledPostContext context) { }

    /// <summary>
    /// 当离线文件上传
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnOfflineFileUploaded(CqOfflineFileUploadedPostContext context) { }

    /// <summary>
    /// 当好友请求
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnFriendRequest(CqFriendRequestPostContext context) { }

    /// <summary>
    /// 当群请求
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupRequest(CqGroupRequestPostContext context) { }

    /// <summary>
    /// 当被拍一拍
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnPoked(CqPokedPostContext context) { }

    /// <summary>
    /// 当幸运王被通报
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnLuckyKingNoticed(CqGroupLuckyKingNoticedPostContext context) { }

    /// <summary>
    /// 当群荣誉变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMemberHonorChanged(CqGroupMemberHonorChangedPostContext context) { }

    /// <summary>
    /// 当群成员头衔变更
    /// </summary>
    /// <param name="context"></param>
    public virtual void OnGroupMemberTitleChanged(CqGroupMemberTitleChangeNoticedPostContext context) { }




    /// <summary>
    /// 当收到私聊消息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnPrivateMessageReceivedAsync(CqPrivateMessagePostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当收到群聊消息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMessageReceivedAsync(CqGroupMessagePostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当收到心跳包
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnHeartbeatAsync(CqHeartbeatPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当生命周期变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnLifecycleAsync(CqLifecyclePostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群精华消息变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupEssenceChangedAsync(CqGroupEssenceChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当客户端状态变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnClientStatusChangedAsync(CqClientStatusChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群文件上传
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupFileUploadedAsync(CqGroupFileUploadedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群管理员变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupAdminChangedAsync(CqGroupAdministratorChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群成员增加
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMemberIncreasedAsync(CqGroupMemberIncreasedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群成员减少
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMemberDecreasedAsync(CqGroupMemberDecreasedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群成员昵称变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMemberNicknameChangedAsync(CqGroupMemberNicknameChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群禁言状态变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupBanChangedAsync(CqGroupMemberBanChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群消息被撤回
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMessageRecalledAsync(CqGroupMessageRecalledPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当好友添加
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnFriendAddedAsync(CqFriendAddedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当好友消息被撤回
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnFriendMessageRecalledAsync(CqFriendMessageRecalledPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当离线文件上传
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnOfflineFileUploadedAsync(CqOfflineFileUploadedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当好友请求
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnFriendRequestAsync(CqFriendRequestPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群请求
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupRequestAsync(CqGroupRequestPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当被拍一拍
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnPokedAsync(CqPokedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当幸运王通报
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnLuckyKingNoticedAsync(CqGroupLuckyKingNoticedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群成员荣誉变更
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Task OnGroupMemberHonorChangedAsync(CqGroupMemberHonorChangedPostContext context) => Task.CompletedTask;

    /// <summary>
    /// 当群成员头衔变更
    /// </summary>
    /// <param name="context">上报上下文</param>
    /// <returns>异步任务</returns>
    public virtual Task OnGroupMemberTitleChangedAsync(CqGroupMemberTitleChangeNoticedPostContext context) => Task.CompletedTask;
}
