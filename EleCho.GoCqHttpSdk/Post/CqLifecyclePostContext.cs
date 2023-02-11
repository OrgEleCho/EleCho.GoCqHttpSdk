
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 生命周期上报上下文
    /// </summary>
    public class CqLifecyclePostContext : CqMetaEventPostContext
    {
        /// <summary>
        /// 元事件类型: 生命周期
        /// </summary>
        public override CqMetaEventType MetaEventType => CqMetaEventType.Lifecycle;

        /// <summary>
        /// 生命周期类型
        /// </summary>
        public CqLifecycleType LifecycleType { get; set; }

        internal CqLifecyclePostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaLifecyclePostModel metaModel)
                return;

            LifecycleType = CqEnum.GetLifecycleType(metaModel.sub_type);
        }
    }
}