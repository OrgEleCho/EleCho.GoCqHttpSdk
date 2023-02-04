using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetImageActionResult : CqActionResult
    {
        public int Size { get; private set; }
        public string Filename { get; private set; } = string.Empty;
        public string Url { get; private set; } = string.Empty;
        
        internal CqGetImageActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqGetImageActionResultDataModel dataModel)
            {
                Size = dataModel.size;
                Filename = dataModel.filename;
                Url = dataModel.filename;
            }
        }
    }
}