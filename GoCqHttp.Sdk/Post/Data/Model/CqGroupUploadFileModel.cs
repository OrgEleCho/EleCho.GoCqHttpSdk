namespace NullLib.GoCqHttpSdk.Post
{
    internal class CqGroupUploadFileModel
    {
        public CqGroupUploadFileModel() { }
        public CqGroupUploadFileModel(CqGroupUploadFilePostContext srdData)
        {
            id = srdData.Id;
            name = srdData.Name;
            size = srdData.Size;
            busid = srdData.BusId;
        }
        
        public string id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public long busid { get; set; }
    }
}
