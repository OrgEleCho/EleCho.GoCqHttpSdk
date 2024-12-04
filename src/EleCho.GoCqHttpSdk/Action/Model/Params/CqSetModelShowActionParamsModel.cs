namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetModelShowActionParamsModel(string model, string? model_show) : CqActionParamsModel
{
    public string model { get; } = model;
    public string? model_show { get; } = model_show;
}