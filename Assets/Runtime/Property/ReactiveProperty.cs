using JetBrains.Annotations;

namespace com.karabaev.reactivetypes.Property
{
  [PublicAPI]
  public class ReactiveProperty<T> : IReadOnlyReactiveProperty<T>, IWriteOnlyReactiveProperty<T>
  {
    private T _value;

    public event IReadOnlyReactiveProperty<T>.ValueChangedHandler? Changed;

    public T Value
    {
      get => _value;
      set
      {
        if(value == null && _value == null)
          return;
        
        if(value != null && value.Equals(_value))
          return;
        
        var oldValue = _value;
        _value = value;
        Changed?.Invoke(oldValue, _value);
      }
    }

    public void SetValueWithoutNotify(T value) => _value = value;

    public ReactiveProperty(T value) => _value = value;
  }
}