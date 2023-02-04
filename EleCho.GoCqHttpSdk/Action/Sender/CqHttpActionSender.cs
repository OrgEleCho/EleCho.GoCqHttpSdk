using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action.Model;

using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post.Model;
using static EleCho.GoCqHttpSdk.Utils.Consts;

namespace EleCho.GoCqHttpSdk.Action.Invoker
{
    /// <summary>
    /// HTTP 操作发送器
    /// </summary>
    public class CqHttpActionSender : CqActionSender
    {
        public HttpClient Client { get; }

        /// <summary>
        /// 新建一个 HTTP 操作发送器
        /// </summary>
        /// <param name="client"></param>
        public CqHttpActionSender(HttpClient client)
        {
            Client = client;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override async Task<CqActionResult?> InvokeActionAsync(CqAction action)
        {
            // 转为 Model
            string actionType = CqEnum.GetString(action.ActionType) ?? throw new Exception("Uknown action");
            CqActionParamsModel? paramsModel = action.GetParamsModel();
            
            // 转为 JSON 和 HTTP 内容
            string json = JsonSerializer.Serialize(paramsModel, paramsModel.GetType(), JsonHelper.Options);
            StringContent content = new StringContent(json, GlobalConfig.TextEncoding, "application/json");

            // 发送请求
            HttpResponseMessage response = await Client.PostAsync(actionType, content);
            if (!response.IsSuccessStatusCode)
                return null;

            // 读取响应
            MemoryStream ms = new MemoryStream();
            await response.Content.CopyToAsync(ms);
            string rstjson = GlobalConfig.TextEncoding.GetString(ms.ToArray());
            CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, options: null);

#if DEBUG
            Debug.WriteLine($"{action.ActionType} {JsonSerializer.Serialize(JsonDocument.Parse(rstjson), JsonHelper.Options)}");
#endif

            if (resultRaw == null)
                return null;

            return CqActionResult.FromRaw(resultRaw, actionType);
        }

        /// <summary>
        /// 处理快速操作
        /// </summary>
        /// <param name="context">上报数据模型</param>
        /// <param name="quickActionModel">快速操作数据模型</param>
        /// <returns></returns>
        internal override async Task<bool> HandleQuickAction(CqPostModel context, object quickActionModel)
        {
            object bodyModel = new
            {
                context = context,
                operation = quickActionModel
            };

            // 转为 JSON 和 HTTP 内容
            string json = JsonSerializer.Serialize(bodyModel, bodyModel.GetType(), JsonHelper.Options);
            StringContent content = new StringContent(json, GlobalConfig.TextEncoding, "application/json");

            // 发送请求
            HttpResponseMessage response = await Client.PostAsync(Consts.ActionType.HandleQuickOperation, content);
            if (!response.IsSuccessStatusCode)
                return false;

            // 未来可能在这里加些逻辑
            
            return true;
        }
    }
}