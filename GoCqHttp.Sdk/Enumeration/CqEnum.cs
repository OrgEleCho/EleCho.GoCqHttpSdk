using NullLib.GoCqHttpSdk.Action;
using System;

namespace NullLib.GoCqHttpSdk.Enumeration
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

        public static string? GetString(CqActionStatus status)
        {
            return status switch
            {
                CqActionStatus.Success => "success",
                CqActionStatus.Async => "async",
                CqActionStatus.Failed => "failed",

                _ => null
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
                "success" => CqActionStatus.Success,
                "async" => CqActionStatus.Async,
                "failed" => CqActionStatus.Failed,

                _ => CqActionStatus.Unknown
            };
        }
    }
}