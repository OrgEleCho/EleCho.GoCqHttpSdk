using EleCho.GoCqHttpSdk.Action.Result.Model.Data;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public class CqGetMsgActionResult : CqActionResult
    {
        public bool IsGroupMsg { get; set; }
        
        public int MessageId { get; set; }
        public int RealId { get; set; }
        public CqMsgSender Sender { get; set; }
        public DateTime Time { get; set; }
        public CqMsg[] Message { get; set; }
        public string RawMessage { get; set; }

        internal CqGetMsgActionResult()
        { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if(model is CqGetMsgActionResultDataModel dataModel)
            {
                IsGroupMsg = dataModel.group;
                MessageId = dataModel.message_id;
                RealId = dataModel.real_id;
                Sender = new CqMsgSender(dataModel.sender);
                Time = UnixTime.DateFromUnix(dataModel.time);
                Message = Array.ConvertAll(dataModel.message ?? Array.Empty<CqMsgModel>(), CqMsg.FromModel);
                RawMessage = dataModel.raw_message;
            }
        }
    }
}