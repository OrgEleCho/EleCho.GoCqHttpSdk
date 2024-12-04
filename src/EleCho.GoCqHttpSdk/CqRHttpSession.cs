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

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 反向 HTTP 会话
/// </summary>
public class CqRHttpSession : CqSession, ICqPostSession, IDisposable
{
    readonly Uri baseUri;
    readonly string? secret;
    private readonly CqPostPipeline postPipeline;
    private readonly HMACSHA1? sha1;

    private readonly HttpListener listener;
    private Task? mainLoopTask;

    /// <summary>
    /// 基地址
    /// </summary>
    public Uri BaseUri => baseUri;
    
    /// <summary>
    /// 密钥
    /// </summary>
    public string? Secret { get; set; }

    /// <summary>
    /// HTTP 监听器
    /// </summary>
    public HttpListener Listener => listener;

    /// <summary>
    /// 上报管线
    /// </summary>
    public CqPostPipeline PostPipeline => postPipeline;


    /// <summary>
    /// 当未捕捉的用户异常发生时
    /// </summary>
    public event UnhandledExceptionEventHandler? UnhandledException;

    /// <summary>
    /// 实例化类
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
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
    }

    private bool Verify(string? signature, byte[] data)
    {
        if (signature == null)
            return sha1 == null;
        if (sha1 == null)
            return false;

        if (signature.StartsWith("SHA1=", StringComparison.OrdinalIgnoreCase))
            signature = signature[5..];

        byte[] hash = sha1.ComputeHash(data);
        string realSignature = string.Join(null, hash.Select(bt => Convert.ToString(bt, 16).PadLeft(2, '0')));
        return signature == realSignature;
    }

    private async Task HttpListenerLoopAsync()
    {
        while (listener.IsListening)
        {
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

                    if (postContext is not null)
                    {
                        try
                        {
                            await postPipeline.ExecuteAsync(postContext);

                            if (postContext.QuickOperationModel is object quickActionModel)
                                JsonSerializer.Serialize(context.Response.OutputStream, quickActionModel, quickActionModel.GetType(), JsonHelper.Options);
                        }
                        catch (Exception ex)
                        {
                            UnhandledException?.Invoke(this, new UnhandledExceptionEventArgs(ex, false));
                        }

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

    /// <summary>
    /// 异步启动
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话已经启动</exception>
    public Task StartAsync()
    {
        if (listener.IsListening)
            throw new InvalidOperationException("Session is already started");

        listener.Start();
        mainLoopTask = HttpListenerLoopAsync();

        return Task.CompletedTask;
    }

    /// <summary>
    /// 异步停止
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话没有启动</exception>
    public Task StopAsync()
    {
        if (!listener.IsListening)
            throw new InvalidOperationException("Session is not started yet");

        listener.Stop();

        return Task.CompletedTask;
    }
    
    /// <summary>
    /// 异步等待关闭
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话没有启动</exception>
    public async Task WaitForShutdownAsync()
    {
        if (mainLoopTask == null)
            throw new InvalidOperationException("Session is not started yet");

        await mainLoopTask;
    }
    
    /// <summary>
    /// 异步运行 (异步启动并等待关闭)
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        await StartAsync();
        await WaitForShutdownAsync();
    }
    
    /// <summary>
    /// 同步启动
    /// </summary>
    public void Start() => StartAsync().Wait();

    /// <summary>
    /// 同步停止
    /// </summary>
    public void Stop() => StopAsync().Wait();

    /// <summary>
    /// 同步运行
    /// </summary>
    public void Run() => RunAsync().Wait();

    /// <summary>
    /// 同步等待关闭
    /// </summary>
    public void WaitForShutdown() => WaitForShutdownAsync().Wait();


    bool disposed = false;

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
        if (disposed)
            return;

        listener.Close();
        
        GC.SuppressFinalize(this);
        disposed = true;
    }
}