using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Threading.Tasks;

namespace TestConsole
{
    class MyPostPlugin : CqPostPlugin
    {
        const long TestGroupId = 295322097;
        const long TestUserId = 3257726229;
        
        public override async Task OnGroupMessageAsync(CqGroupMessagePostContext context)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;

            if (context.GroupId == TestGroupId)
                context.QuickOperation.Reply = CqMsg.Chain("这是一个快速操作回复");
            
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

            await actionSession.SendGroupMessageAsync(context.GroupId, CqMsg.Chain(new CqAtMsg(context.UserId), "让我康康你撤回了什么: ", msg.Message, "\n嘿嘿, 撤回失败了吧~"));
        }
    }
}