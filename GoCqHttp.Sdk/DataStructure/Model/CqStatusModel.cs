using EleCho.GoCqHttpSdk;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqStatusModel
    {
        public CqStatusModel(CqStatus srcData)
        {
            app_initialized = srcData.AppInitialized;
            app_enabled = srcData.AppEnabled;
            plugins_good = srcData.PluginsGood;
            app_good = srcData.AppGood;
            online = srcData.Online;
            good = srcData.Good;
            stat = new CqStatusStatisticsModel(srcData.Statistics);
        }

        [JsonConstructor]
        public CqStatusModel(bool app_initialized, bool app_enabled, bool plugins_good, bool app_good, bool online, bool good, CqStatusStatisticsModel stat)
        {
            this.app_initialized = app_initialized;
            this.app_enabled = app_enabled;
            this.plugins_good = plugins_good;
            this.app_good = app_good;
            this.online = online;
            this.good = good;
            this.stat = stat;
        }

        public bool app_initialized { get; set; }
        public bool app_enabled { get; set; }
        public bool plugins_good { get; set; }
        public bool app_good { get; set; }
        public bool online { get; set; }
        public bool good { get; set; }
        public CqStatusStatisticsModel stat { get; set; }
    }
}