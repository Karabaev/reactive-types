using System.Collections.Generic;
using JetBrains.Annotations;

namespace com.karabaev.reactivetypes.Property
{
  [PublicAPI]
  public class ReactiveProperty<TValue> : IReadOnlyReactiveProperty<TValue>, IWriteOnlyReactiveProperty<TValue>
  {
    private TValue _value;

    public event IReadOnlyReactiveProperty<TValue>.ValueChangedHandler? Changed;

    public TValue Value
    {
      get => _value;
      set
      {
        if(EqualityComparer<TValue?>.Default.Equals(value, _value))
          return;

        var oldValue = _value;
        _value = value;
        Changed?.Invoke(oldValue, _value);
      }
    }

    public void SetValueWithoutNotify(TValue value) => _value = value;

    public ReactiveProperty(TValue value) => _value = value;
  }
}