namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDeleteMsgActionParamsModel : CqActionParamsModel
    {
        public CqDeleteMsgActionParamsModel(int message_id)
        {
            this.message_id = message_id;
        }

        public int message_id { get; set; }
    }
}