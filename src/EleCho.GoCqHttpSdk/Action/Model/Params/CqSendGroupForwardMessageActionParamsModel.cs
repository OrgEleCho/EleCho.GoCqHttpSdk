using EleCho.GoCqHttpSdk.Message.DataModel;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSendGroupForwardMessageActionParamsModel(long group_id, CqMsgModel[] messages) : CqActionParamsModel
{
    public long group_id { get; } = group_id;

    /// <summary>
    /// CqMsgModel&lt;CqForwardNodeMsgDataModel&gt;[]
    /// </summary>
    public CqMsgModel[] messages { get; } = messages;
}