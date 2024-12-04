namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqDeleteUnidirectionalFriendActionParamsModel(long user_id) : CqActionParamsModel
{
    public long user_id { get; } = user_id;
}
