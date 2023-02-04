using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDeleteEssenceMessageAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.DeleteEssenceMessage;

        public long MessageId { get; set; }

        public CqDeleteEssenceMessageAction(long messageId)
        {
            MessageId = messageId;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteEssenceMessageActionParamsModel(MessageId);
        }
    }
}
