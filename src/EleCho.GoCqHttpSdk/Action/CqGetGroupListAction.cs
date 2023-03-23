using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群列表操作
    /// </summary>
    public class CqGetGroupListAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取群列表
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupList;

        /// <summary>
        /// 是否不使用缓存
        /// </summary>
        public bool NoCache { get; set; }

        /// <summary>
        /// 创建实例  (NoCache = false)
        /// </summary>
        public CqGetGroupListAction() : this(false)
        { }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="noCache">是否不使用缓存</param>
        public CqGetGroupListAction(bool noCache)
        {
            NoCache = noCache;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupListActionParamsModel(NoCache);
        }
    }
}
