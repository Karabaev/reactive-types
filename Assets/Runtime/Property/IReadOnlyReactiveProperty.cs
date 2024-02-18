namespace com.karabaev.reactivetypes.Property
{
  public interface IReadOnlyReactiveProperty<T>
  {
    delegate void ValueChangedHandler(T oldValue, T newValue);

    T Value { get; }
    
    event ValueChangedHandler? Changed;
  }
}