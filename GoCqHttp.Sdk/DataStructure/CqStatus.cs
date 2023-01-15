using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    public class CqStatus
    {
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
        
        public bool AppInitialized { get; set; }
        public bool AppEnabled { get; set; }
        public bool? PluginsGood { get; set; }
        public bool AppGood { get; set; }
        public bool Online { get; set; }
        public bool Good { get; set; }
        public CqStatusStatistics Statistics { get; set; }
    }
}