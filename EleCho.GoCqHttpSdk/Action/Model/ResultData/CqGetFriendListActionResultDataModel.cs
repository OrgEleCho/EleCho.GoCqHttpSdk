using System.Collections;
using System.Collections.Generic;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetFriendListActionResultDataModel : CqActionResultDataModel, IList<CqFriendModel>
    {
        readonly List<CqFriendModel> list = new List<CqFriendModel>();
        public CqFriendModel this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(CqFriendModel item) => list.Add(item);
        public void Clear() => list.Clear();
        public bool Contains(CqFriendModel item) => list.Contains(item);
        public void CopyTo(CqFriendModel[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
        public IEnumerator<CqFriendModel> GetEnumerator() => list.GetEnumerator();
        public int IndexOf(CqFriendModel item) => list.IndexOf(item);
        public void Insert(int index, CqFriendModel item) => list.Insert(index, item);
        public bool Remove(CqFriendModel item) => list.Remove(item);
        public void RemoveAt(int index) => list.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
    }
}
