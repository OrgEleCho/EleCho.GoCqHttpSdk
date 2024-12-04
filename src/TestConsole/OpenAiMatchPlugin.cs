using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Extension;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.MessageMatching;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Base;
//using EleCho.GoCqHttpSdk.MessageMatching;

#nullable enable

namespace TestConsole;

class OpenAiMatchPlugin(ICqActionSession actionSession, string apikey) : CqMessageMatchPostPlugin
{
    public HttpClient Client { get; } = new HttpClient();
    public ICqActionSession ActionSession { get; } = actionSession;
    public string Apikey { get; } = apikey;


    public class davinci_result
    {
        public class davinci_result_choices
        {
            public string text { get; set; }
            public int index { get; set; }
            public object logprobs { get; set; }
            public string finish_reason { get; set; }
        }
        public class davinci_result_usage
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }
        }
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public davinci_result_choices[] choices { get; set; }
        public davinci_result_usage usage { get; set; }
    }


    [CqMessageMatch("^davinci (?<prompt>.+)")]
    public async void Davinci(CqMessagePostContext context, string prompt)
    {
        var request =
            new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions")
            {
                Headers =
                {
                    { "Authorization", $"Bearer {Apikey}" }
                },

                Content = JsonContent.Create(
                    new
                    {
                        model = "text-davinci-003",
                        prompt = $"回答这句话: {prompt}\n",
                        max_tokens = 2048,
                        temperature = 0.5,
                    }),
            };

        var response = await Client.SendAsync(request);
        var davinci_rst = await response.Content.ReadFromJsonAsync<davinci_result>();

        if (davinci_rst == null)
            return;

        var davinci_rst_txt =
            string.Join(Environment.NewLine, davinci_rst.choices.Select(choice => choice.text)).Trim();

        if (context is CqGroupMessagePostContext groupContext)
        {
            await ActionSession.SendGroupMessageAsync(groupContext.GroupId, new CqMessage(davinci_rst_txt));
        }
        else if (context is CqPrivateMessagePostContext privateContext)
        {
            await ActionSession.SendPrivateMessageAsync(privateContext.UserId, new CqMessage(davinci_rst_txt));
        }
    }



    public async Task ImageEdit(CqMessagePostContext context)
    {

    }
}