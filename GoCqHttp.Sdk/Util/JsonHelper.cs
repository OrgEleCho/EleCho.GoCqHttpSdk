using EleCho.GoCqHttpSdk.JsonConverter;
using EleCho.GoCqHttpSdk.Message.JsonConverter;
using EleCho.GoCqHttpSdk.Post.JsonConverter;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace EleCho.GoCqHttpSdk.Util
{
    internal static class JsonHelper
    {
        private static Lazy<JsonSerializerOptions> options = new Lazy<JsonSerializerOptions>(NewOptions);

        private static JsonSerializerOptions NewOptions()
        {
            return new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
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
#if DEBUG
            return debugOptions.Value;
#else
            return options.Value;
#endif
        }

#if DEBUG
        private static Lazy<JsonSerializerOptions> debugOptions = new(NewDebugOptions);

        private static JsonSerializerOptions NewDebugOptions()
        {
            return new JsonSerializerOptions()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
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

#endif

        public static T? ToObject<T>(this JsonElement el, JsonSerializerOptions? options)
        {
            return JsonSerializer.Deserialize<T>(el, options);
        }
    }
}