namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqCheckUrlSafetyActionParamsModel : CqActionParamsModel
    {
        public CqCheckUrlSafetyActionParamsModel(string url)
        {
            this.url = url;
        }

        public string url { get; set; }
    }
}