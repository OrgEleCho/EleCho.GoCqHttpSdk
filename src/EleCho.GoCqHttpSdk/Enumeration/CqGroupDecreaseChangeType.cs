namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 群成员减少的变更类型
    /// </summary>
    public enum CqGroupDecreaseChangeType
    {
        /// <summary>
        /// 踢出
        /// </summary>
        Kick, 
        
        /// <summary>
        /// 退群
        /// </summary>
        Leave, 
        
        /// <summary>
        /// 自己被踢出
        /// </summary>
        KickMe,

        /// <summary>
        /// 未知
        /// </summary>
        Unknown = -1
    }
}