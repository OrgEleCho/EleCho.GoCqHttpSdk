using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.DataStructure;

/// <summary>
/// 状态信息
/// </summary>
public record class CqStatus
{
    internal CqStatus()
    {
    }

    internal CqStatus(CqStatusModel model)
    {
        AppInitialized = model.app_initialized;
        AppEnabled = model.app_enabled;
        PluginsGood = model.plugins_good;
        AppGood = model.app_good;
        Online = model.online;
        Good = model.good;
        Statistics = model.stat == null ? new CqStatusStatistics() : new CqStatusStatistics(model.stat);
    }

    /// <summary>
    /// 程序初始化完成
    /// </summary>
    public bool AppInitialized { get; }

    /// <summary>
    /// 程序已启用
    /// </summary>
    public bool AppEnabled { get; }

    /// <summary>
    /// 插件良好
    /// </summary>
    public bool? PluginsGood { get; }

    /// <summary>
    /// 应用良好
    /// </summary>
    public bool AppGood { get; }

    /// <summary>
    /// 在线
    /// </summary>
    public bool Online { get; }

    /// <summary>
    /// 状态良好
    /// </summary>
    public bool Good { get; }

    /// <summary>
    /// 统计信息
    /// </summary>
    public CqStatusStatistics Statistics { get; } = new CqStatusStatistics();
}