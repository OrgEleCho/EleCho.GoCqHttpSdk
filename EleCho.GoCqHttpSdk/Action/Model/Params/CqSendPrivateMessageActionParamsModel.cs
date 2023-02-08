using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendPrivateMessageActionParamsModel : CqActionParamsModel
    {
        public CqSendPrivateMessageActionParamsModel(long user_id, long? group_id, CqMsgModel[] message, bool auto_escape)
        {
            this.user_id = user_id;
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }

        public long user_id { get; }
        public long? group_id { get; }
        public CqMsgModel[] message { get; }
        
        [JsonIgnore]
        public bool auto_escape { get; }
    }

    //internal class 
}