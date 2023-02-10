using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 检查 URL 安全性操作
    /// </summary>
    public class CqCheckUrlSafetyAction : CqAction
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public override CqActionType ActionType => CqActionType.CheckUrlSafety;

        /// <summary>
        /// 要检查的 URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="url">要检查的 URL</param>
        public CqCheckUrlSafetyAction(string url)
        {
            Url = url;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqCheckUrlSafetyActionParamsModel(Url);
        }
    }
}
