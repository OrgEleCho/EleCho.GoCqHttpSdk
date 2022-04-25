namespace NullLib.GoCqHttpSdk.Event
{
    public class CqMessageAnonymous
    {
        internal CqMessageAnonymous(CqMessageAnonymousModel model)
        {
            Id = model.id;
            Name = model.name;
            Flag = model.flag;
        }
        public CqMessageAnonymous(long id, string name, string flag)
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
