using System.Collections.Concurrent;
using UnityEngine;

public class GameEventBase : ScriptableObject
{
    protected ConcurrentDictionary<int, GameEventListenerBase> _listeners =
        new ConcurrentDictionary<int, GameEventListenerBase>();
    public bool _debug;

    public void Invoke()
    {
        if (_debug && Application.isPlaying)
        {
            Debug.Log($"v: Invoked GameEvent listeners: num_listeners({_listeners.Values.Count})");
        }

        foreach (var listener in _listeners)
        {
            if (_debug && Application.isPlaying)
            {
                Debug.Log($"GameEvent: RaiseEvent GameEvent listener: name({listener.Value.gameObject.name})",
                    listener.Value.gameObject);
            }

            (listener.Value as GameEventListenerBase).RaiseEvent();
        }
    }

    public void Deregister(GameEventListenerBase listener) =>
        _listeners.TryRemove(listener.gameObject.GetInstanceID(), out _);

    public void Register(GameEventListenerBase listener) =>
        _listeners.TryAdd(listener.gameObject.GetInstanceID(), listener);
}