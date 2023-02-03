using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetEssenceMessageListActionResult : CqActionResult
    {
        internal CqGetEssenceMessageListActionResult()
        {
        }

        public IReadOnlyList<CqEssenceMessage> Messages { get; private set; } = Array.Empty<CqEssenceMessage>();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetEssenceMessageListActionResultDataModel _m)
                throw new Exception();

            Messages = _m.Select(v => new CqEssenceMessage(v)).ToList().AsReadOnly();
        }
    }
}
