using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 消息发送者
    /// </summary>
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

        /// <summary>
        /// 发送者QQ号
        /// </summary>
        public long UserId { get; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; } = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        public CqGender Gender { get; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; }
    }
}