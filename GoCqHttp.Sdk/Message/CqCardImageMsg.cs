using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqCardImageMsg : CqMsg
    {
        public override string Type => Consts.MsgType.CardImage;

        internal CqCardImageMsg() { }
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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqCardImageDataModel(File, MinWidth, MinHeight, MaxWidth, MaxHeight, Source, Icon));
        internal override void ReadDataModel(object model) => throw new NotImplementedException();
    }

    internal class CqCardImageDataModel
    {
        public CqCardImageDataModel() { }
        public CqCardImageDataModel(string file, long? minwidth, long? minheight, long? maxwidth, long? maxheight, string? source, string? icon)
        {
            this.file = file;
            this.minwidth = minwidth;
            this.minheight = minheight;
            this.maxwidth = maxwidth;
            this.maxheight = maxheight;
            this.source = source;
            this.icon = icon;
        }

        public string file { get; set; }
        public long? minwidth { get; set; }
        public long? minheight { get; set; }
        public long? maxwidth { get; set; }
        public long? maxheight { get; set; }
        public string? source { get; set; }
        public string? icon { get; set; }
    }
}
