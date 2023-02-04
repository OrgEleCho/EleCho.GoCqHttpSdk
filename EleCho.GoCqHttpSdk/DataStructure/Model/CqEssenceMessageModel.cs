using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal class CqEssenceMessageModel
    {
        [JsonConstructor]
        public CqEssenceMessageModel(long sender_id, string sender_nick, long sender_time, long operator_id, string operator_nick, long operator_time, long message_id)
        {
            this.sender_id = sender_id;
            this.sender_nick = sender_nick;
            this.sender_time = sender_time;
            this.operator_id = operator_id;
            this.operator_nick = operator_nick;
            this.operator_time = operator_time;
            this.message_id = message_id;
        }

        public long sender_id { get; }
        public string sender_nick { get; }
        public long sender_time { get; }
        
        public long operator_id { get; }
        public string operator_nick { get; }
        public long operator_time { get; }

        public long message_id { get; }
    }
}
