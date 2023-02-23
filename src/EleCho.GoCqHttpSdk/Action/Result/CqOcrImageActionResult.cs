using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public record class CqOcrImageActionResult : CqActionResult
    {
        internal CqOcrImageActionResult() { }

        /// <summary>
        /// 识别文本
        /// </summary>
        public CqTextDetection[] Texts { get; private set; } = Array.Empty<CqTextDetection>();

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; private set; } = string.Empty;


        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqOcrImageActionResultDataModel _m)
                throw new InvalidOperationException();

            Texts = Array.ConvertAll(_m.texts, txt_m => new CqTextDetection(txt_m));
            Language = _m.language;
        }
    }
}