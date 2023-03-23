using System.Collections;
using System.Collections.Generic;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupMemberListActionResultDataModel : CqActionResultDataModel, IList<CqGroupMemberModel>
    {
        readonly List<CqGroupMemberModel> list = new List<CqGroupMemberModel>();

        public CqGroupMemberModel this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(CqGroupMemberModel item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(CqGroupMemberModel item) => list.Contains(item);
        public void CopyTo(CqGroupMemberModel[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public IEnumerator<CqGroupMemberModel> GetEnumerator() => list.GetEnumerator();
        public int IndexOf(CqGroupMemberModel item) => list.IndexOf(item);
        public void Insert(int index, CqGroupMemberModel item) => list.Insert(index, item);
        public bool Remove(CqGroupMemberModel item) => list.Remove(item);
        public void RemoveAt(int index) => list.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
