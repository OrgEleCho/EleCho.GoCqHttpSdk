using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqMsgAnonymous
    {
        internal CqMsgAnonymous(CqMsgAnonymousModel model)
        {
            Id = model.id;
            Name = model.name;
            Flag = model.flag;
        }

        public CqMsgAnonymous(long id, string name, string flag)
        {
            Id = id;
            Name = name;
            Flag = flag;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
    }
}