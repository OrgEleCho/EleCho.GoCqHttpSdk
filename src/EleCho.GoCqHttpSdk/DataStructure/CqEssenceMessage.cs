using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public record class CqEssenceMessage
    {
        internal CqEssenceMessage(CqEssenceMessageModel model)
        {
            SenderId = model.sender_id;
            SenderNickname = model.sender_nick;

            OperatorId = model.operator_id;
            OperatorNickname = model.operator_nick;

            MessageId = model.message_id;

            SendTime = DateTimeOffset.FromUnixTimeSeconds(model.sender_time).DateTime;
            OperationTime = DateTimeOffset.FromUnixTimeSeconds(model.operator_time).DateTime;
        }
        
        [JsonConstructor]
        public CqEssenceMessage(long senderId, string senderNickname, long operatorId, string operatorNickname, long messageId, DateTime sendTime, DateTime operationTime)
        {
            SenderId = senderId;
            SenderNickname = senderNickname;
            OperatorId = operatorId;
            OperatorNickname = operatorNickname;
            MessageId = messageId;
            SendTime = sendTime;
            OperationTime = operationTime;
        }

        public long SenderId { get; }
        public string SenderNickname { get; }
        public long OperatorId { get; }
        public string OperatorNickname { get; }

        public long MessageId { get; }

        public DateTime SendTime { get; }
        public DateTime OperationTime { get; set; }
    }
}
