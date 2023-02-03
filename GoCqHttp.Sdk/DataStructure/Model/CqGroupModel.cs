#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal record class CqGroupModel
    {
        public CqGroupModel(long group_id, string group_name, string group_memo, uint group_create_time, uint group_level, int member_count, int max_member_count)
        {
            this.group_id = group_id;
            this.group_name = group_name;
            this.group_memo = group_memo;
            this.group_create_time = group_create_time;
            this.group_level = group_level;
            this.member_count = member_count;
            this.max_member_count = max_member_count;
        }

        public long group_id { get; }
        public string group_name { get; }
        public string group_memo { get; }
        public uint group_create_time { get; }
        public uint group_level { get; }
        public int member_count { get; }
        public int max_member_count { get; }
    }
}
