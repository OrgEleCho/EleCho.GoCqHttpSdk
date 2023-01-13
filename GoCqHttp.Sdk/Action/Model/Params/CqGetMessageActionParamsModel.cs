#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetMessageActionParamsModel : CqActionParamsModel
    {
        public CqGetMessageActionParamsModel(long message_id) => this.message_id = message_id;

        public long message_id { get; set; }
    }

    //internal class 
}