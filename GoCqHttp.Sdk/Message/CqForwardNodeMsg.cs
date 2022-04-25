using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqForwardNodeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Node;

        public int? Id { get; set; }
        public string? Name { get; set; }
        public long? QQ { get; set; }
        public CqMsg[]? Content { get; set; }
        public CqMsg[]? Seq { get; set; }

        internal CqForwardNodeMsg() { }
        public CqForwardNodeMsg(int id)
        {
            Id = id;
        }

        public CqForwardNodeMsg(string name, long qq, CqMsg[] content)
        {
            Name = name;
            QQ = qq;
            Content = content;
        }

        public CqForwardNodeMsg(string name, long qq, CqMsg[] content, CqMsg[] seq)
        {
            Name = name;
            QQ = qq;
            Content = content;
            Seq = seq;
        }


        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqForwardNodeDataModel(Id, Name, QQ, Content, Seq));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqForwardNodeDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Name = m.name;
            QQ = m.uin;
            Content = m.content;
            Seq = m.seq;
        }
    }

    internal class CqForwardNodeDataModel
    {
        public CqForwardNodeDataModel() { }
        public CqForwardNodeDataModel(int? id, string? name, long? uin, CqMsg[]? content, CqMsg[]? seq)
        {
            this.id = id;
            this.name = name;
            this.uin = uin;
            this.content = content;
            this.seq = seq;
        }

        public int? id { get; set; }
        public string? name { get; set; }
        public long? uin { get; set; }
        public CqMsg[]? content { get; set; }
        public CqMsg[]? seq { get; set; }
    }
}
