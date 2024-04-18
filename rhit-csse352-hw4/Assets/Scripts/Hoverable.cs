using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Hoverable : UIUpdatable, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
        => UIEventBus.Instance.Publish(UIEventBus.Type.HoverStart, this);

    public void OnPointerExit(PointerEventData eventData)
        => UIEventBus.Instance.Publish(UIEventBus.Type.HoverStop, this);

    public abstract HoverInfo GetHoverInfo();
}
