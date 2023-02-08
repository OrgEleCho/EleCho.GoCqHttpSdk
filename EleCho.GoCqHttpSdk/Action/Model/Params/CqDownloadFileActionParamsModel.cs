using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDownloadFileActionParamsModel : CqActionParamsModel
    {
        public CqDownloadFileActionParamsModel(string url, int thread_count, string[] headers)
        {
            this.url = url;
            this.thread_count = thread_count;
            this.headers = headers;
        }

        public string url { get;  }
        public int thread_count { get; }
        public string[] headers { get; }
    }
}
