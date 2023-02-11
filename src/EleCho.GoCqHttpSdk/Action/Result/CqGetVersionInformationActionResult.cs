using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取版本信息操作结果
    /// </summary>
    public class CqGetVersionInformationActionResult : CqActionResult
    {
        internal CqGetVersionInformationActionResult()
        {
        }

        /// <summary>
        /// 应用名
        /// </summary>
        public string AppName { get; private set; } = string.Empty;

        /// <summary>
        /// 应用全名
        /// </summary>
        public string AppFullName { get; private set; } = string.Empty;

        /// <summary>
        /// 应用版本
        /// </summary>
        public string AppVersion { get; private set; } = string.Empty;


        /// <summary>
        /// 酷 Q 版本
        /// </summary>
        public string CoolqEdition { get; private set; } = string.Empty;

        /// <summary>
        /// 酷 Q 目录
        /// </summary>
        public string CoolqDirectory { get; private set; } = string.Empty;

        /// <summary>
        /// 是 Go-CqHttp
        /// </summary>
        public bool IsGoCqHttp { get; private set; }

        /// <summary>
        /// 插件版本
        /// </summary>
        public string PluginVersion { get; private set; } = string.Empty;

        /// <summary>
        /// 插件构建版本
        /// </summary>
        public int PluginBuildNumber { get; private set; }

        /// <summary>
        /// 插件构建配置
        /// </summary>
        public string PluginBuildConfiguration { get; private set; } = string.Empty;


        /// <summary>
        /// 运行时操作系统
        /// </summary>
        public string RuntimeOS { get; private set; } = string.Empty;

        /// <summary>
        /// 运行时版本
        /// </summary>
        public string RuntimeVersion { get; private set; } = string.Empty;

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; private set; } = string.Empty;
        

        /// <summary>
        /// 协议
        /// </summary>
        public int Protocol { get; private set; }

        /// <summary>
        /// 协议版本
        /// </summary>
        public string ProtocolVersion { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetVersionInformationActionResultDataModel _m)
                throw new Exception();

            AppName = _m.app_name;
            AppFullName = _m.app_full_name;
            AppVersion = _m.app_version;

            CoolqEdition = _m.coolq_edition;
            CoolqDirectory = _m.coolq_directory;

            IsGoCqHttp = _m.go_cqhttp;
            PluginVersion = _m.plugin_version;
            PluginBuildNumber = _m.plugin_build_number;
            PluginBuildConfiguration = _m.plugin_build_configuration;

            RuntimeOS = _m.runtime_os;
            RuntimeVersion = _m.runtime_version;

            Version = _m.version;
            Protocol = _m.protocol;
            ProtocolVersion = _m.protocol_version;
        }
    }
}