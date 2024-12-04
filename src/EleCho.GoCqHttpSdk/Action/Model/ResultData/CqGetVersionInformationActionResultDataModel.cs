using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetVersionInformationActionResultDataModel(string app_name, string app_version, string app_full_name, string protocol_version, string coolq_edition, string coolq_directory, bool go_cqhttp, string plugin_version, int plugin_build_number, string plugin_build_configuration, string runtime_version, string runtime_os, string version, int protocol_name) : CqActionResultDataModel
{
    public string app_name { get; } = app_name;
    public string app_version { get; } = app_version;
    public string app_full_name { get; } = app_full_name;
    public int protocol_name { get; } = protocol_name;
    public string protocol_version { get; } = protocol_version;
    public string coolq_edition { get; } = coolq_edition;
    public string coolq_directory { get; } = coolq_directory;

    [JsonPropertyName("go-cqhttp")]
    public bool go_cqhttp { get; } = go_cqhttp;

    public string plugin_version { get; } = plugin_version;
    public int plugin_build_number { get; } = plugin_build_number;
    public string plugin_build_configuration { get; } = plugin_build_configuration;

    public string runtime_version { get; } = runtime_version;
    public string runtime_os { get; } = runtime_os;

    public string version { get; } = version;
}
