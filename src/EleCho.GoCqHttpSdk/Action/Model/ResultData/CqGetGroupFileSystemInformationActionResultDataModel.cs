using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupFileSystemInformationActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupFileSystemInformationActionResultDataModel(int file_count, int limit_count, long used_space, long total_space)
        {
            this.file_count = file_count;
            this.limit_count = limit_count;
            this.used_space = used_space;
            this.total_space = total_space;
        }

        public int file_count { get; }
        public int limit_count { get; }
        public long used_space { get; }
        public long total_space { get; }
    }
}
