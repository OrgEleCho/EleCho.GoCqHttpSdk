using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendGroupMessageActionParamsModel : CqActionParamsModel
    {
        public CqSendGroupMessageActionParamsModel(long group_id, CqMsgModel[] message, bool auto_escape)
        {
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }

        public long group_id { get; set; }
        public CqMsgModel[] message { get; set; }
        
        [JsonIgnore]
        public bool auto_escape { get; set; }
    }
}