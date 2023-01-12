using EleCho.GoCqHttpSdk.Action.Result.Model.Data;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public class CqGetMessageActionResult : CqActionResult
    {
        public bool IsGroupMsg { get; set; }
        
        public int MessageId { get; set; }
        public int RealId { get; set; }
        public CqMessageSender Sender { get; set; }
        public DateTime Time { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CqGetMessageActionResult()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if(model is CqGetMessageActionResultDataModel dataModel)
            {
                IsGroupMsg = dataModel.group;
                MessageId = dataModel.message_id;
                RealId = dataModel.real_id;
                Sender = new CqMessageSender(dataModel.sender);
                Time = UnixTime.DateFromUnix(dataModel.time);
                Message = Array.ConvertAll(dataModel.message ?? Array.Empty<CqMsgModel>(), CqMsg.FromModel);
                RawMessage = dataModel.raw_message;
            }
        }
    }
}