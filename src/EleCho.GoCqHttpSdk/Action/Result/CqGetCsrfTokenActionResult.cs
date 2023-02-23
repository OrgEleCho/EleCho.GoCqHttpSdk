using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取 CSRF 令牌操作结果
    /// </summary>
    public record class CqGetCsrfTokenActionResult : CqActionResult
    {
        internal CqGetCsrfTokenActionResult()
        {
        }

        /// <summary>
        /// 令牌
        /// </summary>
        public int Token { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetCsrfTokenActionResultDataModel _m)
                throw new Exception();

            Token = _m.token;
        }
    }
}