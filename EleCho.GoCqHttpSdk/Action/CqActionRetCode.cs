namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// CQ Action 返回码
    /// </summary>
    public enum CqActionRetCode
    {
        /// <summary>
        /// 调用成功
        /// </summary>
        Okay = 0,

        /// <summary>
        /// 调用已经提交异步处理, 具体 api 调用是否成功无法得知
        /// </summary>
        Async = 1,

        /// <summary>
        /// 请求参数错误
        /// </summary>
        BadRequest = 1400,
        /// <summary>
        /// AccessToken 未提供
        /// </summary>
        Unauthorized = 1401,
        /// <summary>
        /// AccessToken 不符合
        /// </summary>
        Forbidden = 1403,
        /// <summary>
        /// API 不存在
        /// </summary>
        NotFound = 1404,
    }
}