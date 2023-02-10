using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置账户信息
    /// </summary>
    public class CqSetAccountProfileAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="company">公司</param>
        /// <param name="eMail">邮箱</param>
        /// <param name="college">大学</param>
        /// <param name="personalNote">个性签名</param>
        public CqSetAccountProfileAction(string nickname, string company, string eMail, string college, string personalNote)
        {
            Nickname = nickname;
            Company = company;
            EMail = eMail;
            College = college;
            PersonalNote = personalNote;
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetAccountProfile;

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// 大学
        /// </summary>
        public string College { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string PersonalNote { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetAccountProfileActionParamsModel(Nickname, Company, EMail, College, PersonalNote);
        }
    }
}
