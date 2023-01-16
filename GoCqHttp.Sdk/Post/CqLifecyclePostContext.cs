
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqLifecyclePostContext : CqMetaEventPostContext
    {
        public override CqMetaEventType MetaEventType => CqMetaEventType.Lifecycle;

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