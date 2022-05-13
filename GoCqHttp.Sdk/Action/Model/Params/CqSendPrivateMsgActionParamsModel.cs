using NullLib.GoCqHttpSdk.Message.DataModel;

namespace NullLib.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendPrivateMsgActionParamsModel : CqSendMsgActionParamsModel
    {
        public CqSendPrivateMsgActionParamsModel(long user_id, long group_id, CqMsgModel[] message, bool auto_escape)
        {
            this.user_id = user_id;
            this.group_id = group_id;
            this.message = message;
            this.auto_escape = auto_escape;
        }

        internal CqSendPrivateMsgActionParamsModel()
        { }

        public long user_id { get; set; }
        public long group_id { get; set; }
    }
}