using NullLib.GoCqHttpSdk.Post.Model;
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
            if (doc.RootElement.TryGetProperty("notice_type", out JsonElement noticeTypeEle))
            {
                if (noticeTypeEle.ValueKind != JsonValueKind.String)
                    return null;

                string noticeType = noticeTypeEle.GetString()!;
                return noticeType switch
                {
                    "group_upload" => JsonSerializer.Deserialize<CqNoticeGroupUploadPostModel>(doc, options),
                    "group_admin" => JsonSerializer.Deserialize<CqNoticeGroupAdminPostModel>(doc, options),
                    "group_decrease" => JsonSerializer.Deserialize<CqNoticeGroupDecreasePostModel>(doc, options),
                    "group_increase" => JsonSerializer.Deserialize<CqNoticeGroupIncreasePostModel>(doc, options),
                    "group_ban" => JsonSerializer.Deserialize<CqNoticeGroupBanPostModel>(doc, options),
                    "friend_add" => JsonSerializer.Deserialize<CqNoticeFriendAddPostModel>(doc, options),
                    "group_recall" => JsonSerializer.Deserialize<CqNoticeGroupRecallPostModel>(doc, options),
                    "friend_recall" => JsonSerializer.Deserialize<CqNoticeFriendRecallPostModel>(doc, options),
                    "notify" => JsonSerializer.Deserialize<CqNoticeNotifyPostModel>(doc, options),
                    "group_card" => JsonSerializer.Deserialize<CqNoticeGroupCardPostModel>(doc, options),
                    "offline_file" => JsonSerializer.Deserialize<CqNoticeOfflineFilePostModel>(doc, options),

                    _ => null
                };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, CqNoticePostModel value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException();
        }
    }
}