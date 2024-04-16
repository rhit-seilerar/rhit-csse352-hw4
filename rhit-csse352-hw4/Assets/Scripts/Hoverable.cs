using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hoverable : UIUpdatable
{
    void OnMouseEnter()
        => UIEventBus.Instance.Publish(UIEventBus.Type.HoverStart, this);

    void OnMouseExit()
        => UIEventBus.Instance.Publish<Hoverable>(UIEventBus.Type.HoverStop, null);

    public abstract HoverInfo GetHoverInfo();
}
