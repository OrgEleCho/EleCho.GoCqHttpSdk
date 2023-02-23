using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取分词
    /// </summary>
    public class CqGetWordSlicesAction : CqAction
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetWordSlices;

        /// <summary>
        /// 分词内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="content"></param>
        public CqGetWordSlicesAction(string content)
        {
            Content = content;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetWordSlicesActionParamsModel(Content);
        }
    }
}