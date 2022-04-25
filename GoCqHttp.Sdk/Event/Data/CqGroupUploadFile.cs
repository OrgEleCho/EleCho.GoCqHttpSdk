namespace NullLib.GoCqHttpSdk.Event
{
    public class CqGroupUploadFile
    {
        internal CqGroupUploadFile(CqGroupUploadFileModel model)
        {
            Id = model.id;
            Name = model.name;
            Size = model.size;
            BusId = model.busid;
        }
        public CqGroupUploadFile(string id, string name, long size, long busid)
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
