#pragma warning disable IDE1006 // Naming Styles

using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqCreateGroupFolderActionParamsModel : CqActionParamsModel
    {
        [JsonConstructor]
        public CqCreateGroupFolderActionParamsModel(long group_id, string name, string parent_id)
        {
            this.group_id = group_id;
            this.name = name;
            this.parent_id = parent_id;
        }

        public long group_id { get; }
        public string name { get; }
        public string parent_id { get; }
    }
}