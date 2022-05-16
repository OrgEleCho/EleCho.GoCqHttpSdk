using EleCho.GoCqHttpSdk.Action.Invoker;
using System.Buffers.Text;
using System.Net.Http;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 正向 HTTP 会话
    /// 可用来发送 Action
    /// </summary>
    public class CqHttpSession : ICqActionSession
    {
        private HttpClient httpClient;
        private CqHttpActionSender actionSender;

        public HttpClient BaseClient => httpClient;
        public CqActionSender ActionSender => actionSender;

        public CqHttpSession(CqHttpSessionOptions options)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = options.BaseUri;
            if (options.AccessToken != null)
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.AccessToken}");

            actionSender = new CqHttpActionSender(httpClient);
        }
    }
}