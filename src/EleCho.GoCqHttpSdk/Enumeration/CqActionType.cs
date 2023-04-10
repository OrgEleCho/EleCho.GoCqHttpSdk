namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum CqActionType
    {
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        SendPrivateMessage,

        /// <summary>
        /// 发送群消息
        /// </summary>
        SendGroupMessage,

        /// <summary>
        /// 发送信息
        /// </summary>
        SendMessage,

        /// <summary>
        /// 撤回消息
        /// </summary>
        RecallMessage,

        /// <summary>
        /// 发送群转发消息
        /// </summary>
        SendGroupForwardMessage,

        /// <summary>
        /// 获取消息
        /// </summary>
        GetMessage,

        /// <summary>
        /// 获取转发消息
        /// </summary>
        GetForwardMessage,

        /// <summary>
        /// 获取图片
        /// </summary>
        GetImage,

        /// <summary>
        /// 禁言群成员
        /// </summary>
        BanGroupMember,

        /// <summary>
        /// 禁言群匿名成员
        /// </summary>
        BanGroupAnonymousMember,

        /// <summary>
        /// 禁言群所有成员 (全体禁言)
        /// </summary>
        BanGroupAllMembers,

        /// <summary>
        /// 踢出群成员
        /// </summary>
        KickGroupMember,

        /// <summary>
        /// 处理好友请求
        /// </summary>
        HandleFriendRequest,

        /// <summary>
        /// 处理群请求
        /// </summary>
        HandleGroupRequest,

        /// <summary>
        /// 标记消息已读
        /// </summary>
        MarkMessageAsRead,

        /// <summary>
        /// 设置群管理员
        /// </summary>
        SetGroupAdministrator,

        /// <summary>
        /// 设置群是否允许匿名聊天
        /// </summary>
        SetGroupAnonymous,

        /// <summary>
        /// 设置群昵称
        /// </summary>
        SetGroupNickname,

        /// <summary>
        /// 设置群名
        /// </summary>
        SetGroupName,

        /// <summary>
        /// 退群
        /// </summary>
        LeaveGroup,

        /// <summary>
        /// 设置群专属头衔
        /// </summary>
        SetGroupSpecialTitle,

        /// <summary>
        /// 群打卡
        /// </summary>
        GroupSignIn,

        /// <summary>
        /// 获取登陆信息
        /// </summary>
        GetLoginInformation,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        GetStrangerInformation,

        /// <summary>
        /// 设置账号信息
        /// </summary>
        SetAccountProfile,

        /// <summary>
        /// 获取好友列表
        /// </summary>
        GetFriendList,

        /// <summary>
        /// 获取单向好友列表
        /// </summary>
        GetUnidirectionalFriendList,

        /// <summary>
        /// 删除好友
        /// </summary>
        DeleteFriend,

        /// <summary>
        /// 删除单向好友
        /// </summary>
        DeleteUnidirectionalFriend,

        /// <summary>
        /// 发送私聊转发消息
        /// </summary>
        SendPrivateForwardMessage,

        /// <summary>
        /// 获取群信息
        /// </summary>
        GetGroupInformation,

        /// <summary>
        /// 获取群列表
        /// </summary>
        GetGroupList,

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        GetGroupMemberInformation,

        /// <summary>
        /// 判断是否能发送图片
        /// </summary>
        CanSendImage,

        /// <summary>
        /// 判断是否能发送语音
        /// </summary>
        CanSendRecord,

        /// <summary>
        /// 设置显示机型
        /// </summary>
        SetModelShow,

        /// <summary>
        /// 获取显示机型
        /// </summary>
        GetModelShow,

        /// <summary>
        /// 检查链接安全性
        /// </summary>
        CheckUrlSafety,

        /// <summary>
        /// 获取版本信息
        /// </summary>
        GetVersionInformation,
        


        /// <summary>
        /// 设置精华消息
        /// </summary>
        SetEssenceMessage,

        /// <summary>
        /// 删除精华消息
        /// </summary>
        DeleteEssenceMessage,

        /// <summary>
        /// 获取精华消息列表
        /// </summary>
        GetEssenceMessagesList,

        /// <summary>
        /// 获取 Cookies
        /// </summary>
        GetCookies,

        /// <summary>
        /// 获取 CSRF Token
        /// </summary>
        GetCsrfToken,

        /// <summary>
        /// 获取在线客户端
        /// </summary>
        GetOnlineClients,

        /// <summary>
        /// 设置群头像
        /// </summary>
        SetGroupAvatar,

        /// <summary>
        /// 下载文件
        /// </summary>
        DownloadFile,

        /// <summary>
        /// 重载事件过滤器
        /// </summary>
        ReloadEventFilter,

        /// <summary>
        /// 获取分词
        /// </summary>
        GetWordSlices,

        /// <summary>
        /// 图片 OCR
        /// </summary>
        OcrImage,

        /// <summary>
        /// 上传群文件
        /// </summary>
        UploadGroupFile,

        /// <summary>
        /// 删除群文件
        /// </summary>
        DeleteGroupFile,

        /// <summary>
        /// 创建群文件目录
        /// </summary>
        CreateGroupFolder,

        /// <summary>
        /// 删除群文件目录
        /// </summary>
        DeleteGroupFolder,

        /// <summary>
        /// 获取群文件系统信息
        /// </summary>
        GetGroupFileSystemInformation,

        /// <summary>
        /// 获取群根目录文件
        /// </summary>
        GetGroupRootFiles,

        /// <summary>
        /// 获取群指定目录文件
        /// </summary>
        GetGroupFilesByFolder,

        /// <summary>
        /// 获取群文件地址
        /// </summary>
        GetGroupFileUrl,

        /// <summary>
        /// 上传私聊文件
        /// </summary>
        UploadPrivateFile,

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        GetGroupMemberList,
    }
}