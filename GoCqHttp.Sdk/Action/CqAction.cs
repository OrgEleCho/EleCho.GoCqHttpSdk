using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 一个 CQ Action
    /// </summary>
    public abstract class CqAction
    {
        public abstract CqActionType Type { get; }
        public string? EchoData { get; set; }

        internal abstract CqActionParamsModel GetParamsModel();

        internal static CqActionModel ToModel(CqAction action)
        {
            return new CqActionModel(
                CqEnum.GetString(action.Type) ?? "",
                action.GetParamsModel(),
                action.EchoData);
        }
    }
}