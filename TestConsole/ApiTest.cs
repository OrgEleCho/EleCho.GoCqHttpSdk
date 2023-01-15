using EleCho.GoCqHttpSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal static class ApiTest
    {
        const long TestGroupId = 295322097;
        const long TestUserId = 3257726229;

        public static async Task RunAsync(ICqActionSession session)
        {
            await session.SendGroupMessageAsync(TestGroupId, "小机器人开始测试了捏");
            await session.SendPrivateMessageAsync(TestUserId, "你是人家的测试对象捏");

            await session.SendGroupForwardMessageAsync(TestGroupId, new CqForwardMessageNode("伞兵一号", TestUserId, "你好呀"));
            await session.SendPrivateForwardMessageAsync(TestUserId, new CqForwardMessageNode("伞兵一号", TestUserId, "你好呀"));

            await session.BanGroupAllMembersAsync(TestGroupId);
            await session.CancelBanGroupAllMembersAsync(TestGroupId);

            await session.BanGroupMemberAsync(TestGroupId, TestUserId, TimeSpan.FromSeconds(30));
            await session.CancelBanGroupMemberAsync(TestGroupId, TestUserId);
        }
    }
}
