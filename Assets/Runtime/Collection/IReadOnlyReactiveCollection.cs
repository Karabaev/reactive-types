using System.Collections.Generic;

namespace com.karabaev.reactivetypes.Collection
{
  public interface IReadOnlyReactiveCollection<TItem> : IEnumerable<TItem>
  {
    public delegate void ItemAddedHandler(TItem newItem, int index);
    public delegate void ItemsAddedHandler(IEnumerable<TItem> newItems, int startingIndex);
    public delegate void ItemRemovedHandler(TItem oldItem, int index);
    public delegate void ItemReplacedHandler(TItem oldItem, TItem newItem, int index);
    public delegate void CollectionReinitializedHandler();
    public delegate void CollectionCleanedHandler();
    
    event ItemAddedHandler? ItemAdded;
    event ItemsAddedHandler? ItemsAdded;
    event ItemRemovedHandler? ItemRemoved;
    event ItemReplacedHandler? ItemReplaced;
    event CollectionReinitializedHandler? Reinitialized;
    event CollectionCleanedHandler? Cleaned;
    
    IReadOnlyList<TItem> Collection { get; }
    
    int Count { get; }
    
    bool IsEmpty { get; }

    bool Contains(TItem item);

    TItem this[int index]
    {
      get;
    }
  }
}