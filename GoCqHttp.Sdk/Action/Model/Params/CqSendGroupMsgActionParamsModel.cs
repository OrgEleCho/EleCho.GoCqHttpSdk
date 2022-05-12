using NullLib.GoCqHttpSdk.Message.DataModel;

namespace NullLib.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendGroupMsgActionParamsModel : CqSendMsgActionParamsModel
    {
        public CqSendGroupMsgActionParamsModel(long group_id, CqMsgModel[] message, bool auto_escape)
        {
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }

        internal CqSendGroupMsgActionParamsModel() { }


        public long group_id { get; set; }
    }
}
