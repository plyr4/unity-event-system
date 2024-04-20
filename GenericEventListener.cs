using System;
using UnityEngine;
using UnityEngine.Events;

public class GenericEventOpts
{
    // add fields here
    public StateBase _newState;
}

[Serializable]
public class UnityEventGeneric : UnityEvent<GenericEventOpts>
{
}

public class GenericEventListener : GameEventListenerBase
{
    [SerializeField]
    protected UnityEventGeneric _unityEventGeneric;

    public void RaiseEvent(GenericEventOpts opts)
    {
        _unityEvent?.Invoke();
        _unityEventGeneric?.Invoke(opts);
    }
}