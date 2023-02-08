using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqReloadEventFilterAction : CqAction
    {
        public CqReloadEventFilterAction(string file)
        {
            File = file;
        }

        public string File { get; set; } = string.Empty;

        public override CqActionType ActionType => CqActionType.ReloadEventFilter;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqReloadEventFilterActionParamsModel(File);
        }
    }
}
