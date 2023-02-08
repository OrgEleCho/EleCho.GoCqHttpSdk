namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetModelShowActionParamsModel : CqActionParamsModel
    {
        public CqSetModelShowActionParamsModel(string model, string? model_show)
        {
            this.model = model;
            this.model_show = model_show;
        }

        public string model { get; }
        public string? model_show { get; }
    }
}