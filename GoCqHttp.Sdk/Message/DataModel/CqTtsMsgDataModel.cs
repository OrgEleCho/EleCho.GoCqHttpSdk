using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqTtsMsgDataModel : CqMsgDataModel
    {
        public CqTtsMsgDataModel()
        {
        }

        public CqTtsMsgDataModel(string text)
        {
            this.text = text;
        }

        public string text { get; set; } = string.Empty;

        public static CqTtsMsgDataModel FromCqCode(CqCode code)
        {
            return new CqTtsMsgDataModel(
                code.GetString(nameof(text))!);
        }
    }
}
