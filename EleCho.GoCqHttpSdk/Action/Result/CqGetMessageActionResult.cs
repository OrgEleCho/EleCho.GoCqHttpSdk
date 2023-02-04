using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetMessageActionResult : CqActionResult
    {
        public bool IsGroupMsg { get; private set; }
        
        public long MessageId { get; private set; }
        public int RealId { get; private set; }
        public CqMessageSender Sender { get; private set; } = new CqMessageSender();
        public DateTime Time { get; private set; }
        public CqMsg[] Message { get; private set; } = Array.Empty<CqMsg>();
        public string RawMessage { get; private set; } = string.Empty;

        internal CqGetMessageActionResult() { }

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