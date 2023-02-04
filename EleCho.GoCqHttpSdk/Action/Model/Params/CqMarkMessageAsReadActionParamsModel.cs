#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqMarkMessageAsReadActionParamsModel : CqActionParamsModel
    {
        public long message_id { get; set; }

        public CqMarkMessageAsReadActionParamsModel(long message_id)
        {
            this.message_id = message_id;
        }
    }
}
