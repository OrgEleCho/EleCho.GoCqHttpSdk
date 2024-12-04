using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqOfflineFileModel
{
    [JsonConstructor]
    public CqOfflineFileModel(string name, long size, string url)
    {
        this.name = name;
        this.size = size;
        this.url = url;
    }

    public string name { get; }
    public long size { get; }
    public string url { get; }
}