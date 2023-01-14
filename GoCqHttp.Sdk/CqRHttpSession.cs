using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public class CqRHttpSession : CqSession, ICqPostSession
    {
        readonly Uri baseUri;
        readonly string? secret;
        CqPostPipeline postPipeline;
        HMACSHA1? sha1;

        private HttpListener listener;

        public Uri BaseUri => baseUri;
        public string? Secret { get; set; }
        public HttpListener Listener => listener;

        public CqPostPipeline PostPipeline => postPipeline;

        public CqRHttpSession(CqRHttpSessionOptions options)
        {
            if (options.BaseUri == null)
                throw new ArgumentNullException(nameof(options.BaseUri), "BaseUri can't be null");

            baseUri = options.BaseUri;
            secret = options.Secret;
            postPipeline = new CqPostPipeline();

            listener = new HttpListener();
            listener.Prefixes.Add(baseUri.ToString());        // 之所以让用户传入 Uri 又自己转为 String, 是为了避免用户少写一个 "/" 而报错 (Uri 会自动补上这个

            if (secret != null)
            {
                byte[] tokenBin = Encoding.UTF8.GetBytes(secret);
                sha1 = new HMACSHA1(tokenBin);
            }
            
            _ = HttpListenerLoopAsync();
        }

        private bool Verify(string? signature, byte[] data)
        {
            if (signature == null)
                return sha1 == null;
            if (sha1 == null)
                return false;

            if (signature.StartsWith("sha1="))
                signature = signature.Substring(5);

            byte[] hash = sha1.ComputeHash(data);
            string realSignature = string.Join(null, hash.Select(bt => Convert.ToString(bt, 16).PadLeft(2, '0')));
            return signature == realSignature;
        }
        
        private async Task HttpListenerLoopAsync()
        {
            while (true)
            {
                if (!listener.IsListening)
                {
                    await Task.Delay(100);
                    continue;
                }

                var context = await listener.GetContextAsync();

                using MemoryStream ms = new MemoryStream();
                context.Request.InputStream.CopyTo(ms);

                byte[] data = ms.ToArray();
                if (Verify(context.Request.Headers["X-Signature"], data))
                {
                    string json = GlobalConfig.TextEncoding.GetString(data);
                    CqWsDataModel? wsDataModel = JsonSerializer.Deserialize<CqWsDataModel>(json, JsonHelper.Options);
                    if (wsDataModel is CqPostModel postModel)
                    {
                        CqPostContext? postContext = CqPostContext.FromModel(postModel);
                        postContext?.SetSession(this);

                        if (postContext is CqPostContext)
                        {
                            await postPipeline.ExecuteAsync(postContext);
                            context.Response.StatusCode = (int)HttpStatusCode.OK;
                            context.Response.Close();
                            continue;
                        }
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.Close();
                }
            }
        }

        public void Start()
        {
            listener.Start();
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}