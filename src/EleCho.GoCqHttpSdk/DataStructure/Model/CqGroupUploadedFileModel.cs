using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqGroupUploadedFileModel
{
    [JsonConstructor]
    public CqGroupUploadedFileModel(string id, string name, long size, long busid)
    {
        this.id = id;
        this.name = name;
        this.size = size;
        this.busid = busid;
    }

    public string id { get; }
    public string name { get; }
    public long size { get; }
    public long busid { get; }
}