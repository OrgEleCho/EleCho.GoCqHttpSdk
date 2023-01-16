using EleCho.GoCqHttpSdk.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    public class CqGroup
    {
        internal CqGroup(CqGroupModel model)
        {
            GroupId = model.group_id;
            GroupName = model.group_name;
            GroupMemo = model.group_memo;
            GroupCreateTime = DateTimeOffset.FromUnixTimeSeconds(model.group_create_time).DateTime;
            GroupLevel = model.group_level;
            MemberCount = model.member_count;
            MaxMemberCount = model.max_member_count;
        }

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupMemo { get; set; }
        public DateTime GroupCreateTime { get; set; }
        public uint GroupLevel { get; set; }
        public int MemberCount { get; set; }
        public int MaxMemberCount { get; set; }
    }
}
