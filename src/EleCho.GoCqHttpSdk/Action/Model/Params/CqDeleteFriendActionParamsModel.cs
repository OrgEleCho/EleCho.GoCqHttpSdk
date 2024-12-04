namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqDeleteFriendActionParamsModel(long user_id) : CqActionParamsModel
{
    public long user_id { get; } = user_id;
}
