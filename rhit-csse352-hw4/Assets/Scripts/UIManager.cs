using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] LoopEndHandler loopEndHandler;
    [SerializeField] TooltipManager tooltip;
    Hoverable hovered = null;

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

        if (hovered)
            FocusTooltip(Input.mousePosition);
        tooltip.gameObject.SetActive(hovered);
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
        this.hovered = hoverable;
        tooltip.SetInfo(hoverable.GetHoverInfo());
    }

    void OnHoverStop(Hoverable hoverable)
    {
        if (this.hovered == hoverable)
            this.hovered = null;
    }

    void FocusTooltip(Vector2 position)
    {
        var tooltipRect = tooltip.gameObject.GetComponent<RectTransform>();
        tooltipRect.anchoredPosition = new Vector2(
            position.x - Screen.width / 2,
            position.y - Screen.height / 2);
        tooltipRect.pivot = new Vector2(
            tooltipRect.anchoredPosition.x < 0 ? 0 : 1,
            tooltipRect.anchoredPosition.y < 0 ? 0 : 1);
    }
}
