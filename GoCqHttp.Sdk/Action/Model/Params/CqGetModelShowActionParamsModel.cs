namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetModelShowActionParamsModel : CqActionParamsModel
    {
        public CqGetModelShowActionParamsModel(string model)
        {
            this.model = model;
        }

        public string model { get; set; }
    }
}