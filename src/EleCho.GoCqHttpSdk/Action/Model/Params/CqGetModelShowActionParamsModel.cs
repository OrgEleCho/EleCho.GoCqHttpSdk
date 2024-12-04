namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetModelShowActionParamsModel(string model) : CqActionParamsModel
{
    public string model { get; } = model;
}