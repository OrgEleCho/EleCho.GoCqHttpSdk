using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetModelShowAction : CqAction
    {
        public CqGetModelShowAction(string model)
        {
            Model = model;
        }

        public override CqActionType ActionType => CqActionType.GetModelShow;

        public string Model { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetModelShowActionParamsModel(Model);
        }
    }
}
