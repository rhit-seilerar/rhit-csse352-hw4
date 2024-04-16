using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] LoopEndHandler loopEndHandler;

    void Start()
    {
        UIEventBus.Instance.Publish(UIEventBus.Type.Start);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Start, OnStart);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Stop, OnStop);
    }

    void Update()
    {
        UIEventBus.Instance.Publish(UIEventBus.Type.Update);
    }

    void OnStart()
    {
        loopEndHandler.gameObject.SetActive(false);
    }

    void OnStop()
    {
        loopEndHandler.gameObject.SetActive(true);
    }
}
