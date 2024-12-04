using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Collections;
using System.Collections.Generic;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

internal class CqGetEssenceMessageListActionResultDataModel : CqActionResultDataModel, IList<CqEssenceMessageModel>
{
    private List<CqEssenceMessageModel> storage;

    public CqGetEssenceMessageListActionResultDataModel()
    {
        storage = [];
    }

    public CqGetEssenceMessageListActionResultDataModel(int capacity)
    {
        storage = new List<CqEssenceMessageModel>(capacity);
    }


    public CqGetEssenceMessageListActionResultDataModel(IEnumerable<CqEssenceMessageModel> collection)
    {
        storage = new List<CqEssenceMessageModel>(collection);
    }


    public CqEssenceMessageModel this[int index] { get => storage[index]; set => storage[index] = value; }

    public int Count => storage.Count;

    public bool IsReadOnly => false;

    public void Add(CqEssenceMessageModel item) => storage.Add(item);
    public void Clear() => storage.Clear();
    public bool Contains(CqEssenceMessageModel item) => storage.Contains(item);
    public void CopyTo(CqEssenceMessageModel[] array, int arrayIndex) => storage.CopyTo(array, arrayIndex);
    public IEnumerator<CqEssenceMessageModel> GetEnumerator() => storage.GetEnumerator();
    public int IndexOf(CqEssenceMessageModel item) => storage.IndexOf(item);
    public void Insert(int index, CqEssenceMessageModel item) => storage.Insert(index, item);
    public bool Remove(CqEssenceMessageModel item) => storage.Remove(item);
    public void RemoveAt(int index) => storage.RemoveAt(index);
    IEnumerator IEnumerable.GetEnumerator() => storage.GetEnumerator();
}
