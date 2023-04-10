using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群头像操作
    /// </summary>
    public class CqSetGroupAvatarAction : CqAction
    {
        /// <summary>
        /// 实例化对象 (UseCache = false)
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="file">文件</param>
        public CqSetGroupAvatarAction(long groupId, string file) : this(groupId, file, false) { }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="file">文件</param>
        /// <param name="useCache">使用缓存</param>
        public CqSetGroupAvatarAction(long groupId, string file, bool useCache)
        {
            GroupId = groupId;
            File = file;
            UseCache = useCache;
        }

        /// <summary>
        /// 操作类型: 设置群头像
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetGroupAvatar;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
        public string File { get; set; } = string.Empty;

        /// <summary>
        /// 使用缓存
        /// </summary>
        public bool UseCache { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAvatarActionParamsModel(GroupId, File, UseCache ? 1 : 0);
        }
    }
}
