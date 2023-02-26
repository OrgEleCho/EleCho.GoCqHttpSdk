#pragma warning disable IDE1006 // Naming Styles

using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqUploadGroupFileActionParamsModel : CqActionParamsModel
    {
        public CqUploadGroupFileActionParamsModel(long group_id, string file, string name, string? folder)
        {
            this.group_id = group_id;
            this.file = file;
            this.name = name;
            this.folder = folder;
        }

        public long group_id { get; }
        public string file { get; } = string.Empty;
        public string name { get; } = string.Empty;
        public string? folder { get; } = string.Empty;
    }
}