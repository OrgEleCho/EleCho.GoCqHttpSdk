using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    public class CqGroupFile
    {
        internal CqGroupFile(CqGroupFileModel model)
        {
            Id = model.id;
            Name = model.name;
            Size = model.size;
            BusId = model.busid;
        }

        public CqGroupFile(string id, string name, long size, long busid)
        {
            Id = id;
            Name = name;
            Size = size;
            BusId = busid;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public long BusId { get; set; }
    }
}