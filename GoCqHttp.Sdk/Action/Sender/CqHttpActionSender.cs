using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Action.Result;
using EleCho.GoCqHttpSdk.Action.Result.Model;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Util;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public override async Task<CqActionResult?> SendActionAsync(CqAction action)
        {
            string actionType = CqEnum.GetString(action.Type) ?? "";
            CqActionParamsModel? paramsModel = action.GetParamsModel();
            string json = JsonSerializer.Serialize(paramsModel, paramsModel.GetType(), JsonHelper.GetOptions());
            StringContent content = new StringContent(json, GlobalConfig.TextEncoding, MediaTypeNames.Application.Json);

            HttpResponseMessage response = await Client.PostAsync(actionType, content);
            if (!response.IsSuccessStatusCode)
                return null;

            MemoryStream ms = new MemoryStream();
            response.Content.CopyTo(ms, null, default);
            string rstjson = GlobalConfig.TextEncoding.GetString(ms.ToArray());
            CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, options: null);

#if DEBUG
            Debug.WriteLine($"{action.Type} {JsonSerializer.Serialize(JsonDocument.Parse(rstjson), JsonHelper.GetOptions())}");
#endif

            if (resultRaw == null)
                return null;

            return CqActionResult.FromRaw(resultRaw, actionType);
        }
    }
}