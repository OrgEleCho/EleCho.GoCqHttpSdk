namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqReloadEventFilterActionParamsModel(string file) : CqActionParamsModel
{
    public string file { get; } = file;
}