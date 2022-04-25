using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event.JsonConverter
{
    internal class CqNoticeEventModelConverter : JsonConverter<CqNoticeEventModel>
    {
        public override CqNoticeEventModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? noticeType = doc.RootElement.GetProperty("notice_type").GetString();

            return noticeType switch
            {
                "group_upload" => doc.ToObject<CqNoticeGroupUploadEventModel>(options),
                "group_admin" => doc.ToObject<CqNoticeGroupAdminEventModel>(options),
                "group_decrease" => doc.ToObject<CqNoticeGroupDecreaseEventModel>(options),
                "group_increase" => doc.ToObject<CqNoticeGroupIncreaseEventModel>(options),
                "group_ban" => doc.ToObject<CqNoticeGroupBanEventModel>(options),
                "friend_add" => doc.ToObject<CqNoticeFriendAddEventModel>(options),
                "group_recall" => doc.ToObject<CqNoticeGroupRecallEventModel>(options),
                "friend_recall" => doc.ToObject<CqNoticeFriendRecallEventModel>(options),
                "notify" => doc.ToObject<CqNoticeNotifyEventModel>(options),
                "group_card" => doc.ToObject<CqNoticeGroupCardEventModel>(options),
                "offline_file" => doc.ToObject<CqNoticeOfflineFileEventModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqNoticeEventModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
