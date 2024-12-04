using System.Collections.Generic;
using EleCho.GoCqHttpSdk.DataStructure;

namespace EleCho.GoCqHttpSdk.Message;

/// <summary>
/// 一个完整的转发消息 (包含许多节点)
/// </summary>
public class CqForwardMessage : List<CqForwardMessageNode>
{
    /// <summary>
    /// 实例化空的转发消息
    /// </summary>
    public CqForwardMessage()
    {
    }

    /// <summary>
    /// 根据指定节点实例化转发消息
    /// </summary>
    /// <param name="collection">一些消息节点</param>
    public CqForwardMessage(IEnumerable<CqForwardMessageNode> collection) : base(collection)
    {
    }

    /// <summary>
    /// 根据指定的容器容量初始化转发消息
    /// </summary>
    /// <param name="capacity">容量</param>
    public CqForwardMessage(int capacity) : base(capacity)
    {
    }
}