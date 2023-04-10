#pragma warning disable CS8618


namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 图片子类型
    /// </summary>
    public enum CqImageSubType
    {
        /// <summary>
        /// 正常图片
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 表情包
        /// </summary>
        FacePack = 1,

        /// <summary>
        /// 热图
        /// </summary>
        HotImage = 2,

        /// <summary>
        /// 斗图
        /// </summary>
        FightImage = 3,

        /// <summary>
        /// 智图 ?
        /// </summary>
        SmartImage = 4,

        /// <summary>
        /// 贴图
        /// </summary>
        PinImage = 7,

        /// <summary>
        /// 自拍
        /// </summary>
        SelfCapture = 8,

        /// <summary>
        /// 贴图广告 ?
        /// </summary>
        PinAd = 9,

        /// <summary>
        /// 有待测试
        /// </summary>
        WaitForTest = 10,

        /// <summary>
        /// 热搜图
        /// </summary>
        HotSearchedImage = 13
    }
}