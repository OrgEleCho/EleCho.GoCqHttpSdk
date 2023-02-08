#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupNicknameActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupNicknameActionParamsModel(long group_id, long user_id, string? card)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.card = card;
        }

        public long group_id { get; }
        public long user_id { get; }
        public string? card { get; }
    }
}
