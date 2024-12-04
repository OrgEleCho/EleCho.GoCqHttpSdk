using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetGroupFileSystemInformationActionResultDataModel(int file_count, int limit_count, long used_space, long total_space) : CqActionResultDataModel
{
    public int file_count { get; } = file_count;
    public int limit_count { get; } = limit_count;
    public long used_space { get; } = used_space;
    public long total_space { get; } = total_space;
}
