using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
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
            Statistics = new CqStatusStatistics(model.stat);
        }
        
        public bool AppInitialized { get; }
        public bool AppEnabled { get; }
        public bool? PluginsGood { get; }
        public bool AppGood { get; }
        public bool Online { get; }
        public bool Good { get; }
        public CqStatusStatistics Statistics { get; } = new CqStatusStatistics();
    }
}