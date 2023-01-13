using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqMarkMessageAsReadAction : CqAction
    {
        public CqMarkMessageAsReadAction(long messageId)
        {
            MessageId = messageId;
        }

        public override CqActionType Type => CqActionType.MarkMessageAsRead;

        public long MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqMarkMessageAsReadActionParamsModel(MessageId);
        }
    }
}
