namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqStatus
    {
        public bool AppInitialized { get; set; }
        public bool AppEnabled { get; set; }
        public bool PluginsGood { get; set; }
        public bool AppGood { get; set; }
        public bool Online { get; set; }
        public bool Good { get; set; }
        public CqStatusStatistics? Statistics { get; set; }
    }
}