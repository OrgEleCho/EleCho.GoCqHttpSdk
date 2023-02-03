using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqGroupHonorOwner
    {
        internal CqGroupHonorOwner(CqGroupHonorOwnerModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Avator = model.avatar;
            Description = model.description;
        }

        [JsonConstructor]
        public CqGroupHonorOwner(long userId, string nickname, string avator, string description)
        {
            UserId = userId;
            Nickname = nickname;
            Avator = avator;
            Description = description;
        }

        public long UserId { get; }
        public string Nickname { get; } = string.Empty;
        public string Avator { get; } = string.Empty;
        public string Description { get; } = string.Empty;
    }
}
