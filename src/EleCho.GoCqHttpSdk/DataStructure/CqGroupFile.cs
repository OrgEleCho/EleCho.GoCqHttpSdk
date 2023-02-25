using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 群文件
    /// </summary>
    public record class CqGroupFile
    {
        internal CqGroupFile()
        { }

        internal CqGroupFile(CqGroupFileModel model)
        {
            GroupId = model.group_id;
            FileId = model.file_id;
            FileName = model.file_name;
            Busid = model.busid;
            FileSize = model.file_size;
            UploadTime = DateTimeOffset.FromUnixTimeSeconds(model.upload_time).DateTime;
            ExpireTime = DateTimeOffset.FromUnixTimeSeconds(model.dead_time).DateTime;
            ModifyTime = DateTimeOffset.FromUnixTimeSeconds(model.modify_time).DateTime;
            DownloadTimes = model.download_times;
            Uploader = model.uploader;
            UploaderName = model.uploader_name;
        }


        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <param name="busid"></param>
        /// <param name="fileSize"></param>
        /// <param name="uploadTime"></param>
        /// <param name="deadTime"></param>
        /// <param name="modifyTime"></param>
        /// <param name="downloadTimes"></param>
        /// <param name="uploader"></param>
        /// <param name="uploaderName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CqGroupFile(long groupId, string fileId, string fileName, int busid, long fileSize, DateTime uploadTime, DateTime deadTime, DateTime modifyTime, int downloadTimes, long uploader, string uploaderName)
        {
            GroupId = groupId;
            FileId = fileId ?? throw new ArgumentNullException(nameof(fileId));
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            Busid = busid;
            FileSize = fileSize;
            UploadTime = uploadTime;
            ExpireTime = deadTime;
            ModifyTime = modifyTime;
            DownloadTimes = downloadTimes;
            Uploader = uploader;
            UploaderName = uploaderName ?? throw new ArgumentNullException(nameof(uploaderName));
        }


        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 文件 ID
        /// </summary>
        public string FileId { get; set; } = string.Empty;

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// 文件类型
        /// </summary>
        public int Busid { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownloadTimes { get; set; }

        /// <summary>
        /// 上传者 QQ
        /// </summary>
        public long Uploader { get; set; }

        /// <summary>
        /// 上传者名称
        /// </summary>
        public string UploaderName { get; set; } = string.Empty;
    }
}