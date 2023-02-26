namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqReloadEventFilterActionParamsModel : CqActionParamsModel
    {
        public CqReloadEventFilterActionParamsModel(string file)
        {
            this.file = file;
        }

        public string file { get; }
    }
}