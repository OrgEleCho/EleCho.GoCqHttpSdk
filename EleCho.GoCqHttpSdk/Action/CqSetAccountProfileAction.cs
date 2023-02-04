using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetAccountProfileAction : CqAction
    {
        public CqSetAccountProfileAction(string nickname, string company, string eMail, string college, string personalNote)
        {
            Nickname = nickname;
            Company = company;
            EMail = eMail;
            College = college;
            PersonalNote = personalNote;
        }

        public override CqActionType ActionType => CqActionType.SetAccountProfile;

        public string Nickname { get; set; }
        public string Company { get; set; }
        public string EMail { get; set; }
        public string College { get; set; }
        public string PersonalNote { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetAccountProfileActionParamsModel(Nickname, Company, EMail, College, PersonalNote);
        }
    }
}
