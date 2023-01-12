using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System.Threading.Tasks;

namespace TestConsole
{
    class MyPostPlugin : CqPostPlugin
    {
        public override void OnGroupMessage(CqGroupMessagePostContext context)
        {
            
        }

        public override async Task OnGroupMessageRecalledAsync(CqGroupMessageRecalledPostContext context)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;

            var msg = (await actionSession.GetMessageAsync(context.MessageId));

            await actionSession.SendGroupMessageAsync(context.GroupId, CqMsg.Chain("让我康康你撤回了什么: ", msg.Message));
        }
    }
}