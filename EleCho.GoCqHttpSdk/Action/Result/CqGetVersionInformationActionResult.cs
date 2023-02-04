using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetVersionInformationActionResult : CqActionResult
    {
        internal CqGetVersionInformationActionResult()
        {
        }

        public string AppName { get; private set; } = string.Empty;
        public string AppFullName { get; private set; } = string.Empty;
        public string AppVersion { get; private set; } = string.Empty;

        public string CoolqEdition { get; private set; } = string.Empty;
        public string CoolqDirectory { get; private set; } = string.Empty;

        public bool IsGoCqHttp { get; private set; }
        public string PluginVersion { get; private set; } = string.Empty;
        public int PluginBuildNumber { get; private set; }
        public string PluginBuildConfiguration { get; private set; } = string.Empty;

        public string RuntimeOS { get; private set; } = string.Empty;
        public string RuntimeVersion { get; private set; } = string.Empty;

        public string Version { get; private set; } = string.Empty;
        
        public int Protocol { get; private set; }
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