namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqRecallMessageActionParamsModel : CqActionParamsModel
    {
        public CqRecallMessageActionParamsModel(long message_id)
        {
            this.message_id = message_id;
        }

        public long message_id { get; set; }
    }
}