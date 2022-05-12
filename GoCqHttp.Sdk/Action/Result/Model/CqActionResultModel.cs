using NullLib.GoCqHttpSdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Action.Result.Model
{
    internal class CqActionResultRaw : CqWsDataModel
    {
        public string status { get; set; }
        public int retcode { get; set; }
        public string? echo { get; set; }
        public JsonElement? data { get; set; }
    }
}