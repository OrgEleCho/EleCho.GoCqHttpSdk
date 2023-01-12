namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqRecallMessageActionParamsModel : CqActionParamsModel
    {
        public CqRecallMessageActionParamsModel(int message_id)
        {
            this.message_id = message_id;
        }

        public int message_id { get; set; }
    }
}