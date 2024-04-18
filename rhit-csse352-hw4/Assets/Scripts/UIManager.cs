using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] LoopEndDisplay loopEndDisplay;
    [SerializeField] TooltipDisplay tooltipDisplay;

    void Start()
    {
        GameEventBus.Instance.Publish(GameEventBus.Type.Start);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, OnStop);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStart, OnHoverStart);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
    }

    void Update()
    {
        GameEventBus.Instance.Publish(GameEventBus.Type.Update);
    }

    void OnStart()
    {
        loopEndDisplay.gameObject.SetActive(false);
    }

    void OnStop()
    {
        loopEndDisplay.gameObject.SetActive(true);
    }

    void OnHoverStart(Hoverable hoverable)
    {
        Debug.Log($"Hover start: {hoverable}");
        tooltipDisplay.OnHoverStart(hoverable);
    }

    void OnHoverStop(Hoverable hoverable)
    {
        Debug.Log($"Hover stop: {hoverable}");
        tooltipDisplay.OnHoverEnd(hoverable);
    }
}
