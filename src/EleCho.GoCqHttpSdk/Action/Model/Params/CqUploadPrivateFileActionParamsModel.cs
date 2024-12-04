#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqUploadPrivateFileActionParamsModel(long user_id, string file, string name) : CqActionParamsModel
{
    public long user_id { get; } = user_id;
    public string file { get; } = file;
    public string name { get; } = name;
}