namespace EleCho.GoCqHttpSdk.Util
{
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
        }

        public static class RequestType
        {
            public const string Group = "group";
            public const string Friend = "friend";
        }

        public static class ActionType
        {
            public const string SendPrivateMsg = "send_private_msg";
            public const string SendGroupMsg = "send_group_msg";
            public const string SendMsg = "send_msg";
            public const string DeleteMsg = "delete_msg";
            public const string SendGroupForwardMsg = "send_group_forward_msg";
            public const string GetMsg = "get_msg";
            public const string GetForwardMsg = "get_forward_msg";
            
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
            public const string Request = "request";
            public const string Notice = "notice";
            public const string MetaEvent = "meta_event";
        }

        public static class NotifyType
        {
            public const string LuckyKing = "lucky_king";
            public const string Poke = "poke";
            public const string Honor = "honor";
        }
    }
}