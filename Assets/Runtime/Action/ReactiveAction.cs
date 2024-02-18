namespace com.karabaev.reactivetypes.Action
{
  public class ReactiveAction : ISubscribeOnlyAction, IInvokeOnlyAction
  {
    public event System.Action? Invoked;

    public void Invoke() => Invoked?.Invoke();

    public ReactiveAction(System.Action action) => Invoked += action;
    
    public ReactiveAction() { }
  }

  public class ReactiveAction<T> : ISubscribeOnlyAction<T>, IInvokeOnlyAction<T>
  {
    public event System.Action<T>? Invoked;

    public void Invoke(T value) => Invoked?.Invoke(value);
    
    public ReactiveAction(System.Action<T> action) => Invoked += action;
    
    public ReactiveAction() { }
  }
  
  public class ReactiveAction<T1, T2> : ISubscribeOnlyAction<T1, T2>, IInvokeOnlyAction<T1, T2>
  {
    public event System.Action<T1, T2>? Invoked;

    public void Invoke(T1 value1, T2 value2) => Invoked?.Invoke(value1, value2);
    
    public ReactiveAction(System.Action<T1, T2> action) => Invoked += action;
    
    public ReactiveAction() { }
  }
}