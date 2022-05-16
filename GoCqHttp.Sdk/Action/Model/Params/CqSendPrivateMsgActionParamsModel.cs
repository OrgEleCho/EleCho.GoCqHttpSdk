using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendPrivateMsgActionParamsModel : CqActionParamsModel
    {
        public CqSendPrivateMsgActionParamsModel(long user_id, long group_id, CqMsgModel[] message, bool auto_escape)
        {
            this.user_id = user_id;
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }

        public long user_id { get; set; }
        public long group_id { get; set; }
        public CqMsgModel[] message { get; set; }
        
        [JsonIgnore]
        public bool auto_escape { get; set; }
    }

    internal class CqGetMsgActionParamsModel : CqActionParamsModel
    {
        public CqGetMsgActionParamsModel(long message_id) => this.message_id = message_id;

        public long message_id { get; set; }
    }

    //internal class 
}