using System;
using EleCho.GoCqHttpSdk.Post;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
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
                    OnPrivateMessage(privateMessagePC);
                    await OnPrivateMessageAsync(privateMessagePC);
                    break;
                case CqGroupMessagePostContext groupMessagePC:
                    OnGroupMessage(groupMessagePC);
                    await OnGroupMessageAsync(groupMessagePC);
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
                    OnEssenceChanged(essenceChangedPC);
                    await OnEssenceChangedAsync(essenceChangedPC);
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
                    OnGroupMemberCardChanged(groupMemberCardChangedPC);
                    await OnGroupMemberCardChangedAsync(groupMemberCardChangedPC);
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
                    OnHonorChanged(honorChangedPC);
                    await OnHonorChangedAsync(honorChangedPC);
                    break;
                case CqGroupMemberTitleChangeNoticedPostContext memberTitleChangeNoticedPostContext:
                    OnMemberTitleChanged(memberTitleChangeNoticedPostContext);
                    await OnGroupMemberTitleChangedAsync(memberTitleChangeNoticedPostContext);
                    break;
            }

            await next();
        }

        public virtual void OnPrivateMessage(CqPrivateMessagePostContext context) { }
        public virtual void OnGroupMessage(CqGroupMessagePostContext context) { }
        public virtual void OnHeartbeat(CqHeartbeatPostContext context) { }
        public virtual void OnLifecycle(CqLifecyclePostContext context) { }
        public virtual void OnEssenceChanged(CqGroupEssenceChangedPostContext context) { }
        public virtual void OnClientStatusChanged(CqClientStatusChangedPostContext context) { }
        public virtual void OnGroupFileUploaded(CqGroupFileUploadedPostContext context) { }
        public virtual void OnGroupAdminChanged(CqGroupAdministratorChangedPostContext context) { }
        public virtual void OnGroupMemberIncreased(CqGroupMemberIncreasedPostContext context) { }
        public virtual void OnGroupMemberDecreased(CqGroupMemberDecreasedPostContext context) { }
        public virtual void OnGroupMemberCardChanged(CqGroupMemberNicknameChangedPostContext context) { }
        public virtual void OnGroupBanChanged(CqGroupMemberBanChangedPostContext context) { }
        public virtual void OnGroupMessageRecalled(CqGroupMessageRecalledPostContext context) { }
        public virtual void OnFriendAdded(CqFriendAddedPostContext context) { }
        public virtual void OnFriendMessageRecalled(CqFriendMessageRecalledPostContext context) { }
        public virtual void OnOfflineFileUploaded(CqOfflineFileUploadedPostContext context) { }
        public virtual void OnFriendRequest(CqFriendRequestPostContext context) { }
        public virtual void OnGroupRequest(CqGroupRequestPostContext context) { }
        public virtual void OnPoked(CqPokedPostContext context) { }
        public virtual void OnLuckyKingNoticed(CqGroupLuckyKingNoticedPostContext context) { }
        public virtual void OnHonorChanged(CqGroupMemberHonorChangedPostContext context) { }
        public virtual void OnMemberTitleChanged(CqGroupMemberTitleChangeNoticedPostContext context) { }


        public virtual Task OnPrivateMessageAsync(CqPrivateMessagePostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMessageAsync(CqGroupMessagePostContext context) => Task.CompletedTask;
        public virtual Task OnHeartbeatAsync(CqHeartbeatPostContext context) => Task.CompletedTask;
        public virtual Task OnLifecycleAsync(CqLifecyclePostContext context) => Task.CompletedTask;
        public virtual Task OnEssenceChangedAsync(CqGroupEssenceChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnClientStatusChangedAsync(CqClientStatusChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupFileUploadedAsync(CqGroupFileUploadedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupAdminChangedAsync(CqGroupAdministratorChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberIncreasedAsync(CqGroupMemberIncreasedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberDecreasedAsync(CqGroupMemberDecreasedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberCardChangedAsync(CqGroupMemberNicknameChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupBanChangedAsync(CqGroupMemberBanChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMessageRecalledAsync(CqGroupMessageRecalledPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendAddedAsync(CqFriendAddedPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendMessageRecalledAsync(CqFriendMessageRecalledPostContext context) => Task.CompletedTask;
        public virtual Task OnOfflineFileUploadedAsync(CqOfflineFileUploadedPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendRequestAsync(CqFriendRequestPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupRequestAsync(CqGroupRequestPostContext context) => Task.CompletedTask;
        public virtual Task OnPokedAsync(CqPokedPostContext context) => Task.CompletedTask;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task OnLuckyKingNoticedAsync(CqGroupLuckyKingNoticedPostContext context) => Task.CompletedTask;

        /// <summary>
        /// 当群成员荣誉变更时
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task OnHonorChangedAsync(CqGroupMemberHonorChangedPostContext context) => Task.CompletedTask;

        /// <summary>
        /// 当群成员头衔变更时
        /// </summary>
        /// <param name="context">上报上下文</param>
        /// <returns>异步任务</returns>
        public virtual Task OnGroupMemberTitleChangedAsync(CqGroupMemberTitleChangeNoticedPostContext context) => Task.CompletedTask;
    }
}
