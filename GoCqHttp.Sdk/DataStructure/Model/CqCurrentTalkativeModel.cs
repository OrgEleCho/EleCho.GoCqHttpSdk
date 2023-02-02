using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal class CqCurrentTalkativeModel
    {
        public long user_id { get; set; }
        public string nickname { get; set; } = string.Empty;
        public string avatar { get; set; } = string.Empty;
        public int day_count { get; set; }
    }
}
