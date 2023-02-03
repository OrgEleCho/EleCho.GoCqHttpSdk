using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqOfflineFile
    {
        internal CqOfflineFile()
        {
        }

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

        public string Name { get; } = string.Empty;
        public long Size { get; }
        public string Url { get; } = string.Empty;
    }
}