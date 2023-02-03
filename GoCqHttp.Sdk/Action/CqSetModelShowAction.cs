using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetModelShowAction : CqAction
    {
        public CqSetModelShowAction(string model, string? modelShow)
        {
            Model = model;
            ModelShow = modelShow;
        }

        public override CqActionType Type => CqActionType.SetModelShow;

        public string Model { get; set; }
        public string? ModelShow { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetModelShowActionParamsModel(Model, ModelShow);
        }
    }
}
