#pragma warning disable IDE1006 // Naming Styles

using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDeleteGroupFileActionParamsModel : CqActionParamsModel
    {
        public CqDeleteGroupFileActionParamsModel(long group_id, string file_id, int busid)
        {
            this.group_id = group_id;
            this.file_id = file_id;
            this.busid = busid;
        }

        public long group_id { get; }
        public string file_id { get; }

        public int busid { get; }
    }
}