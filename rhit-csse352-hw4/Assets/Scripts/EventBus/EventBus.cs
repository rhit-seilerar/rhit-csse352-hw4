using System.Collections.Generic;
using UnityEngine.Events;

public class EventBus<T> : MonoSingleton<EventBus<T>>
{
    private IDictionary<T, dynamic> events = new Dictionary<T, dynamic>();

    public void Publish(T eventType)
        => GetOrAddEvent(eventType).Invoke();

    public void Publish<R>(T eventType, R value)
        => GetOrAddEvent<R>(eventType).Invoke(value);

    public void Subscribe(T eventType, UnityAction listener)
        => GetOrAddEvent(eventType).AddListener(listener);

    public void Subscribe<R>(T eventType, UnityAction<R> listener)
        => GetOrAddEvent<R>(eventType).AddListener(listener);

    public void Unsubscribe(T eventType, UnityAction listener)
    {
        dynamic _event;
        if (events.TryGetValue(eventType, out _event))
            _event.RemoveListener(listener);
    }

    public void Unsubscribe<R>(T eventType, UnityAction<R> listener)
    {
        dynamic _event;
        if (events.TryGetValue(eventType, out _event))
            _event.RemoveListener(listener);
    }

    private UnityEvent GetOrAddEvent(T eventType)
    {
        dynamic _event;
        if (!events.TryGetValue(eventType, out _event))
        {
            _event = new UnityEvent();
            events.Add(eventType, _event);
        }
        return _event;
    }

    private UnityEvent<R> GetOrAddEvent<R>(T eventType)
    {
        dynamic _event;
        if (!events.TryGetValue(eventType, out _event))
        {
            _event = new UnityEvent<R>();
            events.Add(eventType, _event);
        }
        return _event;
    }
}
