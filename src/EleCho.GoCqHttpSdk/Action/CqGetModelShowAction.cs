using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取可用在线机型显示操作
    /// </summary>
    public class CqGetModelShowAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="model">机型</param>
        public CqGetModelShowAction(string model)
        {
            Model = model;
        }

        /// <summary>
        /// 操作类型: 获取可用在线机型显示
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetModelShow;

        /// <summary>
        /// 机型
        /// </summary>
        public string Model { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetModelShowActionParamsModel(Model);
        }
    }
}
