using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    public record class CqMessageSender
    {
        internal CqMessageSender(CqMessageSenderModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Gender = CqEnum.GetGender(model.sex);
            Age = model.age;
        }

        internal CqMessageSender()
        {

        }

        public long UserId { get; }
        public string Nickname { get; } = string.Empty;
        public CqGender Gender { get; }
        public int Age { get; }
    }
}