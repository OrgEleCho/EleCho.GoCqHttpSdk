using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Action.Sender
{
    /// <summary>
    /// 反向 WebSocket 的操作发送器
    /// </summary>
    public class CqRWsActionSender : CqActionSender
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="session"></param>
        public CqRWsActionSender(CqRWsSession session)
        {
            Session = session;
        }

        /// <summary>
        /// 持有当前反向 WebSocket ActionSender 的会话
        /// </summary>
        public CqRWsSession Session { get; }

        /// <summary>
        /// 使反向 WebSocket 会话中包含的所有连接都执行一个操作, 并返回第一个非空结果, 如果没有非空结果, 则返回空
        /// </summary>
        public override async Task<CqActionResult?> InvokeActionAsync(CqAction action)
        {
            CqActionResult? result = null;

            foreach (var connection in Session.Connections)
                if (await connection.ActionSender.InvokeActionAsync(action) is CqActionResult realRst)
                    result = realRst;
            foreach (var connection in Session.ApiConnections)
                if (await connection.ActionSender.InvokeActionAsync(action) is CqActionResult realRst)
                    result = realRst;

            return result;
        }


        /// <summary>
        /// 使反向 WebSocket 会话中包含的所有连接都处理一个快速操作, 返回是否有任何一个会话执行成功
        /// </summary>
        internal override async Task<bool> HandleQuickAction(CqPostContext context, CqPostModel postModel)
        {
            bool result = false;

            foreach (var connection in Session.Connections)
                result |= await connection.ActionSender.HandleQuickAction(context, postModel);
            foreach (var connection in Session.ApiConnections)
                result |= await connection.ActionSender.HandleQuickAction(context, postModel);

            return result;
        }
    }
}