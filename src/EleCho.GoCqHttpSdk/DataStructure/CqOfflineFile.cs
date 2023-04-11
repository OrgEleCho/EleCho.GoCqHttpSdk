using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 离线文件
    /// </summary>
    public record class CqOfflineFile
    {
        internal CqOfflineFile()
        {
        }

        internal CqOfflineFile(CqOfflineFileModel model)
        {
            Name = model.name;
            Size = model.size;
            Url = model.url;
        }

        /// <summary>
        /// 实例化离线文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="url"></param>
        public CqOfflineFile(string name, long size, string url)
        {
            Name = name;
            Size = size;
            Url = url;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        /// 大小
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; } = string.Empty;
    }
}