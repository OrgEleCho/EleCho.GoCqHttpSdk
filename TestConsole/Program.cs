using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        static CqWsSession session = new CqWsSession(new CqWsSessionOptions()
        {
            BaseUri = new Uri("ws://127.0.0.1:5701"),
            UseApiEndPoint = true,
            UseEventEndPoint = true,
        });

        static CqHttpSession httpSession = new CqHttpSession(new CqHttpSessionOptions()
        {
            BaseUri = new Uri("http://127.0.0.1:5700"),
        });

        private static async Task Main(string[] args)
        {

            
            Assembly asm = typeof(CqWsSession).Assembly;
            CheckAssemblyTypes(asm);
            
            var manyMiddlewares = new ManyMiddlewares(httpSession);

            session.UsePlugin(new MyPostPlugin());

            session.UseGroupMessage(manyMiddlewares.WaterWaterWater);
            session.UseGroupRequest(async (context, next) =>
            {
                await httpSession.ApproveGroupRequestAsync(context.Flag, context.SubRequestType);     // 自动同意群聊邀请
            });


            await session.ConnectAsync();

            await session.SendGroupMessageAsync(687864919, CqMsg.CqCodeChain("测试捏[cq:cardimage,file=C:\\Users\\slime\\Pictures\\v2-8704ed02c12ce08ea5f06599dd88cdad_r.jpg]"));

            var friends = (await session.GetFriendListAsync())?.Friends ?? throw new Exception("无法获取好友列表");
            Console.WriteLine("好友列表:");
            foreach (var friend in friends)
                Console.WriteLine($"QQ: {friend.UserId}, 昵称: {friend.Nickname}");

            while (true)
                Console.ReadKey(true);
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
            Type[] allTypes = asm.GetTypes();

            Type typeCqActionParamsModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.Params.CqActionParamsModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");
            Type typeCqActionResultDataModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.Data.CqActionResultDataModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");

            Type[] cqActionTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqAction))).ToArray();
            Type[] cqActionParamsModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionParamsModel)).ToArray();
            Type[] cqActionResultTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqActionResult))).ToArray();
            Type[] cqActionResultDataModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionResultDataModel)).ToArray();

            foreach (var action in cqActionTypes)
                if (!action.IsPublic)
                    throw new Exception($"{action.FullName} 不是 public");

            foreach (var actionParamsModel in cqActionParamsModelTypes)
                if (actionParamsModel.IsPublic)
                    throw new Exception($"{actionParamsModel.FullName} 是 public");

            foreach (var actionResult in cqActionResultTypes)
            {
                if (!actionResult.IsPublic)
                    throw new Exception($"{actionResult.FullName} 不是 public");
                if (actionResult.GetConstructors().Length > 0)
                    throw new Exception($"{actionResult} 有公共的构造函数!");
            }

            foreach (var actionResultDataModel in cqActionResultDataModelTypes)
                if (actionResultDataModel.IsPublic)
                    throw new Exception($"{actionResultDataModel.FullName} 是 public");

            Console.WriteLine("类型访问级别检查通过");
        }
    }
}