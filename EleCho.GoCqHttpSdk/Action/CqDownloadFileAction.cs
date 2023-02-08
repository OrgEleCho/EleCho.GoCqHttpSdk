using System;
using System.Collections.Generic;
using System.Linq;
using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDownloadFileAction : CqAction
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        public CqDownloadFileAction(string url, int threadCount, Dictionary<string, string> headers)
        {
            Url = url;
            ThreadCount = threadCount;
            Headers = headers;
        }

        public override CqActionType ActionType => CqActionType.DownloadFile;

        public string Url { get; set; } = string.Empty;
        public int ThreadCount { get; set; } = 1;
        public Dictionary<string, string> Headers
        {
            get => headers;
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                headers = value;
            }
        }
        
        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDownloadFileActionParamsModel(Url, ThreadCount, new List<string>(Headers.Select(kv => string.Join("=", kv.Key, kv.Value))).ToArray());
        }
    }
}