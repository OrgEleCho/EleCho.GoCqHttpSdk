using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using NullLib.GoCqHttpSdk.Post.JsonConverter;
using NullLib.GoCqHttpSdk.Message.JsonConverter;
using NullLib.GoCqHttpSdk.JsonConverter;

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
        static Lazy<JsonSerializerOptions> debugOptions = new(NewDebugOptions);
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
            return JsonSerializer.Deserialize<T>(el.GetRawText(), options);
        }
        public static T? ToObject<T>(this JsonDocument doc, JsonSerializerOptions? options)
        {
            return doc.RootElement.ToObject<T>(options);
        }
    }
}
