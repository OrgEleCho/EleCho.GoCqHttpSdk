using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    public class CqAnonymousInfomation
    {
        internal CqAnonymousInfomation(CqAnonymousInformationModel model)
        {
            Id = model.id;
            Name = model.name;
            Flag = model.flag;
        }

        public CqAnonymousInfomation(long id, string name, string flag)
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