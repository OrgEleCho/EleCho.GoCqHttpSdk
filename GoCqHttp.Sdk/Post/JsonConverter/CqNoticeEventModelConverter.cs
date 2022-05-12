using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Post.JsonConverter
{
    internal class CqNoticeEventModelConverter : JsonConverter<CqNoticePostModel>
    {
        public override CqNoticePostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            JsonDocument doc = JsonDocument.ParseValue(ref reader);
            string? noticeType = doc.RootElement.GetProperty("notice_type").GetString();

            return noticeType switch
            {
                "group_upload" => doc.ToObject<CqNoticeGroupUploadPostModel>(options),
                "group_admin" => doc.ToObject<CqNoticeGroupAdminPostModel>(options),
                "group_decrease" => doc.ToObject<CqNoticeGroupDecreasePostModel>(options),
                "group_increase" => doc.ToObject<CqNoticeGroupIncreasePostModel>(options),
                "group_ban" => doc.ToObject<CqNoticeGroupBanPostModel>(options),
                "friend_add" => doc.ToObject<CqNoticeFriendAddPostModel>(options),
                "group_recall" => doc.ToObject<CqNoticeGroupRecallPostModel>(options),
                "friend_recall" => doc.ToObject<CqNoticeFriendRecallPostModel>(options),
                "notify" => doc.ToObject<CqNoticeNotifyPostModel>(options),
                "group_card" => doc.ToObject<CqNoticeGroupCardPostModel>(options),
                "offline_file" => doc.ToObject<CqNoticeOfflineFilePostModel>(options),

                _ => null
            };
        }

        public override void Write(Utf8JsonWriter writer, CqNoticePostModel value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
