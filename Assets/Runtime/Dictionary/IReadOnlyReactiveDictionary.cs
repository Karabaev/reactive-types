using System.Collections.Generic;

namespace com.karabaev.reactivetypes.Dictionary
{
  public interface IReadOnlyReactiveDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
  {
    public delegate void ItemAddedHandler(TKey key, TValue newValue);

    public delegate void ItemChangedHandler(TKey key, TValue oldValue, TValue newValue);

    public delegate void ItemRemovedHandler(TKey key, TValue oldValue);
    
    public delegate void DictionaryCleanedHandler();
    
    event ItemAddedHandler? ItemAdded;

    event ItemChangedHandler? ItemChanged;
    
    event ItemRemovedHandler? ItemRemoved;
    
    event DictionaryCleanedHandler? Cleaned;
    
    TValue Require(TKey key);

    TValue? Get(TKey key);

    new Dictionary<TKey, TValue>.Enumerator GetEnumerator();
  }
}