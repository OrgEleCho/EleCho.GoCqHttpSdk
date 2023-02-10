using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取图片操作
    /// </summary>
    public class CqGetImageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取图像
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetImage;

        /// <summary>
        /// 文件名
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="filename">文件名</param>
        public CqGetImageAction(string filename) => Filename = filename;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetImageActionParamsModel(Filename);
        }
    }
}