namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetEssenceMessageActionParamsModel : CqActionParamsModel
    {
        public CqSetEssenceMessageActionParamsModel(long message_id)
        {
            this.message_id = message_id;
        }

        public long message_id { get; }
    }
}
