using System.Collections;
using System.Collections.Generic;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupListActionResultDataModel : CqActionResultDataModel, IList<CqGroupModel>
    {
        readonly List<CqGroupModel> list = new List<CqGroupModel>();
        public CqGroupModel this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(CqGroupModel item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(CqGroupModel item) => list.Contains(item);
        public void CopyTo(CqGroupModel[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public IEnumerator<CqGroupModel> GetEnumerator() => list.GetEnumerator();
        public int IndexOf(CqGroupModel item) => list.IndexOf(item);
        public void Insert(int index, CqGroupModel item) => list.Insert(index, item);
        public bool Remove(CqGroupModel item) => list.Remove(item);
        public void RemoveAt(int index) => list.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
