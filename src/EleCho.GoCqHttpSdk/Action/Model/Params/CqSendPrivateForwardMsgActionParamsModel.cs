using EleCho.GoCqHttpSdk.Message.DataModel;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSendPrivateForwardMsgActionParamsModel(long user_id, CqMsgModel[] messages) : CqActionParamsModel
{
    public long user_id { get; } = user_id;

    /// <summary>
    /// CqMsgModel&lt;CqForwardNodeMsgDataModel&gt;[]
    /// </summary>
    public CqMsgModel[] messages { get; } = messages;
}