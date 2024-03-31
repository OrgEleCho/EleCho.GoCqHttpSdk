namespace EleCho.GoCqHttpSdk.Post.Interface
{
    /// <summary>
    /// 群聊上报标记（其实就是能读GroupId
    /// </summary>
    public interface IGroupPostContext
    {
        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; }
    }
}
