using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUpdatable : MonoBehaviour
{
    protected virtual void Start()
    {
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Update, OnUpdate);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, OnStop);
    }

    protected void UnsubscribeFromUpdates()
    {
        GameEventBus.Instance.Unsubscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Unsubscribe(GameEventBus.Type.Update, OnUpdate);
        GameEventBus.Instance.Unsubscribe(GameEventBus.Type.Stop, OnStop);
    }

    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract void OnStop();
}
