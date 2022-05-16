using EleCho.GoCqHttpSdk.DataStructure;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqStatusModel
    {
        public CqStatusModel()
        { }

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

        public bool app_initialized { get; set; }
        public bool app_enabled { get; set; }
        public bool plugins_good { get; set; }
        public bool app_good { get; set; }
        public bool online { get; set; }
        public bool good { get; set; }
        public CqStatusStatisticsModel stat { get; set; }
    }
}