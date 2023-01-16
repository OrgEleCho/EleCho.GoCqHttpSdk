using EleCho.GoCqHttpSdk;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post
{

    internal class CqGroupMessageSenderModel : CqMessageSenderModel
    {

        public CqGroupMessageSenderModel(CqGroupMessageSender srcData) : base(srcData)
        {
            role = CqEnum.GetString(srcData.Role) ?? string.Empty;
            card = srcData.Card;
            area = srcData.Area;
            level = srcData.Level;
            title = srcData.Title;
        }

        [JsonConstructor]
        public CqGroupMessageSenderModel(
            long user_id, string nickname, string sex, int age,
            string role, string card, string area, string level, string title) : base(user_id, nickname, sex, age)
        {
            this.role = role;
            this.card = card;
            this.area = area;
            this.level = level;
            this.title = title;
        }

        public string role { get; set; }
        public string card { get; set; }
        public string area { get; set; }
        public string level { get; set; }
        public string title { get; set; }
    }
}