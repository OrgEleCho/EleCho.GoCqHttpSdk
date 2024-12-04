namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqCheckUrlSafetyActionParamsModel(string url) : CqActionParamsModel
{
    public string url { get; } = url;
}