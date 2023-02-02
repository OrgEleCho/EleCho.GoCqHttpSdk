using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqGroupHonorOwner
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

        public long UserId { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Avator { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
