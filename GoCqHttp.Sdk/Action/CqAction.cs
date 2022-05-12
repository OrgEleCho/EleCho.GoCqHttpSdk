using NullLib.GoCqHttpSdk.Action.Model;
using NullLib.GoCqHttpSdk.Action.Model.Params;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Action
{
    public abstract class CqAction
    {
        public abstract string Type { get; }
        public string? EchoData { get; set; }

        internal abstract CqActionParamsModel GetParamsModel();

        internal static CqActionModel ToModel(CqAction action)
        {
            return new CqActionModel(action.Type, action.GetParamsModel(), action.EchoData);
        }
    }
}
