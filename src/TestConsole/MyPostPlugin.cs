using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Threading.Tasks;

namespace AssemblyCheck
{
    class MyPostPlugin : CqPostPlugin
    {
        const long TestGroupId = 295322097;
        const long TestUserId = 3257726229;
        
        public override async Task OnGroupMessageReceivedAsync(CqGroupMessagePostContext context)
        {
            //if(context.GroupId != 860355679) return;


            if(context.Session is not ICqActionSession actionSession)
                return;

            if (context.GroupId == TestGroupId)
                context.QuickOperation.Reply = new CqMessage("这是一个快速操作回复");
            
            string text = context.Message.Text;
            if (text.StartsWith("TTS:", StringComparison.OrdinalIgnoreCase))
            {
                await actionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(text[4..]));
            }
            else if (text.StartsWith("ToFace:"))
            {
                if (CqFaceMsg.FromName(text[7..]) is CqFaceMsg face)
                
                await actionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(face));
            }
        }

        public override async Task OnGroupMessageRecalledAsync(CqGroupMessageRecalledPostContext context)
        {
            //if(context.GroupId != 860355679) return;


            if(context.Session is not ICqActionSession actionSession)
                return;

            var msg = (await actionSession.GetMessageAsync(context.MessageId));

            await actionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(new CqAtMsg(context.UserId), "让我康康你撤回了什么: ", msg.Message, "\n嘿嘿, 撤回失败了吧~"));
        }

        public override async Task OnGroupMemberTitleChangedAsync(CqGroupMemberTitleChangeNoticedPostContext context)
        {
            //if(context.GroupId != 860355679) return;


            if(context.Session is not ICqActionSession actionSession)
                return;

            await actionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(new CqTextMsg($"有人头衔改变了哦, 内容是{context.NewTitle}")));


        }
    }
}