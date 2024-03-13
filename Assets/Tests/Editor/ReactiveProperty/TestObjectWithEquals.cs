using System;

namespace com.karabaev.reactivetypes.editor.tests.ReactiveProperty
{
  public class TestClassWithEquals
  {
    public float Float;
    public object? Object;

    public bool Equals(TestClassWithEquals? other)
    {
      if(ReferenceEquals(null, other))
        return false;
      if(ReferenceEquals(this, other))
        return true;
      return Float.Equals(other.Float) && Equals(Object, other.Object);
    }

    public override bool Equals(object? obj)
    {
      if(ReferenceEquals(null, obj))
        return false;
      if(ReferenceEquals(this, obj))
        return true;
      if(obj.GetType() != this.GetType())
        return false;
      return Equals((TestClassWithEquals)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Float, Object);
  }
}