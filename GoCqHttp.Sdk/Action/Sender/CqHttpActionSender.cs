using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Action.Result;
using EleCho.GoCqHttpSdk.Action.Result.Model;

using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Invoker
{
    public class CqHttpActionSender : CqActionSender
    {
        public HttpClient Client { get; }

        public CqHttpActionSender(HttpClient client)
        {
            Client = client;
        }

        public override async Task<CqActionResult?> InvokeActionAsync(CqAction action)
        {
            string actionType = CqEnum.GetString(action.Type) ?? "";
            CqActionParamsModel? paramsModel = action.GetParamsModel();
            string json = JsonSerializer.Serialize(paramsModel, paramsModel.GetType(), JsonHelper.Options);
            StringContent content = new StringContent(json, GlobalConfig.TextEncoding, "application/json");

            HttpResponseMessage response = await Client.PostAsync(actionType, content);
            if (!response.IsSuccessStatusCode)
                return null;

            MemoryStream ms = new MemoryStream();
            await response.Content.CopyToAsync(ms);
            string rstjson = GlobalConfig.TextEncoding.GetString(ms.ToArray());
            CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, options: null);

#if DEBUG
            Debug.WriteLine($"{action.Type} {JsonSerializer.Serialize(JsonDocument.Parse(rstjson), JsonHelper.Options)}");
#endif

            if (resultRaw == null)
                return null;

            return CqActionResult.FromRaw(resultRaw, actionType);
        }
    }
}