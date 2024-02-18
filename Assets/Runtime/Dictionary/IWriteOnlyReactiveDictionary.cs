namespace com.karabaev.reactivetypes.Dictionary
{
  public interface IWriteOnlyReactiveDictionary<in TKey, in TValue>
  {
    void Add(TKey key, TValue value);

    void Remove(TKey key);
    
    void Replace(TKey key, TValue newValue);

    void ReplaceWithoutNotify(TKey key, TValue newValue);
    
    void Clear();
  }
}