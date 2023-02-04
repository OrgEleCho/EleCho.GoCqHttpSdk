using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetAccountProfileActionParamsModel : CqActionParamsModel
    {
        public CqSetAccountProfileActionParamsModel(string nickname, string company, string email, string college, string personal_note)
        {
            this.nickname = nickname;
            this.company = company;
            this.email = email;
            this.college = college;
            this.personal_note = personal_note;
        }

        public string nickname { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string college { get; set; }
        public string personal_note { get; set; }
    }
}
