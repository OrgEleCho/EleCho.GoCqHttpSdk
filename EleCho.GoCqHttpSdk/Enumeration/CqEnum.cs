using System;
using System.Data;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Utils;

using static EleCho.GoCqHttpSdk.Utils.Consts.ActionType;

namespace EleCho.GoCqHttpSdk
{
    internal static class CqEnum
    {
        public static string? GetString(CqContactType contactType)
        {
            return contactType switch
            {
                CqContactType.Group => "group",
                CqContactType.QQ => "qq",
                _ => null
            };
        }

        public static string? GetString(CqMessageType messageType)
        {
            return messageType switch
            {
                CqMessageType.Private => "private",
                CqMessageType.Group => "group",

                _ => null
            };
        }

        public static string? GetString(CqLifecycleType lifecycleType)
        {
            return lifecycleType switch
            {
                CqLifecycleType.Enable => "enable",
                CqLifecycleType.Disable => "disable",
                CqLifecycleType.Connect => "connect",

                _ => null
            };
        }

        public static string? GetString(CqRole role)
        {
            return role switch
            {
                CqRole.Owner => "owner",
                CqRole.Admin => "admin",
                CqRole.Member => "member",

                _ => null
            };
        }

        public static string? GetString(CqActionStatus status)
        {
            return status switch
            {
                CqActionStatus.Okay => "ok",
                CqActionStatus.Async => "async",
                CqActionStatus.Failed => "failed",

                _ => null
            };
        }

        public static string? GetString(CqMessagePrivateType privateType)
        {
            return privateType switch
            {
                CqMessagePrivateType.Friend => "friend",
                CqMessagePrivateType.Group => "group",
                CqMessagePrivateType.GroupSelf => "group_self",
                CqMessagePrivateType.Other => "other",

                _ => null
            };
        }

        public static string? GetString(CqGroupRequestType type)
        {
            return type switch
            {
                CqGroupRequestType.Add => "add",
                CqGroupRequestType.Invite => "invite",

                _ => null
            };
        }

        public static string? GetString(CqEssenceChangeType type)
        {
            return type switch
            {
                CqEssenceChangeType.Add => "add",
                CqEssenceChangeType.Delete => "delete",

                _ => null
            };
        }

        public static string? GetString(CqGender gender)
        {
            return gender switch
            {
                CqGender.Male => "mail",
                CqGender.Female => "female",
                CqGender.Unknown => "unknown",
                
                _ => null,
            };
        }

        public static string? GetString(CqActionType type)
        {
            return type switch
            {
                CqActionType.SendPrivateMessage => SendPrivateMsg,
                CqActionType.SendGroupMessage => SendGroupMsg,
                CqActionType.SendMessage => SendMsg,
                CqActionType.RecallMessage => DeleteMsg,
                CqActionType.SendGroupForwardMessage => SendGroupForwardMsg,
                CqActionType.SendPrivateForwardMessage => SendPrivateForwardMsg,
                CqActionType.GetMessage => GetMsg,
                CqActionType.GetForwardMessage => GetForwardMsg,
                CqActionType.GetImage => GetImage,
                CqActionType.BanGroupMember => SetGroupBan,
                CqActionType.BanGroupAnonymousMember => SetGroupAnonymousBan,
                CqActionType.BanGroupAllMembers => SetGroupWholeBan,
                CqActionType.KickGroupMember => SetGroupKick,

                CqActionType.HandleFriendRequest => SetFriendAddRequest,
                CqActionType.HandleGroupRequest => SetGroupAddRequest,

                CqActionType.MarkMessageAsRead => MarkMsgAsRead,
                CqActionType.SetGroupAdministrator => SetGroupAdmin,
                CqActionType.SetGroupAnonymous => SetGroupAnonymous,
                CqActionType.SetGroupNickname => SetGroupCard,
                CqActionType.SetGroupName => SetGroupName,
                CqActionType.SetGroupAvatar => SetGroupPortrait,
                CqActionType.SetGroupSpecialTitle => SetGroupSpecialTitle,
                CqActionType.GroupSignIn => SendGroupSign,
                CqActionType.SetAccountProfile => SetQqProfile,
                CqActionType.GetUnidirectionalFriendList => GetUnidirectionalFriendList,

                CqActionType.GetFriendList => GetFriendList,
                CqActionType.GetGroupList => GetGroupList,

                CqActionType.GetLoginInformation => GetLoginInfo,
                CqActionType.GetStrangerInformation => GetStrangerInfo,
                CqActionType.GetGroupInformation => GetGroupInfo,
                CqActionType.GetGroupMemberInformation => GetGroupMemberInfo,

                CqActionType.LeaveGroup => SetGroupLeave,
                CqActionType.DeleteFriend => DeleteFriend,
                CqActionType.DeleteUnidirectionalFriend => DeleteUnidirectionalFriend,

                CqActionType.CanSendImage => CanSendImage,
                CqActionType.CanSendRecord => CanSendRecord,

                CqActionType.GetCookies => GetCookies,
                CqActionType.GetCsrfToken => GetCsrfToken,

                CqActionType.DownloadFile => DownloadFile,
                CqActionType.GetOnlineClients => GetOnlineClients,

                CqActionType.SetEssenceMessage => SetEssenceMsg,
                CqActionType.DeleteEssenceMessage => DeleteEssenceMsg,
                CqActionType.GetEssenceMessagesList => GetEssenceMsgList,

                CqActionType.GetModelShow => GetModelShow,
                CqActionType.SetModelShow => SetModelShow,

                CqActionType.CheckUrlSafety => CheckUrlSafety,
                CqActionType.GetVersionInformation => GetVersionInfo,

                CqActionType.ReloadEventFilter => ReloadEventFilter,

                _ => throw new ArgumentException($"Unknown Action type: {type}")
            };
        }



        public static CqContactType GetContactType(string? value)
        {
            return value switch
            {
                "qq" => CqContactType.QQ,
                "group" => CqContactType.Group,
                _ => (CqContactType)(-1)
            };
        }

        public static CqMessageType GetMessageType(string? value)
        {
            return value switch
            {
                "private" => CqMessageType.Private,
                "group" => CqMessageType.Group,

                _ => CqMessageType.Unknown,
            };
        }

        public static CqLifecycleType GetLifecycleType(string? value)
        {
            return value switch
            {
                "enable" => CqLifecycleType.Enable,
                "disable" => CqLifecycleType.Disable,
                "connect" => CqLifecycleType.Connect,

                _ => CqLifecycleType.Unknown
            };
        }

        public static CqActionStatus GetActionStatus(string? value)
        {
            return value switch
            {
                "ok" => CqActionStatus.Okay,
                "async" => CqActionStatus.Async,
                "failed" => CqActionStatus.Failed,

                _ => CqActionStatus.Unknown
            };
        }

        public static CqMessagePrivateType GetMessagePrivateType(string? value)
        {
            return value switch
            {
                "friend" => CqMessagePrivateType.Friend,
                "group" => CqMessagePrivateType.Group,
                "group_self" => CqMessagePrivateType.GroupSelf,
                "other" => CqMessagePrivateType.Other,

                _ => CqMessagePrivateType.Unknown
            };
        }

        public static CqGroupRequestType GetGroupRequestType(string? str)
        {
            return str switch
            {
                "add" => CqGroupRequestType.Add,
                "invite" => CqGroupRequestType.Invite,

                _ => CqGroupRequestType.Unknown
            };
        }

        public static CqEssenceChangeType GetEssenceChangeType(string? str)
        {
            return str switch
            {
                "add" => CqEssenceChangeType.Add,
                "delete" => CqEssenceChangeType.Delete,

                _ => CqEssenceChangeType.Unknown
            };
        }

        public static CqGroupAdminChangeType GetGroupAdminChangeType(string? str)
        {
            return str switch
            {
                "set" => CqGroupAdminChangeType.Set,
                "unset" => CqGroupAdminChangeType.UnSet,

                _ => CqGroupAdminChangeType.Unknown
            };
        }

        public static CqGroupBanChangeType GetGroupBanChangeType(string? str)
        {
            return str switch
            {
                "ban" => CqGroupBanChangeType.Ban,
                "lift_ban" => CqGroupBanChangeType.LiftBan,

                _ => CqGroupBanChangeType.Unknown
            };
        }

        public static CqGroupIncreaseChangeType GetGroupIncreaseChangeType(string? str)
        {
            return str switch
            {
                "approve" => CqGroupIncreaseChangeType.Approve,
                "invite" => CqGroupIncreaseChangeType.Invite,

                _ => CqGroupIncreaseChangeType.Unknown
            };
        }

        public static CqHonorType GetHonorType(string? str)
        {
            return str switch
            {
                "talkative" => CqHonorType.TalkAtive,
                "performer" => CqHonorType.Performer,
                "emotion" => CqHonorType.Emotion,

                _ => CqHonorType.Unknown
            };
        }

        public static CqRole GetRole(string? str)
        {
            return str switch
            {
                "owner" => CqRole.Owner,
                "admin" => CqRole.Admin,
                "member" => CqRole.Member,

                _ => CqRole.Unknown
            };
        }

        public static CqGender GetGender(string? str)
        {
            return str switch
            {
                "male" => CqGender.Male,
                "female" => CqGender.Female,

                _ => CqGender.Unknown,
            };
        }
    }
}