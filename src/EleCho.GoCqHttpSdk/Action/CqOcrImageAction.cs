using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 图片 OCR
    /// </summary>
    public class CqOcrImageAction : CqAction
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override CqActionType ActionType => CqActionType.OcrImage;

        /// <summary>
        /// 图片 ID
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="image"></param>
        public CqOcrImageAction(string image)
        {
            Image = image;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqOcrImageActionParamsModel(Image);
        }
    }
}