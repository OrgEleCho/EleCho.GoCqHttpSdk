namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 消息上报上下文
    /// </summary>
    public abstract record class CqMessagePostContext : CqBaseMessagePostContext
    {
        /// <summary>
        /// 上报类型: 消息
        /// </summary>
        public override CqPostType PostType => CqPostType.Message;
    }
}