#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 图像消息段
    /// </summary>
    public record class CqImageMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: 图像
        /// </summary>
        public override string MsgType => Consts.MsgType.Image;

        /// <summary>
        /// 文件
        /// </summary>
        public string File { get; set; }
        public CqImageType? ImageType { get; set; }
        public CqImageSubType ImageSubType { get; set; }
        public string Url { get; set; }
        public bool? Cache { get; set; }
        public CqImageEffect? ImageEffect { get; set; }
        public int? ThreadCount { get; set; }

        internal CqImageMsg()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="url"></param>
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

        internal override CqMsgDataModel? GetDataModel() =>
            new CqImageMsgDataModel(File, ImageTypeToString(ImageType), ((int)ImageSubType).ToString(), Url, Cache.ToInt(), (int?)ImageEffect, ThreadCount);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqImageMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            ImageType = ImageTypeFromString(m.type);
            ImageSubType = int.TryParse(m.subType, out int intsubtype) ? (CqImageSubType)intsubtype : CqImageSubType.Normal;
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

        /// <summary>
        /// 图片子类型
        /// </summary>
        public enum CqImageSubType
        {
            /// <summary>
            /// 正常图片
            /// </summary>
            Normal = 0,

            /// <summary>
            /// 表情包
            /// </summary>
            FacePack = 1,

            /// <summary>
            /// 热图
            /// </summary>
            HotImage = 2,

            /// <summary>
            /// 斗图
            /// </summary>
            FightImage = 3,

            /// <summary>
            /// 智图 ?
            /// </summary>
            SmartImage = 4,

            /// <summary>
            /// 贴图
            /// </summary>
            PinImage = 7,

            /// <summary>
            /// 自拍
            /// </summary>
            SelfCapture = 8,

            /// <summary>
            /// 贴图广告 ?
            /// </summary>
            PinAd = 9,

            /// <summary>
            /// 有待测试
            /// </summary>
            WaitForTest = 10,

            /// <summary>
            /// 热搜图
            /// </summary>
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