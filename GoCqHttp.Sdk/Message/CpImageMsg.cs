using System;
using NullLib.GoCqHttpSdk.Util;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqImageMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Image;

        public string File { get; set; }
        public CqImageType? ImageType { get; set; }
        public CqImageSubType ImageSubType { get; set; }
        public string Url { get; set; }
        public bool? Cache { get; set; }
        public CqImageEffect? ImageEffect { get; set; }
        public int? ThreadCount { get; set; }
        
        internal CqImageMsg() { }
        public CqImageMsg(string file, string url)
        {
            File = file;
            Url = url;
            ImageSubType = CqImageSubType.Normal;
        }
        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqImageDataModel(File, StrPascal.ToCamelStr(ImageType), ((int)ImageSubType).ToString(), Url, Cache.ToInt(), (int?)ImageEffect, ThreadCount));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqImageDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            ImageType = m.type switch
            {
                "flash" => CqImageType.Flash,
                "show" => CqImageType.Show,
                _ => null
            };
            ImageSubType = (CqImageSubType)int.Parse(m.subType!);
            Url = m.url;
            Cache = m.cache.ToBool();
            ImageEffect = (CqImageEffect?)m.id;
            ThreadCount = m.c;
        }

        public enum CqImageType
        {
            Flash, Show
        }
        public enum CqImageSubType
        {
            Normal = 0,
            FacePack = 1,
            HotImage = 2,
            FightImage = 3,
            SmartImage = 4,
            PinImage = 7,
            SelfCapture = 8,
            PinAd = 9,
            WaitForTest = 10,
            HotSearchedImage = 13
        }
        public enum CqImageEffect
        {
            Normal = 40000,
            Phantom = 40001,
            Shake = 40002,
            Brithday = 40003,
            LoveYou = 40004,
            MakeFriend = 40005
        }
    }

    internal class CqImageDataModel
    {
        public CqImageDataModel()
        {
        }

        public CqImageDataModel(string file, string? type, string? subType, string url, int? cache, int? id, int? c)
        {
            this.file = file;
            this.type = type;
            this.subType = subType;
            this.url = url;
            this.cache = cache;
            this.id = id;
            this.c = c;
        }

        public string file { get; set; }
        public string? type { get; set; }
        public string? subType { get; set; }
        public string url { get; set; }
        public int? cache { get; set; }
        public int? id { get; set; }
        public int? c { get; set; }
    }
}
