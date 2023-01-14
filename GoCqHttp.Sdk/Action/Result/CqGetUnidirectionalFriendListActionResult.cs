using EleCho.GoCqHttpSdk.Action.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetUnidirectionalFriendListActionResult : CqActionResult
    {
        internal CqGetUnidirectionalFriendListActionResult() { }

        public IReadOnlyList<CqFriend> Friends { get; set; } = null!;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetUnidirectionalFriendListActionResultDataModel m)
                throw new ArgumentException();

            Friends = m.Select(fm => new CqFriend(fm)).ToList().AsReadOnly();
        }
    }
}
