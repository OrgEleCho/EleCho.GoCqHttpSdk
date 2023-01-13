using EleCho.GoCqHttpSdk.Action.Model.Data;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetImageActionResult : CqActionResult
    {
        public int Size { get; set; }
        public string Filename { get; set; } = null!;
        public string Url { get; set; } = null!;
        
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