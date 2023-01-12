using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqGroupMsgSender : CqMessageSender
    {
        internal CqGroupMsgSender(CqGroupMsgSenderModel model) : base(model)
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