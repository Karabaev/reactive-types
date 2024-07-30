namespace com.karabaev.reactivetypes.Property
{
  public interface IReadOnlyReactiveProperty<out T>
  {
    T Value { get; }
    
    event ValueChangedHandler<T>? Changed;
  }
}