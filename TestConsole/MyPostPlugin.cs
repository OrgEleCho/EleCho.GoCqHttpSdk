using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Threading.Tasks;

namespace TestConsole
{
    class MyPostPlugin : CqPostPlugin
    {
        public override async Task OnGroupMessageAsync(CqGroupMessagePostContext context)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;
            
            string text = context.Message.GetText();
            if (text.StartsWith("TTS:", StringComparison.OrdinalIgnoreCase))
            {
                await actionSession.SendGroupMessageAsync(context.GroupId, new CqTtsMsg(text[4..]));
            }
            else if (text.StartsWith("ToFace:"))
            {
                if (CqFaceMsg.FromName(text[7..]) is CqFaceMsg face)
                
                await actionSession.SendGroupMessageAsync(context.GroupId, face);
            }
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