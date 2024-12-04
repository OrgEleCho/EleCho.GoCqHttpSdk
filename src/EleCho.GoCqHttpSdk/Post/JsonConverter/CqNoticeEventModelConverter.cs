using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post.JsonConverter;

internal class CqNoticeEventModelConverter : JsonConverter<CqNoticePostModel>
{
    public override CqNoticePostModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument doc = JsonDocument.ParseValue(ref reader);
        if (doc.RootElement.TryGetProperty(Consts.EnumNames.NoticeType, out JsonElement noticeTypeEle))
        {
            if (noticeTypeEle.ValueKind != JsonValueKind.String)
                return null;

            string noticeType = noticeTypeEle.GetString()!;
            return noticeType switch
            {
                Consts.NoticeType.GroupUpload => JsonSerializer.Deserialize<CqNoticeGroupUploadPostModel>(doc, options),
                Consts.NoticeType.GroupAdmin => JsonSerializer.Deserialize<CqNoticeGroupAdminPostModel>(doc, options),
                Consts.NoticeType.GroupIncrease => JsonSerializer.Deserialize<CqNoticeGroupIncreasePostModel>(doc, options),
                Consts.NoticeType.GroupDecrease => JsonSerializer.Deserialize<CqNoticeGroupDecreasePostModel>(doc, options),
                Consts.NoticeType.GroupBan => JsonSerializer.Deserialize<CqNoticeGroupBanPostModel>(doc, options),
                Consts.NoticeType.FriendAdd => JsonSerializer.Deserialize<CqNoticeFriendAddPostModel>(doc, options),
                Consts.NoticeType.GroupRecall => JsonSerializer.Deserialize<CqNoticeGroupRecallPostModel>(doc, options),
                Consts.NoticeType.FriendRecall => JsonSerializer.Deserialize<CqNoticeFriendRecallPostModel>(doc, options),
                Consts.NoticeType.GroupCard => JsonSerializer.Deserialize<CqNoticeGroupCardPostModel>(doc, options),
                Consts.NoticeType.OfflineFile => JsonSerializer.Deserialize<CqNoticeOfflineFilePostModel>(doc, options),
                Consts.NoticeType.Notify => JsonSerializer.Deserialize<CqNoticeNotifyPostModel>(doc, options),

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