namespace NullLib.GoCqHttpSdk.Post
{
    public class CqOfflineFile
    {
        internal CqOfflineFile(CqOfflineFileModel model)
        {
            Name = model.name;
            Size = model.size;
            Url = model.url;
        }

        public CqOfflineFile(string name, long size, string url)
        {
            Name = name;
            Size = size;
            Url = url;
        }

        public string Name { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
    }
}