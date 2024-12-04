using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqGroupFileModel
{
    [JsonConstructor]
    public CqGroupFileModel(long group_id, string file_id, string file_name, int busid, long file_size, long upload_time, long dead_time, long modify_time, int download_times, long uploader, string uploader_name)
    {
        this.group_id = group_id;
        this.file_id = file_id;
        this.file_name = file_name;
        this.busid = busid;
        this.file_size = file_size;
        this.upload_time = upload_time;
        this.dead_time = dead_time;
        this.modify_time = modify_time;
        this.download_times = download_times;
        this.uploader = uploader;
        this.uploader_name = uploader_name;
    }

    public long group_id { get; set; }
    public string file_id { get; set; }
    public string file_name { get; set; }
    public int busid { get; set; }

    public long file_size { get; set; }
    public long upload_time { get; set; }

    public long dead_time { get; set; }
    public long modify_time { get; set; }
    public int download_times { get; set; }

    public long uploader { get; set; }
    public string uploader_name { get; set; }
}