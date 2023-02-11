using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群信息操作结果
    /// </summary>
    public class CqGetGroupInformationActionResult : CqActionResult
    {
        internal CqGetGroupInformationActionResult() { }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; private set; }

        /// <summary>
        /// 群名
        /// </summary>
        public string GroupName { get; private set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string GroupMemo { get; private set; } = string.Empty;

        /// <summary>
        /// 建群时间
        /// </summary>
        public DateTime GroupCreateTime { get; private set; }

        /// <summary>
        /// 群等级
        /// </summary>
        public uint GroupLevel { get; private set; }

        /// <summary>
        /// 成员数量
        /// </summary>
        public int MemberCount { get; private set; }

        /// <summary>
        /// 最大群成员数量
        /// </summary>
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
