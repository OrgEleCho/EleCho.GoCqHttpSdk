using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqCardImageMsg : CqMsg
    {
        public override string Type => Consts.MsgType.CardImage;

        internal CqCardImageMsg()
        { }

        public CqCardImageMsg(string file)
        {
            File = file;
        }

        public string File { get; set; }
        public long? MinWidth { get; set; }
        public long? MinHeight { get; set; }
        public long? MaxWidth { get; set; }
        public long? MaxHeight { get; set; }
        public string? Source { get; set; }
        public string? Icon { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqCardImageMsgDataModel(File, MinWidth, MinHeight, MaxWidth, MaxHeight, Source, Icon);

        internal override void ReadDataModel(CqMsgDataModel model) => throw new NotImplementedException();
    }
}