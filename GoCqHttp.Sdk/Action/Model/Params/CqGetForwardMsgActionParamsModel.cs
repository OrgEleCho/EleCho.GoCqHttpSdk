namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetForwardMessageActionParamsModel : CqActionParamsModel
    {
        public CqGetForwardMessageActionParamsModel(int message_id) => this.message_id = message_id;

        public int message_id { get; set; }
    }
}