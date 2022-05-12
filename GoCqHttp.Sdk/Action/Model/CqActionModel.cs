using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Action.Model
{
    internal class CqActionModel
    {
        public CqActionModel(string action, object @params)
        {
            this.action = action;
            this.@params = @params;
        }

        public CqActionModel(string action, object @params, string? echo) : this(action, @params) => this.echo = echo;

        public string action { get; set; }
        public object @params { get; set; }

        public string? echo { get; set; }
    }
}
