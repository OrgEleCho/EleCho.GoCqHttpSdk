namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetImageActionParamsModel : CqActionParamsModel
    {
        public CqGetImageActionParamsModel(string file) => this.file = file;

        public string file { get; set; }
    }
}