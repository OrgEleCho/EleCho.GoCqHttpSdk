using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取好友列表
    /// </summary>
    public class CqGetFriendListActionResult : CqActionResult
    {
        internal CqGetFriendListActionResult() { }

        /// <summary>
        /// 好友列表
        /// </summary>
        public IReadOnlyList<CqFriend> Friends { get; private set; } = new List<CqFriend>(0).AsReadOnly();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetFriendListActionResultDataModel m)
                throw new ArgumentException();

            Friends = m.Select(fm => new CqFriend(fm)).ToList().AsReadOnly();
        }
    }
}
