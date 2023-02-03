
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqGroupMessageSender : CqMessageSender
    {
        internal CqGroupMessageSender()
        {
        }

        internal CqGroupMessageSender(CqGroupMessageSenderModel model) : base(model)
        {
            Card = model.card;
            Area = model.area;
            Level = model.level;
            Title = model.title;
            Role = CqEnum.GetRole(model.role);
        }

        public string Card { get; } = string.Empty;
        public string Area { get; } = string.Empty;
        public string Level { get; } = string.Empty;
        public string Title { get; } = string.Empty;
        public CqRole Role { get; }
    }
}