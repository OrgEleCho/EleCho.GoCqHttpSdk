using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取 Cookies 操作
    /// </summary>
    public class CqGetCookiesAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取 Cookies
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetCookies;

        /// <summary>
        /// 域
        /// </summary>
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="domain">域</param>
        public CqGetCookiesAction(string domain)
        {
            Domain = domain;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetCookiesActionParamsModel(Domain);
        }
    }
}
