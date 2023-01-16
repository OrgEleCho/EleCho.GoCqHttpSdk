using System;
using EleCho.GoCqHttpSdk.Post;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public class CqPostPlugin
    {
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
                case CqEssenceChangedPostContext essenceChangedPC:
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
                case CqGroupAdminChangedPostContext groupAdminChangedPC:
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
                case CqGroupMemberCardChangedPostContext groupMemberCardChangedPC:
                    OnGroupMemberCardChanged(groupMemberCardChangedPC);
                    await OnGroupMemberCardChangedAsync(groupMemberCardChangedPC);
                    break;
                case CqGroupBanChangedPostContext groupBanChangedPC:
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
                case CqLuckyKingNoticedPostContext luckyKingNoticedPC:
                    OnLuckyKingNoticed(luckyKingNoticedPC);
                    await OnLuckyKingNoticedAsync(luckyKingNoticedPC);
                    break;
                case CqHonorChangedPostContext honorChangedPC:
                    OnHonorChanged(honorChangedPC);
                    await OnHonorChangedAsync(honorChangedPC);
                    break;
                case CqMemberTitleChangeNoticedPostContext memberTitleChangeNoticedPostContext:
                    OnMemberTitleChanged(memberTitleChangeNoticedPostContext);
                    await OnMemberTitleChangedAsync(memberTitleChangeNoticedPostContext);
                    break;
            }

            await next();
        }

        public virtual void OnPrivateMessage(CqPrivateMessagePostContext context) { }
        public virtual void OnGroupMessage(CqGroupMessagePostContext context) { }
        public virtual void OnHeartbeat(CqHeartbeatPostContext context) { }
        public virtual void OnLifecycle(CqLifecyclePostContext context) { }
        public virtual void OnEssenceChanged(CqEssenceChangedPostContext context) { }
        public virtual void OnClientStatusChanged(CqClientStatusChangedPostContext context) { }
        public virtual void OnGroupFileUploaded(CqGroupFileUploadedPostContext context) { }
        public virtual void OnGroupAdminChanged(CqGroupAdminChangedPostContext context) { }
        public virtual void OnGroupMemberIncreased(CqGroupMemberIncreasedPostContext context) { }
        public virtual void OnGroupMemberDecreased(CqGroupMemberDecreasedPostContext context) { }
        public virtual void OnGroupMemberCardChanged(CqGroupMemberCardChangedPostContext context) { }
        public virtual void OnGroupBanChanged(CqGroupBanChangedPostContext context) { }
        public virtual void OnGroupMessageRecalled(CqGroupMessageRecalledPostContext context) { }
        public virtual void OnFriendAdded(CqFriendAddedPostContext context) { }
        public virtual void OnFriendMessageRecalled(CqFriendMessageRecalledPostContext context) { }
        public virtual void OnOfflineFileUploaded(CqOfflineFileUploadedPostContext context) { }
        public virtual void OnFriendRequest(CqFriendRequestPostContext context) { }
        public virtual void OnGroupRequest(CqGroupRequestPostContext context) { }
        public virtual void OnPoked(CqPokedPostContext context) { }
        public virtual void OnLuckyKingNoticed(CqLuckyKingNoticedPostContext context) { }
        public virtual void OnHonorChanged(CqHonorChangedPostContext context) { }
        public virtual void OnMemberTitleChanged(CqMemberTitleChangeNoticedPostContext context) { }


        public virtual Task OnPrivateMessageAsync(CqPrivateMessagePostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMessageAsync(CqGroupMessagePostContext context) => Task.CompletedTask;
        public virtual Task OnHeartbeatAsync(CqHeartbeatPostContext context) => Task.CompletedTask;
        public virtual Task OnLifecycleAsync(CqLifecyclePostContext context) => Task.CompletedTask;
        public virtual Task OnEssenceChangedAsync(CqEssenceChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnClientStatusChangedAsync(CqClientStatusChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupFileUploadedAsync(CqGroupFileUploadedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupAdminChangedAsync(CqGroupAdminChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberIncreasedAsync(CqGroupMemberIncreasedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberDecreasedAsync(CqGroupMemberDecreasedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMemberCardChangedAsync(CqGroupMemberCardChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupBanChangedAsync(CqGroupBanChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupMessageRecalledAsync(CqGroupMessageRecalledPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendAddedAsync(CqFriendAddedPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendMessageRecalledAsync(CqFriendMessageRecalledPostContext context) => Task.CompletedTask;
        public virtual Task OnOfflineFileUploadedAsync(CqOfflineFileUploadedPostContext context) => Task.CompletedTask;
        public virtual Task OnFriendRequestAsync(CqFriendRequestPostContext context) => Task.CompletedTask;
        public virtual Task OnGroupRequestAsync(CqGroupRequestPostContext context) => Task.CompletedTask;
        public virtual Task OnPokedAsync(CqPokedPostContext context) => Task.CompletedTask;
        public virtual Task OnLuckyKingNoticedAsync(CqLuckyKingNoticedPostContext context) => Task.CompletedTask;
        public virtual Task OnHonorChangedAsync(CqHonorChangedPostContext context) => Task.CompletedTask;
        public virtual Task OnMemberTitleChangedAsync(CqMemberTitleChangeNoticedPostContext context) => Task.CompletedTask;
    }
}
