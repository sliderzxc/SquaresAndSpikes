public interface IEventListener<T>
{
    void OnNotify(T value);
}