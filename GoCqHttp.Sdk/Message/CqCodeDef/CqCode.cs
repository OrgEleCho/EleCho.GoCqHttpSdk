using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace EleCho.GoCqHttpSdk.Message.CqCodeDef
{
    internal class CqCode
    {
        public string Type { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public CqCode(string type, Dictionary<string, string> data)
        {
            Type = type;
            Data = data;
        }

        public int? GetInt(string key)
        {
            if (Data.TryGetValue(key, out string? strInt))
            {
                if (int.TryParse(strInt, out int intValue))
                {
                    return intValue;
                }
            }

            return null;
        }

        public long? GetLong(string key)
        {
            if (Data.TryGetValue(key, out string? strLong))
            {
                if (long.TryParse(strLong, out long longValue))
                {
                    return longValue;
                }
            }

            return null;
        }

        public double? GetDouble(string key)
        {
            if (Data.TryGetValue(key, out string? strDouble))
            {
                if (double.TryParse(strDouble, out double doubleValue))
                {
                    return doubleValue;
                }
            }

            return null;
        }

        public string? GetString(string key)
        {
            if (Data.TryGetValue(key, out string? strValue))
            {
                return strValue;
            }

            return null;
        }

        public static string Escape(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Replace("&", "&amp;")
              .Replace("[", "&#91;")
              .Replace("]", "&#93;");
            return sb.ToString();
        }

        public static string Unescape(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Replace("&amp;", "&")
              .Replace("&#91;", "[")
              .Replace("&#93;", "]");
            return sb.ToString();
        }

        public static string ToCqCodeString(CqCode cqCode)
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

        public static CqCode? FromCqCodeString(string str, int index, out int start, out int offset)
        {
            start = -1;
            offset = -1;

            int startIndex = str.IndexOf("[CQ:", index);
            if (startIndex == -1)
                return null;

            int endIndex = str.IndexOf(']', startIndex);
            if (endIndex == -1)
                return null;

            start = startIndex;
            offset = endIndex - startIndex + 1;

            int codeValueStart = startIndex + 4;              // 跳过 "[CQ:" 的CQ码值起始索引
            int codeValueLen = endIndex - codeValueStart;     // 计算CQ码值长度 不包括最后的 ']'
            string codeValue = str.Substring(codeValueStart, codeValueLen);
            string[] valueSegs = codeValue.Split(',');
            if (valueSegs.Length < 1)
                return null;

            string type = Unescape(valueSegs[0]);
            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int i = 1; i < valueSegs.Length; i++)
            {
                int eqIndex = valueSegs[i].IndexOf('=');
                string key = Unescape(valueSegs[i].Substring(0, eqIndex));
                string value = eqIndex == -1 ? "" : Unescape(valueSegs[i].Substring(eqIndex + 1));

                data[key] = value;
            }

            return new CqCode(type, data);
        }

        public static CqMsgModel[] ModelChainFromCqCodeString(string sequence)
        {
            int curIndex = 0;

            List<CqMsgModel> rst = new List<CqMsgModel>();

            while (curIndex < sequence.Length)
            {
                CqCode? code = FromCqCodeString(sequence, curIndex, out int cqStart, out int cqLength);

                if (code == null)
                {
                    if (curIndex < sequence.Length)
                    {
                        string txtLast = Unescape(sequence.Substring(curIndex));
                        rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtLast)));
                    }

                    break;
                }

                if (cqStart > curIndex)
                {
                    string txtBefore = Unescape(sequence.Substring(curIndex, cqStart - curIndex));
                    rst.Add(new CqMsgModel<CqTextMsgDataModel>("text", new CqTextMsgDataModel(txtBefore)));
                }

                CqMsgDataModel? dataModel = code.Type switch
                {
                    Consts.MsgType.Text => CqTextMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Image => CqImageMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Record => CqRecordMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Location => CqLocationMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Anonymous => CqAnonymousMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Face => CqFaceMsgDataModel.FromCqCode(code),
                    Consts.MsgType.At => CqAtMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Rps => CqRpsMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Shake => CqShakeMsgDataModel.FromCqCode(code),
                    Consts.MsgType.CardImage => CqCardImageMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Contact => CqContactMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Dice => CqDiceMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Forward => CqForwardMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Node => CqForwardMsgNodeDataModel.FromCqCode(code),
                    Consts.MsgType.Gift => CqGiftMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Json => CqJsonMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Poke => CqPokeMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Redbag => CqRedEnvelopeMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Reply => CqReplyMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Share => CqShareMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Video => CqVideoMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Xml => CqXmlMsgDataModel.FromCqCode(code),
                    Consts.MsgType.Music => CqMusicMsgDataModel.FromCqCode(code),

                    _ => null
                };

                rst.Add(new CqMsgModel(code.Type, dataModel));

                curIndex = cqStart + cqLength;
            }

            return rst.ToArray();
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
}