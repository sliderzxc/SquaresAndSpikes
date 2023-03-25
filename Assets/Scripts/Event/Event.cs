using System.Collections.Generic;
using System.Collections;

public class Event<T>
{
    private List<IEventListener<T>> listeners = new List<IEventListener<T>>();

    public void Invoke(T value)
    {
        foreach (var listener in listeners)
        {
            listener.OnNotify(value);
        }
    }

    public void AddListener(IEventListener<T> listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}