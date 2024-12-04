#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqOcrImageActionParamsModel(string image) : CqActionParamsModel
{
    public string image { get; } = image;
}