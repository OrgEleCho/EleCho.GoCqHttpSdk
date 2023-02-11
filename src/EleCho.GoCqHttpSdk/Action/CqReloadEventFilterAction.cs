using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 重载事件过滤器操作
    /// </summary>
    public class CqReloadEventFilterAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="file">过滤器文件</param>
        public CqReloadEventFilterAction(string file)
        {
            File = file;
        }

        /// <summary>
        /// 过滤器文件
        /// </summary>
        public string File { get; set; } = string.Empty;

        /// <summary>
        /// 操作类型: 重载事件过滤器
        /// </summary>
        public override CqActionType ActionType => CqActionType.ReloadEventFilter;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqReloadEventFilterActionParamsModel(File);
        }
    }
}
