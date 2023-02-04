using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 一个 CQ Action
    /// </summary>
    public abstract class CqAction
    {
        public abstract CqActionType ActionType { get; }

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