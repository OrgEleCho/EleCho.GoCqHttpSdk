namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDeleteUnidirectionalFriendActionParamsModel : CqActionParamsModel
    {
        public CqDeleteUnidirectionalFriendActionParamsModel(long user_id)
        {
            this.user_id = user_id;
        }

        public long user_id { get; }
    }
}
