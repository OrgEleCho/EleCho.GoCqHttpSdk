using System.Collections.Generic;
using System.Text;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 一个完整的消息
    /// </summary>
    public class CqMessage : List<CqMsg>
    {
        /// <summary>
        /// 实例化空消息
        /// </summary>
        public CqMessage()
        {
        }

        /// <summary>
        /// 根据给定消息段, 实例化消息
        /// </summary>
        /// <param name="collection"></param>
        public CqMessage(IEnumerable<CqMsg> collection) : base(collection)
        {
        }

        /// <summary>
        /// 根据给定容器容量, 实例化消息
        /// </summary>
        /// <param name="capacity"></param>
        public CqMessage(int capacity) : base(capacity)
        {

        }

        /// <summary>
        /// 使用指定文本内容初始化一个带有文本内容的消息
        /// </summary>
        /// <param name="text"></param>
        public CqMessage(string text)
        {
            Add(new CqTextMsg(text));
        }

        /// <summary>
        /// 使用一个 CQ 消息段初始化一个消息
        /// </summary>
        /// <param name="msg"></param>
        public CqMessage(CqMsg msg) : this(1)
        {
            this[0] = msg;
        }

        /// <summary>
        /// 使用一些 CQ 消息段初始化一个消息
        /// </summary>
        /// <param name="msg">一堆消息段</param>
        public CqMessage(params CqMsg[] msg) : base(msg)
        {
            
        }

        /// <summary>
        /// 使用指定的消息段作为头部, 指定的消息作为内容, 初始化一个新的消息 (这是一个工具方法)
        /// </summary>
        /// <param name="head">头部消息段</param>
        /// <param name="msg">消息内容</param>
        public CqMessage(CqMsg head, CqMessage msg)
        {
            Add(head);
            AddRange(msg);
        }

        /// <summary>
        /// 使用指定的消息段作为头部, 指定的消息作为内容, 初始化一个新的消息 (这是一个工具方法)
        /// </summary>
        /// <param name="head1">第一个头部消息段</param>
        /// <param name="head2">第二个头部消息段</param>
        /// <param name="msg">消息内容</param>
        public CqMessage(CqMsg head1, CqMsg head2, CqMessage msg)
        {
            Add(head1);
            Add(head2);
            AddRange(msg);
        }

        /// <summary>
        /// 使用指定的消息段作为头部, 指定的消息作为内容, 初始化一个新的消息 (这是一个工具方法)
        /// </summary>
        /// <param name="head1">第一个头部消息段</param>
        /// <param name="head2">第二个头部消息段</param>
        /// <param name="head3">第三个头部消息段</param>
        /// <param name="msg">消息内容</param>
        public CqMessage(CqMsg head1, CqMsg head2, CqMsg head3, CqMessage msg)
        {
            Add(head1);
            Add(head2);
            Add(head3);
            AddRange(msg);
        }

        /// <summary>
        /// 使用指定的消息作为内容, 指定的消息段作为尾部, 初始化一个新的消息 (这是一个工具方法)
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="tails">尾部消息段</param>
        public CqMessage(CqMessage msg, params CqMsg[] tails)
        {
            AddRange(msg);
            AddRange(tails);
        }

        /// <summary>
        /// 使用指定的消息段作为头部和尾部, 指定的消息作为内容, 初始化一个新的消息 ()
        /// </summary>
        /// <param name="head">头部消息段</param>
        /// <param name="msg">消息内容</param>
        /// <param name="tails">尾部消息段</param>
        public CqMessage(CqMsg head, CqMessage msg, params CqMsg[] tails)
        {
            Add(head);
            AddRange(msg);
            AddRange(tails);
        }

        /// <summary>
        /// 使用指定的消息段作为头部和结尾, 指定的消息作为内容, 初始化一个新的消息
        /// </summary>
        /// <param name="head1">第一个头部消息段</param>
        /// <param name="head2">第二个头部消息段</param>
        /// <param name="msg">消息内容</param>
        /// <param name="tails">尾部消息段</param>
        public CqMessage(CqMsg head1, CqMsg head2, CqMessage msg, params CqMsg[] tails)
        {
            Add(head1);
            Add(head2);
            AddRange(msg);
            AddRange(tails);
        }

        /// <summary>
        /// 使用指定的消息段作为头部和结尾, 指定的消息作为内容, 初始化一个新的消息
        /// </summary>
        /// <param name="head1">第一个头部消息段</param>
        /// <param name="head2">第二个头部消息段</param>
        /// <param name="head3">第三个头部消息段</param>
        /// <param name="msg">消息内容</param>
        /// <param name="tails">尾部消息段</param>
        public CqMessage(CqMsg head1, CqMsg head2, CqMsg head3, CqMessage msg, params CqMsg[] tails)
        {
            Add(head1);
            Add(head2);
            Add(head3);
            AddRange(msg);
            AddRange(tails);
        }

        /// <summary>
        /// 在当前消息的头部添加一个消息段, 并返回当前消息实例
        /// </summary>
        /// <param name="msg">要添加的消息段</param>
        /// <returns>当前实例</returns>
        public CqMessage WithHead(CqMsg msg)
        {
            Insert(0, msg);
            return this;
        }

        /// <summary>
        /// 在当前消息的头部添加几个消息段, 并返回当前消息实例
        /// </summary>
        /// <param name="msg">要添加的消息段</param>
        /// <returns>当前实例</returns>
        public CqMessage WithHeads(params CqMsg[] msg)
        {
            InsertRange(0, msg);
            return this;
        }

        /// <summary>
        /// 在当前消息的尾部添加一个消息段, 并返回当前消息实例
        /// </summary>
        /// <param name="msg">要添加的消息段</param>
        /// <returns>当前实例</returns>
        public CqMessage WithTail(CqMsg msg)
        {
            Add(msg);
            return this;
        }

        /// <summary>
        /// 在当前消息的尾部添加几个消息段, 并返回当前消息实例
        /// </summary>
        /// <param name="msg">要添加的消息段</param>
        /// <returns>当前实例</returns>
        public CqMessage WithTails(params CqMsg[] msg)
        {
            AddRange(msg);
            return this;
        }


        /// <summary>
        /// 获取当前消息的文本内容
        /// </summary>
        public string Text
        { 
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var msg in this)
                    if (msg is CqTextMsg txtMsg)
                        sb.Append(txtMsg.Text);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 从 CQ 码序列创建一个消息
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static CqMessage FromCqCode(string sequence)
        {
            return new CqMessage(CqCode.ChainFromCqCodeString(sequence));
        }
    }
}