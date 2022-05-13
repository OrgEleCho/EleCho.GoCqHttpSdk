using NullLib.GoCqHttpSdk.Action.Invoker;
using System.Net.Http;

namespace NullLib.GoCqHttpSdk
{
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