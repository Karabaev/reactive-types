using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace com.karabaev.reactivetypes.Dictionary
{
  [PublicAPI]
  public class ReactiveDictionary<TKey, TValue> : IReadOnlyReactiveDictionary<TKey, TValue>, IWriteOnlyReactiveDictionary<TKey, TValue> 
    where TValue : IEquatable<TValue?>?
  {
    private readonly Dictionary<TKey, TValue> _dictionary;

    public event IReadOnlyReactiveDictionary<TKey, TValue>.ItemAddedHandler? ItemAdded;

    public event IReadOnlyReactiveDictionary<TKey, TValue>.ItemChangedHandler? ItemChanged;
    
    public event IReadOnlyReactiveDictionary<TKey, TValue>.ItemRemovedHandler? ItemRemoved;
    
    public event IReadOnlyReactiveDictionary<TKey, TValue>.DictionaryCleanedHandler? Cleaned;

    public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

    public TValue Require(TKey key) => _dictionary[key];

    public TValue? Get(TKey key)
    {
      _dictionary.TryGetValue(key, out var result);
      return result;
    }

    public bool TryGet(TKey key, out TValue result) => _dictionary.TryGetValue(key, out result);

    public void Add(TKey key, TValue value)
    {
      if(_dictionary.ContainsKey(key))
        throw new ArgumentOutOfRangeException(nameof(key), $"Entry with the same key there is in the dictionary. Key={key}");
      
      _dictionary.Add(key, value);
      ItemAdded?.Invoke(key, value);
    }

    public void Remove(TKey key)
    {
      if(!_dictionary.Remove(key, out var removed))
        return;
      
      ItemRemoved?.Invoke(key, removed);
    }

    public void Replace(TKey key, TValue newValue)
    {
      ReplaceInternal(key, newValue, out var oldValue);
      ItemChanged?.Invoke(key, oldValue, newValue);
    }

    public void AddOrReplace(TKey key, TValue value)
    {
      if(_dictionary.ContainsKey(key))
      {
        Replace(key, value);
      }
      else
      {
        Add(key, value);
      }
    }

    public void ReplaceWithoutNotify(TKey key, TValue newValue) => ReplaceInternal(key, newValue, out _);

    public void Clear()
    {
      _dictionary.Clear();
      Cleaned?.Invoke();
    }

    private void ReplaceInternal(TKey key, TValue newValue, out TValue oldValue)
    {
      if(!_dictionary.TryGetValue(key, out oldValue))
        throw new ArgumentOutOfRangeException(nameof(key), $"There is no entry with specified key. Key={key}");

      if(newValue == null && oldValue == null)
        return;

      if(newValue != null && newValue.Equals(oldValue))
        return;

      _dictionary[key] = newValue;
    }

    IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Dictionary<TKey, TValue>.Enumerator GetEnumerator() => _dictionary.GetEnumerator();

    public ReactiveDictionary() => _dictionary = new();

    public ReactiveDictionary(Dictionary<TKey, TValue> dictionary) => _dictionary = dictionary;
  }
}