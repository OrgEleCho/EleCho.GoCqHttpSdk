using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupAvatarAction : CqAction
    {
        public CqSetGroupAvatarAction(long groupId, string file) : this(groupId, file, false) { }
        public CqSetGroupAvatarAction(long groupId, string file, bool useCache)
        {
            GroupId = groupId;
            File = file;
            UseCache = useCache;
        }

        public override CqActionType ActionType => CqActionType.SetGroupAvatar;

        public long GroupId { get; set; }
        public string File { get; set; } = string.Empty;
        public bool UseCache { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAvatarActionParamsModel(GroupId, File, UseCache ? 1 : 0);
        }
    }
}
