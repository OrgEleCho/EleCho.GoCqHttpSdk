using EleCho.GoCqHttpSdk.Message.DataModel;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendGroupForwardMsgActionParamsModel : CqActionParamsModel
    {
        public CqSendGroupForwardMsgActionParamsModel(long group_id, CqMsgModel[] messages)
        {
            this.group_id = group_id;
            this.messages = messages;
        }

        public long group_id { get; set; }

        /// <summary>
        /// CqMsgModel&lt;CqForwardNodeMsgDataModel&gt;[]
        /// </summary>
        public CqMsgModel[] messages { get; set; }
    }
}