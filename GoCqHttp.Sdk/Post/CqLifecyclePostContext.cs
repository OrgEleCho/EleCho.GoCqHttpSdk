using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqLifecyclePostContext : CqMetaEventPostContext
    {
        public override CqMetaType MetaEventType => CqMetaType.Lifecycle;

        public CqLifecycleType LifecycleType { get; set; }

        internal CqLifecyclePostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaLifecyclePostModel metaModel)
                return;

            LifecycleType = CqEnum.GetLifecycleType(metaModel.sub_type);
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqMetaLifecyclePostModel metaModel)
                return;

            metaModel.sub_type = CqEnum.GetString(LifecycleType);
        }
    }
}