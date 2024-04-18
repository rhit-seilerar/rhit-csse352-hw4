using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] LoopEndHandler loopEndHandler;
    [SerializeField] TooltipManager tooltip;

    void Start()
    {
        UIEventBus.Instance.Publish(UIEventBus.Type.Start);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Start, OnStart);
        UIEventBus.Instance.Subscribe(UIEventBus.Type.Stop, OnStop);
        UIEventBus.Instance.Subscribe<Hoverable>(UIEventBus.Type.HoverStart, OnHoverStart);
        UIEventBus.Instance.Subscribe<Hoverable>(UIEventBus.Type.HoverStop, OnHoverStop);
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

    void OnHoverStart(Hoverable hoverable)
    {
        tooltip.OnHoverStart(hoverable);
    }

    void OnHoverStop(Hoverable hoverable)
    {
        tooltip.OnHoverEnd(hoverable);
    }
}
