using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : GameUpdatable
{
    [SerializeField] TooltipDisplay tooltipDisplay;
    [SerializeField] LoopEndDisplay loopEndDisplay;
    [SerializeField] GameEndDisplay gameEndDisplay;

    protected override void Start()
    {
        base.Start();
        GameEventBus.Instance.Subscribe(GameEventBus.Type.End, OnEnd);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStart, OnHoverStart);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
    }

    protected override void OnStart()
    {
        loopEndDisplay.gameObject.SetActive(false);
    }

    protected override void OnStop()
    {
        if (GameManager.Instance.GetRunningState() == GameManager.RunningState.STOPPED)
            loopEndDisplay.gameObject.SetActive(true);
    }

    void OnEnd()
    {
        gameEndDisplay.gameObject.SetActive(true);
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
