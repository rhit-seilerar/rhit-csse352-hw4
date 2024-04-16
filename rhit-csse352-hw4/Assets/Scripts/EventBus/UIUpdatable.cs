using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIUpdatable : MonoBehaviour
{
    protected void StartPausable()
    {
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Start, OnStart);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Update, OnUpdate);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Stop, OnStop);
    }

    protected void StopPausable()
    {
        UIEventBus.Instance.Unsubscribe(UIEventBus.Type.Start, OnStart);
        UIEventBus.Instance.Unsubscribe(UIEventBus.Type.Update, OnUpdate);
        UIEventBus.Instance.Unsubscribe(UIEventBus.Type.Stop, OnStop);
    }

    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract void OnStop();
}
