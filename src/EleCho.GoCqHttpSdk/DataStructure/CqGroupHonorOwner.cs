using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 群荣誉所有者信息
    /// </summary>
    public record class CqGroupHonorOwner
    {
        internal CqGroupHonorOwner(CqGroupHonorOwnerModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Avatar = model.avatar;
            Description = model.description;
        }

        /// <summary>
        /// 构建群荣誉所有者信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="nickname"></param>
        /// <param name="avator"></param>
        /// <param name="description"></param>
        [JsonConstructor]
        public CqGroupHonorOwner(long userId, string nickname, string avator, string description)
        {
            UserId = userId;
            Nickname = nickname;
            Avatar = avator;
            Description = description;
        }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; } = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; } = string.Empty;
    }
}
