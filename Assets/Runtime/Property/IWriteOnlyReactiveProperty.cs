namespace com.karabaev.reactivetypes.Property
{
  public interface IWriteOnlyReactiveProperty<in T>
  {
    T Value { set; }

    void SetValueWithoutNotify(T value);
  }
}