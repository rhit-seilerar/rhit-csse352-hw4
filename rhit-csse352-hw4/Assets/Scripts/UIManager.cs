using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : GameUpdatable
{
    [SerializeField] LoopEndDisplay loopEndDisplay;
    [SerializeField] TooltipDisplay tooltipDisplay;

    protected override void Start()
    {
        base.Start();
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStart, OnHoverStart);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
    }

    protected override void OnStart()
    {
        loopEndDisplay.gameObject.SetActive(false);
    }

    protected override void OnStop()
    {
        loopEndDisplay.gameObject.SetActive(true);
    }

    void OnHoverStart(Hoverable hoverable)
    {
        tooltipDisplay.OnHoverStart(hoverable);
    }

    void OnHoverStop(Hoverable hoverable)
    {
        tooltipDisplay.OnHoverEnd(hoverable);
    }

    protected override void OnUpdate() { }
}
