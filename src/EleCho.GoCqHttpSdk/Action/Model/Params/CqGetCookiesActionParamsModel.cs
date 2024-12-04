namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetCookiesActionParamsModel(string domain) : CqActionParamsModel
{
    public string domain { get; } = domain;
}
