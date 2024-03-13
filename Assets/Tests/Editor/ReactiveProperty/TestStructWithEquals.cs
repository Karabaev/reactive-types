namespace com.karabaev.reactivetypes.editor.tests.ReactiveProperty
{
  public class TestStructWithEquals
  {
    public float Float;
    public object? Object;

    public override bool Equals(object obj)
    {
      if(obj is not TestStructWithEquals other)
        return false;
      
      return Float.Equals(other.Float) && Equals(Object, other.Object);
    }
  }
}