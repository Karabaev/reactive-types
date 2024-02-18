namespace com.karabaev.reactivetypes.Action
{
  public interface IInvokeOnlyAction
  {
    void Invoke();
  }
  
  public interface IInvokeOnlyAction<in T>
  {
    void Invoke(T value);
  }
  
  public interface IInvokeOnlyAction<in T1, in T2>
  {
    void Invoke(T1 value1, T2 value2);
  }
}