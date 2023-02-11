using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取登陆信息
    /// </summary>
    public class CqGetLoginInformationActionResult : CqActionResult
    {
        internal CqGetLoginInformationActionResult() { }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetLoginInformationActionResultDataModel _model)
                throw new Exception();

            UserId = _model.user_id;
            Nickname = _model.nickname;
        }
    }
}
