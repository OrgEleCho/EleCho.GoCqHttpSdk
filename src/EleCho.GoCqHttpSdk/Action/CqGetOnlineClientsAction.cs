using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取在线客户端操作
    /// </summary>
    public class CqGetOnlineClientsAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取在线客户端
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetOnlineClients;

        /// <summary>
        /// 不使用缓存
        /// </summary>
        public bool NoCache { get; set; }

        /// <summary>
        /// 实例化对象 (NoCache = false)
        /// </summary>
        public CqGetOnlineClientsAction() : this(false)
        { }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="noCache">不使用缓存</param>
        public CqGetOnlineClientsAction(bool noCache)
        {
            NoCache = noCache;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetOnlineClientsActionParamsModel(NoCache);
        }
    }
}
