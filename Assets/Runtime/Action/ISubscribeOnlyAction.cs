namespace com.karabaev.reactivetypes.Action
{
  public interface ISubscribeOnlyAction
  {
    event System.Action? Invoked;
  }
  
  public interface ISubscribeOnlyAction<out T>
  {
    event System.Action<T>? Invoked;
  }
  
  public interface ISubscribeOnlyAction<out T1, out T2>
  {
    event System.Action<T1, T2>? Invoked;
  }
}