using NullLib.GoCqHttpSdk.JsonConverter;
using NullLib.GoCqHttpSdk.Message.JsonConverter;
using NullLib.GoCqHttpSdk.Post.JsonConverter;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class JsonHelper
    {
        private static Lazy<JsonSerializerOptions> options = new Lazy<JsonSerializerOptions>(NewOptions);

        public static JsonSerializerOptions NewOptions()
        {
            return new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Converters =
                {
                    new CqWsDataModelConverter(),

                    new CqEventModelConverter(),
                    new CqMessageEventModelConverter(),

                    new CqNoticeEventModelConverter(),
                    new CqNoticeNotifyEventModelConverter(),

                    new CqMetaEventModelConverter(),

                    new CqRequestEventModelConverter(),

                    new CqMsgModelArrayConverter(),
                    new CpMsgModelConverter(),
                }
            };
        }

        public static JsonSerializerOptions GetOptions()
        {
#if RELEASE
            return options.Value;
#else
            return debugOptions.Value;
#endif
        }

#if DEBUG
        private static Lazy<JsonSerializerOptions> debugOptions = new(NewDebugOptions);

        public static JsonSerializerOptions NewDebugOptions()
        {
            return new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                Converters =
                {
                    new CqWsDataModelConverter(),

                    new CqEventModelConverter(),
                    new CqMessageEventModelConverter(),

                    new CqNoticeEventModelConverter(),
                    new CqNoticeNotifyEventModelConverter(),

                    new CqMetaEventModelConverter(),

                    new CqRequestEventModelConverter(),

                    new CqMsgModelArrayConverter(),
                    new CpMsgModelConverter(),
                }
            };
        }

        public static JsonSerializerOptions GetDebugOptions()
        {
            return debugOptions.Value;
        }

#endif

        public static T? ToObject<T>(this JsonElement el, JsonSerializerOptions? options)
        {
            return JsonSerializer.Deserialize<T>(el, options);
        }

        public static T? ToObject<T>(this JsonDocument doc, JsonSerializerOptions? options)
        {
            return doc.RootElement.ToObject<T>(options);
        }
    }
}