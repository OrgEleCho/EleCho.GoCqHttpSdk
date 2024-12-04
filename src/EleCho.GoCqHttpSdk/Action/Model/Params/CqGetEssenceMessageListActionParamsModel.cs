namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetEssenceMessageListActionParamsModel(long group_id) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
}
