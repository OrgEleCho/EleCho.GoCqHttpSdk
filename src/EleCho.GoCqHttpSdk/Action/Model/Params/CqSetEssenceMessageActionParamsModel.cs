namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetEssenceMessageActionParamsModel(long message_id) : CqActionParamsModel
{
    public long message_id { get; } = message_id;
}
