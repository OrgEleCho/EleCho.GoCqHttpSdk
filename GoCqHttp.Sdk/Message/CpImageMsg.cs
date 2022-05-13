#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

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

        internal CqImageMsg()
        { }

        public CqImageMsg(string file, string url)
        {
            File = file;
            Url = url;
            ImageSubType = CqImageSubType.Normal;
        }

        internal string ImageTypeToString(CqImageType? cqImageType)
        {
            return cqImageType switch
            {
                CqImageType.Flash => "flash",
                CqImageType.Show => "show",
                _ => ""
            };
        }

        internal CqImageType ImageTypeFromString(string? value)
        {
            return value switch
            {
                "flash" => CqImageType.Flash,
                "show" => CqImageType.Show,
                _ => CqImageType.Unknown
            };
        }

        internal override CqMsgDataModel GetDataModel() =>
            new CqImageMsgDataModel(File, ImageTypeToString(ImageType), ((int)ImageSubType).ToString(), Url, Cache.ToInt(), (int?)ImageEffect, ThreadCount);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqImageMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            ImageType = ImageTypeFromString(m.type);
            ImageSubType = (CqImageSubType)int.Parse(m.subType!);
            Url = m.url;
            Cache = m.cache.ToBool();
            ImageEffect = (CqImageEffect?)m.id;
            ThreadCount = m.c;
        }

        public enum CqImageType
        {
            Flash, Show,
            Unknown = -1
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
}