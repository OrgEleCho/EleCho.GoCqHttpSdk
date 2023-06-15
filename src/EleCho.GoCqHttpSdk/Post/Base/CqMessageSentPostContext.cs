namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 自身消息上报上下文
    /// </summary>
    public abstract record class CqMessageSentPostContext : CqBaseMessagePostContext
    {
        /// <summary>
        /// 上报类型: 自身消息
        /// </summary>
        public override CqPostType PostType => CqPostType.MessageSent;

        internal override object? QuickOperationModel => null;
    }
}