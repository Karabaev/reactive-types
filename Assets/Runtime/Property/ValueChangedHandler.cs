namespace com.karabaev.reactivetypes.Property
{
  public delegate void ValueChangedHandler<in T>(T oldValue, T newValue);
}