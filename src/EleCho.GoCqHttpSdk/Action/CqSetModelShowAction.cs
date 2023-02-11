using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置在线显示机型操作
    /// </summary>
    public class CqSetModelShowAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="model">机型</param>
        /// <param name="modelShow">机型展示内容 (通过 GetModelShow 获取)</param>
        public CqSetModelShowAction(string model, string? modelShow)
        {
            Model = model;
            ModelShow = modelShow;
        }

        /// <summary>
        /// 操作类型: 设置在线显示机型
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetModelShow;

        /// <summary>
        /// 机型
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 机型展示内容
        /// </summary>
        public string? ModelShow { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetModelShowActionParamsModel(Model, ModelShow);
        }
    }
}
