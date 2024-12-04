using System;
using System.Collections.Generic;
using System.Linq;
using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 下载文件操作
/// </summary>
public class CqDownloadFileAction : CqAction
{
    private Dictionary<string, string> headers = [];

    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="url">文件 URL</param>
    /// <param name="threadCount">线程数</param>
    /// <param name="headers">请求头</param>
    public CqDownloadFileAction(string url, int threadCount, Dictionary<string, string> headers)
    {
        Url = url;
        ThreadCount = threadCount;
        Headers = headers;
    }

    /// <summary>
    /// 操作类型: 下载文件
    /// </summary>
    public override CqActionType ActionType => CqActionType.DownloadFile;

    /// <summary>
    /// 文件 URL
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 线程数
    /// </summary>
    public int ThreadCount { get; set; } = 1;

    /// <summary>
    /// 请求头
    /// </summary>
    public Dictionary<string, string> Headers
    {
        get => headers;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            headers = value;
        }
    }
    
    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDownloadFileActionParamsModel(Url, ThreadCount, new List<string>(Headers.Select(kv => string.Join("=", kv.Key, kv.Value))).ToArray());
    }
}