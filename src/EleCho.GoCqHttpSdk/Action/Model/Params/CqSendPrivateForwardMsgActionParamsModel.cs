using EleCho.GoCqHttpSdk.Message.DataModel;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendPrivateForwardMsgActionParamsModel : CqActionParamsModel
    {
        public CqSendPrivateForwardMsgActionParamsModel(long user_id, CqMsgModel[] messages)
        {
            this.user_id = user_id;
            this.messages = messages;
        }

        public long user_id { get; }

        /// <summary>
        /// CqMsgModel&lt;CqForwardNodeMsgDataModel&gt;[]
        /// </summary>
        public CqMsgModel[] messages { get; }
    }
}