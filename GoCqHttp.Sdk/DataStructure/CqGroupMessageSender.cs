
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    public class CqGroupMessageSender : CqMessageSender
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

        public string Card { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public CqRole Role { get; set; }
    }
}