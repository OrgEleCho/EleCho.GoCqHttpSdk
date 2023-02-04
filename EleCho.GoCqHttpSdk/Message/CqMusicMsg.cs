
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 音乐分享
    /// </summary>
    public record class CqMusicMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Music;

        internal CqMusicMsg()
        { }

        public CqMusicMsg(CqMusicType type, long id)
        {
            MusicType = type;
            Id = id;
        }

        /// <summary>
        /// 说明: 分别表示使用 QQ 音乐、网易云音乐、虾米音乐
        /// 可能的值: qq, 163, xm
        /// </summary>
        public virtual CqMusicType MusicType { get; set; }

        /// <summary>
        /// 说明: 歌曲 ID
        /// </summary>
        public virtual long Id { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqMusicMsgDataModel(GetMusicTypeFromEnum(MusicType), Id);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqMusicMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            MusicType = GetMusicTypeFromString(m.type);
            Id = m.id;
        }

        public static string GetMusicTypeFromEnum(CqMusicType name)
        {
            return name switch
            {
                CqMusicType.QQ => "qq",
                CqMusicType.Netease => "163",
                CqMusicType.XiaMi => "xm",
                CqMusicType.Custom => "custom",

                _ => string.Empty,
            };
        }

        public static CqMusicType GetMusicTypeFromString(string name)
        {
            return name switch
            {
                "qq" => CqMusicType.QQ,
                "163" => CqMusicType.Netease,
                "xm" => CqMusicType.XiaMi,
                "custom" => CqMusicType.Custom,

                _ => CqMusicType.Unknown,
            };
        }
    }
}