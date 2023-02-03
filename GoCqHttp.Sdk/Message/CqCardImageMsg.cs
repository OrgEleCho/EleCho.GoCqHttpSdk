using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public record class CqCardImageMsg : CqMsg
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

        internal override CqMsgDataModel? GetDataModel() => new CqCardImageMsgDataModel(File, MinWidth, MinHeight, MaxWidth, MaxHeight, Source, Icon);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            if (model is not CqCardImageMsgDataModel m)
                throw new ArgumentException();

            File = m.file;
            MinWidth = m.minwidth;
            MinHeight = m.minheight;
            MaxWidth = m.maxwidth;
            MaxHeight = m.maxheight;
            Source = m.source;
            Icon = m.icon;
        }
    }
}