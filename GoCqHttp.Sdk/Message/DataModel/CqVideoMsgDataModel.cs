#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqVideoMsgDataModel : CqMsgDataModel
    {
        public CqVideoMsgDataModel()
        { }

        public CqVideoMsgDataModel(string file, string? cover, int? c)
        {
            this.file = file;
            this.cover = cover;
            this.c = c;
        }

        public string file { get; set; }
        public string? cover { get; set; }
        public int? c { get; set; }

        public static CqVideoMsgDataModel FromCqCode(CqCode code)
        {
            return new CqVideoMsgDataModel(
                code.GetString(nameof(file))!,
                code.GetString(nameof(cover)),
                code.GetInt(nameof(c)));
        }
    }
}