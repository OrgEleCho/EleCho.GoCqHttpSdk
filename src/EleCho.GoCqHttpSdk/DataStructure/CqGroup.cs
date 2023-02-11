using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    public record class CqGroup
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

        public long GroupId { get; }
        public string GroupName { get; }
        public string GroupMemo { get; }
        public DateTime GroupCreateTime { get; }
        public uint GroupLevel { get; }
        public int MemberCount { get; }
        public int MaxMemberCount { get; }
    }
}
