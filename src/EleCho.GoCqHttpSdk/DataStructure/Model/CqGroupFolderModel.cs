using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqGroupFolderModel
{
    [JsonConstructor]
    public CqGroupFolderModel(long group_id, string folder_id, string folder_name, long create_time, long creator, string creator_name, int total_file_count)
    {
        this.group_id = group_id;
        this.folder_id = folder_id;
        this.folder_name = folder_name;
        this.create_time = create_time;
        this.creator = creator;
        this.creator_name = creator_name;
        this.total_file_count = total_file_count;
    }

    public long group_id { get; set; }
    public string folder_id { get; set; }
    public string folder_name { get; set; }
    public long create_time { get; set; }
    public long creator { get; set; }
    public string creator_name { get; set; }

    public int total_file_count { get; set; }
}