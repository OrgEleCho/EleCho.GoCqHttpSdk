using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Enumeration
{
    internal static class CqEnum
    {
        public static string GetString(CqContactType contactType)
        {
            return contactType switch
            {
                CqContactType.Group => "group",
                CqContactType.QQ => "qq",
                _ => ""
            };
        }

        public static string GetString(CqMessageType messageType)
        {
            return messageType switch
            {
                CqMessageType.Private => "private",
                CqMessageType.Group => "group",
                
                _ => string.Empty
            };
        }

        public static string GetString(CqLifecycleType lifecycleType)
        {
            return lifecycleType switch
            {
                CqLifecycleType.Enable => "enable",
                CqLifecycleType.Disable => "disable",
                CqLifecycleType.Connect => "connect",

                _ => string.Empty
            };
        }

        

        public static CqContactType GetContactType(string value)
        {
            return value switch
            {
                "qq" => CqContactType.QQ,
                "group" => CqContactType.Group,
                _ => (CqContactType)(-1)
            };            
        }

        public static CqMessageType GetMessageType(string value)
        {
            return value switch
            {
                "private" => CqMessageType.Private,
                "group" => CqMessageType.Group,

                _ => CqMessageType.Unknown,
            };
        }

        public static CqLifecycleType GetLifecycleType(string value)
        {
            return value switch
            {
                "enable" => CqLifecycleType.Enable,
                "disable" => CqLifecycleType.Disable,
                "connect" => CqLifecycleType.Connect,

                _ => CqLifecycleType.Unknown
            };
        }
    }
}
