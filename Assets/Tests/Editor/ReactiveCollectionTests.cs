using System.Collections.Generic;
using com.karabaev.reactivetypes.Collection;
using NUnit.Framework;

namespace com.karabaev.reactivetypes.editor.tests
{
  public class ReactiveCollectionTests
  {
    [Test]
    public void CreatedEmptyTest()
    {
      var collection = new ReactiveCollection<int>();
      Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void CreateEmptyWithSpecifiedCapacity()
    {
      var collection = new ReactiveCollection<int>(50);
      Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void CreateInitializedFromCollection()
    {
      var initialCollection = new List<int> { 0, 1, 2, 3, 4 };
      var collection = new ReactiveCollection<int>(initialCollection);
      Assert.AreEqual(initialCollection.Count, collection.Count);

      for(var i = 0; i < initialCollection.Count; i++)
        Assert.AreEqual(initialCollection[i], collection[i]);
    }
  }
}