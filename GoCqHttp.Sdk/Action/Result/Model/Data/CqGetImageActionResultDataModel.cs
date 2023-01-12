namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqGetImageActionResultDataModel : CqActionResultDataModel
    {
        public int size { get; set; }
        public string filename { get; set; }
        public string url { get; set; }
    }
}