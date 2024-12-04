using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using static EleCho.GoCqHttpSdk.Utils.Consts.MsgType;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 表示一个简单的 CQ 码
/// </summary>
/// <param name="type"></param>
/// <param name="data"></param>
internal class CqCode(string type, Dictionary<string, string> data)
{
    public string Type { get; set; } = type;
    public Dictionary<string, string> Data { get; set; } = data;

    /// <summary>
    /// 从 CQ 码中取一个整数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public int? GetInt(string key)
    {
        if (Data.TryGetValue(key, out string? strInt))
        {
            if (int.TryParse(strInt, out int intValue))
                return intValue;
        }

        return null;
    }

    /// <summary>
    /// 从 CQ 码中取一个长整数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public long? GetLong(string key)
    {
        if (Data.TryGetValue(key, out string? strLong))
        {
            if (long.TryParse(strLong, out long longValue))
                return longValue;
        }

        return null;
    }

    /// <summary>
    /// 从 CQ 码中取一个浮点数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public double? GetDouble(string key)
    {
        if (Data.TryGetValue(key, out string? strDouble))
        {
            if (double.TryParse(strDouble, out double doubleValue))
                return doubleValue;
        }

        return null;
    }

    /// <summary>
    /// 从 CQ 码中取一个字符串
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? GetString(string key)
    {
        if (Data.TryGetValue(key, out string? strValue))
            return strValue;

        return null;
    }

    /// <summary>
    /// 将字符串进行 CQ 码转义
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Escape(string str)
    {
        StringBuilder sb = new StringBuilder(str);
        sb.Replace("&", "&amp;")
          .Replace("[", "&#91;")
          .Replace("]", "&#93;");
        return sb.ToString();
    }

    /// <summary>
    /// 将转移后的 CQ 码字符串还原
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Unescape(string str)
    {
        StringBuilder sb = new StringBuilder(str);
        sb.Replace("&amp;", "&")
          .Replace("&#91;", "[")
          .Replace("&#93;", "]");
        return sb.ToString();
    }

    /// <summary>
    /// 将 CQ 码对象转换为与之对应的字符串
    /// </summary>
    /// <param name="cqCode"></param>
    /// <returns></returns>
    public static string ToCqCodeString(CqCode cqCode)
    {
        if (cqCode.Type.Equals("TEXT", StringComparison.OrdinalIgnoreCase))
        {
            return Escape(
                cqCode.GetString("text") ??
                cqCode.GetString("TEXT") ??
                string.Empty);
        }
        else
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[CQ:");
            sb.Append(Escape(cqCode.Type));
            foreach (var item in cqCode.Data)
            {
                sb.Append(',');
                sb.Append(Escape(item.Key));
                sb.Append('=');
                sb.Append(Escape(item.Value));
            }
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// 从指定字符串中查找一个 CQ 码并输出这个 CQ 码的开始位置和长度
    /// </summary>
    /// <param name="str">要查找的字符串</param>
    /// <param name="index">开始索引</param>
    /// <param name="start">CQ 码的开始值, 如果找不到, 则是 -1</param>
    /// <param name="length">CQ 码的长度, 如果找不到, 则是 -1</param>
    /// <returns>返回一个 CQ 码, 如果找不到, 则是 null</returns>
    public static CqCode? FromCqCodeString(string str, int index, out int start, out int length)
    {
        start = -1;
        length = -1;

        int startIndex = str.IndexOf("[CQ:", index, StringComparison.OrdinalIgnoreCase);
        if (startIndex == -1)
            return null;

        int endIndex = str.IndexOf(']', startIndex);
        if (endIndex == -1)
            return null;

        start = startIndex;
        length = endIndex - startIndex + 1;

        int codeValueStart = startIndex + 4;              // 跳过 "[CQ:" 的CQ码值起始索引
        int codeValueLen = endIndex - codeValueStart;     // 计算CQ码值长度 不包括最后的 ']'
        string codeValue = str.Substring(codeValueStart, codeValueLen);
        string[] valueSegs = codeValue.Split(',');
        if (valueSegs.Length < 1)
            return null;

        string type = Unescape(valueSegs[0]);
        Dictionary<string, string> data = [];
        for (int i = 1; i < valueSegs.Length; i++)
        {
            int eqIndex = valueSegs[i].IndexOf('=');
            string key = Unescape(valueSegs[i][..eqIndex]);
            string value = eqIndex == -1 ? "" : Unescape(valueSegs[i][(eqIndex + 1)..]);

            data[key] = value;
        }

        return new CqCode(type, data);
    }

    /// <summary>
    /// 从一个 CQ 码序列中解析出所有 Cq 消息段
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static CqMsgModel[] ModelChainFromCqCodeString(string sequence)
    {
        int curIndex = 0;

        List<CqMsgModel> rst = [];

        while (curIndex < sequence.Length)
        {
            CqCode? code = FromCqCodeString(sequence, curIndex, out int cqStart, out int cqLength);

            if (code == null)
            {
                if (curIndex < sequence.Length)
                {
                    string txtLast = Unescape(sequence[curIndex..]);
                    rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtLast)));
                }

                break;
            }

            if (cqStart > curIndex)
            {
                string txtBefore = Unescape(sequence[curIndex..cqStart ]);
                rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtBefore)));
            }

            CqMsgDataModel? dataModel = code.Type switch
            {
                Text => CqTextMsgDataModel.FromCqCode(code),
                Image => CqImageMsgDataModel.FromCqCode(code),
                Record => CqRecordMsgDataModel.FromCqCode(code),
                Location => CqLocationMsgDataModel.FromCqCode(code),
                Anonymous => CqAnonymousMsgDataModel.FromCqCode(code),
                Face => CqFaceMsgDataModel.FromCqCode(code),
                At => CqAtMsgDataModel.FromCqCode(code),
                Rps => CqRpsMsgDataModel.FromCqCode(code),
                Shake => CqShakeMsgDataModel.FromCqCode(code),
                CardImage => CqCardImageMsgDataModel.FromCqCode(code),
                Contact => CqContactMsgDataModel.FromCqCode(code),
                Dice => CqDiceMsgDataModel.FromCqCode(code),
                Forward => CqForwardMsgDataModel.FromCqCode(code),
                Node => CqForwardMsgNodeDataModel.FromCqCode(code),
                Gift => CqGiftMsgDataModel.FromCqCode(code),
                Json => CqJsonMsgDataModel.FromCqCode(code),
                Poke => CqPokeMsgDataModel.FromCqCode(code),
                Redbag => CqRedEnvelopeMsgDataModel.FromCqCode(code),
                Reply => CqReplyMsgDataModel.FromCqCode(code),
                Share => CqShareMsgDataModel.FromCqCode(code),
                Video => CqVideoMsgDataModel.FromCqCode(code),
                Xml => CqXmlMsgDataModel.FromCqCode(code),
                Music => CqMusicMsgDataModel.FromCqCode(code),
                TTS => CqTtsMsgDataModel.FromCqCode(code),

                _ => throw new ArgumentException($"Unknown CQCode type: {code.Type}"),
            };

            rst.Add(new CqMsgModel(code.Type, dataModel));

            curIndex = cqStart + cqLength;
        }

        return [.. rst];
    }

    public static CqMsg[] ChainFromCqCodeString(string sequence)
    {
        return Array.ConvertAll(ModelChainFromCqCodeString(sequence), CqMsg.FromModel);
    }

    public override string ToString()
    {
        return ToCqCodeString(this);
    }
}