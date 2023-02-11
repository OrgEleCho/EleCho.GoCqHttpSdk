using System;
using System.Collections.Generic;
using System.Linq;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 一个 CQ Action
    /// </summary>
    public abstract class CqAction
    {
        /// <summary>
        /// 当前操作的类型
        /// </summary>
        public abstract CqActionType ActionType { get; }

        /// <summary>
        /// 回显数据 (用来标记请求)
        /// </summary>
        public string? EchoData { get; set; }

        internal abstract CqActionParamsModel GetParamsModel();

        internal static CqActionModel ToModel(CqAction action)
        {
            return new CqActionModel(
                CqEnum.GetString(action.ActionType) ?? throw new Exception("Unknown action"),
                action.GetParamsModel(),
                action.EchoData);
        }
    }
}