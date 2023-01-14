using EleCho.GoCqHttpSdk.Action.Model.Data;
using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetFriendListActionResult : CqActionResult
    {
        internal CqGetFriendListActionResult() { }

        public IReadOnlyList<CqFriend> Friends { get; set; } = null!;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetFriendListActionResultDataModel m)
                throw new ArgumentException();

            Friends = m.Select(fm => new CqFriend(fm)).ToList().AsReadOnly();
        }
    }
}
