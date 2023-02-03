using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqGroupFile
    {
        internal CqGroupFile()
        {
        }

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

        public string Id { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public long Size { get; }
        public long BusId { get; }
    }
}