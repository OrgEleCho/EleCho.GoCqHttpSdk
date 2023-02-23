using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqOcrImageActionResultDataModel : CqActionResultDataModel
    {
        public CqOcrImageActionResultDataModel(CqTextDetectionModel[] texts, string language)
        {
            this.texts = texts;
            this.language = language;
        }

        public CqTextDetectionModel[] texts { get; }
        public string language { get; }
    }
}
