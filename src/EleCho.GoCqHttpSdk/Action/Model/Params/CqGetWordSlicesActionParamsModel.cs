#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetWordSlicesActionParamsModel(string content) : CqActionParamsModel
{
    public string content { get; } = content;
}