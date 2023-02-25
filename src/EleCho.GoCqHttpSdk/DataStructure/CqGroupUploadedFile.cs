using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 群上传文件
    /// </summary>
    public record class CqGroupUploadedFile
    {
        internal CqGroupUploadedFile()
        {
        }

        internal CqGroupUploadedFile(CqGroupUploadedFileModel model)
        {
            Id = model.id;
            Name = model.name;
            Size = model.size;
            Busid = model.busid;
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="busid"></param>
        public CqGroupUploadedFile(string id, string name, long size, long busid)
        {
            Id = id;
            Name = name;
            Size = size;
            Busid = busid;
        }

        /// <summary>
        /// 文件 ID
        /// </summary>
        public string Id { get; } = string.Empty;

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// 目前不知道有啥用 (官网说的)
        /// </summary>
        public long Busid { get; }
    }
}