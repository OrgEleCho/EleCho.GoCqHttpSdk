using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 自身私聊消息上报上下文 (可能是好友, 也有可能是临时会话)
/// </summary>
public partial record class CqPrivateSelfMessagePostContext : CqSelfMessagePostContext
{
    /// <summary>
    /// 消息类型: 私聊
    /// </summary>
    public override CqMessageType MessageType => CqMessageType.Private;

    /// <summary>
    /// 消息
    /// </summary>
    public CqPrivateMessageType PrivateMessageType { get; internal set; }

    /// <summary>
    /// 临时会话来源
    /// </summary>
    public CqTempSource TempSource { get; internal set; }

    /// <summary>
    /// 发送者
    /// </summary>
    public CqMessageSender Sender { get; internal set; } = new CqMessageSender();

    internal CqPrivateSelfMessagePostContext() { }

    /// <summary>
    /// 快速操作
    /// </summary>
    public CqPrivateMessagePostQuickOperation QuickOperation { get; }
        = new CqPrivateMessagePostQuickOperation();

    internal override object? QuickOperationModel => QuickOperation.GetModel();
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqPrivateSelfMessagePostModel msgModel)
            return;

        PrivateMessageType = CqEnum.GetPrivateMessageType(msgModel.sub_type);
        TempSource = (CqTempSource)msgModel.temp_source;
        Sender = new CqMessageSender(msgModel.sender);
    }
}