using System;
using System.Data;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Util;

namespace EleCho.GoCqHttpSdk.Enumeration
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

        public static string? GetString(CqActionType type)
        {
            return type switch
            {
                CqActionType.SendPrivateMsg => Consts.ActionType.SendPrivateMsg,
                CqActionType.SendGroupMsg => Consts.ActionType.SendGroupMsg,
                CqActionType.SendMsg => Consts.ActionType.SendMsg,
                CqActionType.RecallMsg => Consts.ActionType.DeleteMsg,
                CqActionType.SendGroupForwardMsg => Consts.ActionType.SendGroupForwardMsg,
                CqActionType.GetMsg => Consts.ActionType.GetMsg,
                CqActionType.GetForwardMsg => Consts.ActionType.GetForwardMsg,
                CqActionType.GetImage => Consts.ActionType.GetImage,
                CqActionType.BanGroupMember => Consts.ActionType.SetGroupBan,
                CqActionType.KickGroupMember => Consts.ActionType.SetGroupKick,
                
                CqActionType.HandleFriendRequest => Consts.ActionType.SetFriendAddRequest,
                CqActionType.HandleGroupRequest => Consts.ActionType.SetGroupAddRequest,



                _ => null,
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
    }
}