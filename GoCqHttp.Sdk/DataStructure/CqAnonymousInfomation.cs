using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqAnonymousInfomation
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

        public long Id { get; }
        public string Name { get; }
        public string Flag { get; }
    }
}