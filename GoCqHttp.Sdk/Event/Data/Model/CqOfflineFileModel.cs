namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqOfflineFileModel
    {
        public CqOfflineFileModel() { }
        public CqOfflineFileModel(CqOfflineFile srcData)
        {
            name = srcData.Name;
            size = srcData.Size;
            url = srcData.Url;
        }
        public string name { get; set; }
        public long size { get; set; }
        public string url { get; set; }
    }
}
