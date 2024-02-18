using System;
using System.Collections.Generic;

namespace com.karabaev.reactivetypes.Collection
{
  public interface IWriteOnlyReactiveCollection<TItem>
  {
    void Add(TItem item);

    void AddRange(IReadOnlyList<TItem> items);

    void Remove(TItem item);

    void RemoveAt(int index);
    
    void Remove(Predicate<TItem> predicate);

    void Reinitialize(IEnumerable<TItem> items);

    void Clear();
    
    TItem this[int index]
    {
      set;
    }
  }
}