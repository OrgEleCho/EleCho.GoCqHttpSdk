namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetForwardMsgActionParamsModel : CqActionParamsModel
    {
        public CqGetForwardMsgActionParamsModel(int message_id) => this.message_id = message_id;

        public int message_id { get; set; }
    }
}