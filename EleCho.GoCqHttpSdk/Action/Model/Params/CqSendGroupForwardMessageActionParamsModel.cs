using EleCho.GoCqHttpSdk.Message.DataModel;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendGroupForwardMessageActionParamsModel : CqActionParamsModel
    {
        public CqSendGroupForwardMessageActionParamsModel(long group_id, CqMsgModel[] messages)
        {
            this.group_id = group_id;
            this.messages = messages;
        }

        public long group_id { get; }

        /// <summary>
        /// CqMsgModel&lt;CqForwardNodeMsgDataModel&gt;[]
        /// </summary>
        public CqMsgModel[] messages { get; }
    }
}