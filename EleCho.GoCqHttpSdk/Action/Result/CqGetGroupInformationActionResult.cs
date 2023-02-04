using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupInformationActionResult : CqActionResult
    {
        internal CqGetGroupInformationActionResult() { }

        public long GroupId { get; private set; }
        public string GroupName { get; private set; } = string.Empty;
        public string GroupMemo { get; private set; } = string.Empty;

        public DateTime GroupCreateTime { get; private set; }
        public uint GroupLevel { get; private set; }

        public int MemberCount { get; private set; }
        public int MaxMemberCount { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetGroupInformationActionResultDataModel m)
                throw new Exception();

            GroupId = m.group_id;
            GroupName = m.group_name;
            GroupMemo = m.group_memo;

            GroupCreateTime = DateTimeOffset.FromUnixTimeSeconds(m.group_create_time).DateTime;
            GroupLevel = m.group_level;

            MemberCount = m.member_count;
            MaxMemberCount = m.max_member_count;
        }
    }
}
