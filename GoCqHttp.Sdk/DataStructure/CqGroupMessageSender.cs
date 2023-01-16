
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    public class CqGroupMessageSender : CqMessageSender
    {
        internal CqGroupMessageSender(CqGroupMessageSenderModel model) : base(model)
        {
            Card = model.card;
            Area = model.area;
            Level = model.level;
            Title = model.title;
            Role = CqEnum.GetRole(model.role);
        }

        public string Card { get; set; }
        public string Area { get; set; }
        public string Level { get; set; }
        public string Title { get; set; }
        public CqRole Role { get; set; }
    }
}