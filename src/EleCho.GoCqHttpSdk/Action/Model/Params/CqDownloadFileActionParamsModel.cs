namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqDownloadFileActionParamsModel(string url, int thread_count, string[] headers) : CqActionParamsModel
{
    public string url { get; } = url;
    public int thread_count { get; } = thread_count;
    public string[] headers { get; } = headers;
}
