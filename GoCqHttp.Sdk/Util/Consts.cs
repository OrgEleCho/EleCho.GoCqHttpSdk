using NullLib.GoCqHttpSdk.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class Consts
    {
        public static class EventType
        {

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
        }

        public static class ActionType
        {
            public const string SendPrivateMsg = "send_private_msg";
            public const string SendGroupMsg = "send_group_msg";
            public const string SendMsg = "send_msg";
        }
    }
}
