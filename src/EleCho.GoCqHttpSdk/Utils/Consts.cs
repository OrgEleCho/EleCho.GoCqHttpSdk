namespace EleCho.GoCqHttpSdk.Utils
{
    /// <summary>
    /// 一堆常量
    /// </summary>
    internal static partial class Consts
    {
        public static class EnumNames
        {
            public const string PostType = "post_type";
            public const string MessageType = "message_type";
            public const string RequestType = "request_type";
            public const string NoticeType = "notice_type";
            public const string MetaEventType = "meta_event_type";
        }

        public static class MsgType
        {
            public const string Text = "text";
            public const string Image = "image";
            public const string Record = "record";
            public const string Location = "location";
            public const string Anonymous = "anonymous";
            public const string Face = "face";
            public const string At = "at";
            public const string Rps = "rps";
            public const string Shake = "shake";
            public const string CardImage = "cardimage";
            public const string Contact = "contact";
            public const string Dice = "dice";
            public const string Forward = "forward";
            public const string Node = "node";
            public const string Gift = "gift";
            public const string Json = "json";
            public const string Poke = "poke";
            public const string Redbag = "redbag";
            public const string Reply = "reply";
            public const string Share = "share";
            public const string Video = "video";
            public const string Xml = "xml";
            public const string Music = "music";

            public const string Private = "private";
            public const string Group = "group";

            public const string TTS = "tts";
        }

        public static class RequestType
        {
            public const string Group = "group";
            public const string Friend = "friend";
        }

        /// <summary>
        /// 原始的 Action 终结点定义 (不要改名称)
        /// </summary>
        public static class ActionType
        {
            public const string SendPrivateMsg = "send_private_msg";
            public const string SendGroupMsg = "send_group_msg";
            public const string SendMsg = "send_msg";
            public const string DeleteMsg = "delete_msg";
            public const string SendGroupForwardMsg = "send_group_forward_msg";
            public const string SendPrivateForwardMsg = "send_private_forward_msg";

            public const string GetMsg = "get_msg";
            public const string GetForwardMsg = "get_forward_msg";
            public const string GetImage = "get_image";
            public const string GetUnidirectionalFriendList = "get_unidirectional_friend_list";

            public const string GetFriendList = "get_friend_list";
            public const string GetGroupList = "get_group_list";
            public const string GetGroupMemberList = "get_group_member_list";


            public const string GetLoginInfo = "get_login_info";
            public const string GetStrangerInfo = "get_stranger_info";
            public const string GetGroupInfo = "get_group_info";
            public const string GetGroupMemberInfo = "get_group_member_info";

            public const string DeleteFriend = "delete_friend";
            public const string DeleteUnidirectionalFriend = "delete_unidirectional_friend";

            public const string SetGroupBan = "set_group_ban";
            public const string SetGroupAnonymousBan = "set_group_anonymous_ban";
            public const string SetGroupWholeBan = "set_group_whole_ban";
            public const string SetGroupKick = "set_group_kick";
            public const string SetGroupAdmin = "set_group_admin";
            public const string SetGroupAnonymous = "set_group_anonymous";
            public const string SetGroupCard = "set_group_card";
            public const string SetGroupName = "set_group_name";
            public const string SetGroupLeave = "set_group_leave";
            public const string SetGroupSpecialTitle = "set_group_special_title";
            public const string SetQqProfile = "set_qq_profile";

            public const string SendGroupSign = "send_group_sign";

            public const string SetFriendAddRequest = "set_friend_add_request";
            public const string SetGroupAddRequest = "set_group_add_request";

            public const string MarkMsgAsRead = "mark_msg_as_read";

            public const string HandleQuickOperation = ".handle_quick_operation";

            public const string CanSendImage ="can_send_image";
            public const string CanSendRecord = "can_send_record";

            public const string GetCookies = "get_cookies";
            public const string GetCsrfToken = "get_csrf_token";

            public const string GetModelShow = "_get_model_show";
            public const string SetModelShow = "_set_model_show";

            public const string DownloadFile = "download_file";
            public const string GetOnlineClients = "get_online_clients";
            
            public const string SetEssenceMsg = "set_essence_msg";
            public const string DeleteEssenceMsg = "delete_essence_msg";
            public const string GetEssenceMsgList = "get_essence_msg_list";

            /// <summary>
            /// 所以, 官方文档是写错了吧, 怎么可能是 safely 呢
            /// </summary>
            public const string CheckUrlSafety = "check_url_safely";

            public const string GetVersionInfo = "get_version_info";
            /// <summary>
            /// Set group avatar 更准确些
            /// </summary>
            public const string SetGroupPortrait = "set_group_portrait";

            public const string ReloadEventFilter = "reload_event_filter";

            public const string GetWordSlices = ".get_word_slices";
            public const string OcrImage = "ocr_image";

            public const string UploadGroupFile = "upload_group_file";
            public const string DeleteGroupFile = "delete_group_file";
            public const string CreateGroupFileFolder = "create_group_file_folder";
            public const string DeleteGroupFolder = "delete_group_folder";
            public const string GetGroupFileSystemInfo = "get_group_file_system_info";
            public const string GetGroupRootFiles = "get_group_root_files";
            public const string GetGroupFilesByFolder = "get_group_files_by_folder";
            public const string UploadPrivateFile = "upload_private_file";
            public const string GetGroupFileUrl = "get_group_file_url";

        }

        public static class NoticeType
        {
            public const string Essence = "essence";
            public const string ClientStatus = "client_status";

            public const string GroupAdmin = "group_admin";
            public const string GroupRecall = "group_recall";
            public const string GroupIncrease = "group_increase";
            public const string GroupDecrease = "group_decrease";
            public const string GroupUpload = "group_upload";
            public const string GroupBan = "group_ban";
            public const string GroupCard = "group_card";

            public const string FriendAdd = "friend_add";
            public const string FriendRecall = "friend_recall";

            public const string OfflineFile = "offline_file";

            public const string Notify = "notify";
        }

        public static class MetaEventType
        {
            public const string Heartbeat = "heartbeat";
            public const string Lifecycle = "lifecycle";
        }

        public static class PostType
        {
            public const string Message = "message";
            public const string MessageSent = "message_sent";
            public const string Request = "request";
            public const string Notice = "notice";
            public const string MetaEvent = "meta_event";
        }

        public static class NotifyType
        {
            public const string LuckyKing = "lucky_king";
            public const string Poke = "poke";
            public const string Honor = "honor";
            public const string Title = "title";
        }
    }
}