#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetMessageActionParamsModel(long message_id) : CqActionParamsModel
{
    public long message_id { get; } = message_id;
}

//internal class 