using System.Text.Json.Serialization;
using EleCho.GoCqHttpSdk.Enumeration;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model;


internal record class CqGroupMessageSenderModel : CqMessageSenderModel
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

    public string role { get; }
    public string card { get; }
    public string area { get; }
    public string level { get; }
    public string title { get; }
}