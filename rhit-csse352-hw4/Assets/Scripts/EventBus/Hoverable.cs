using UnityEngine.EventSystems;

public abstract class Hoverable : GameUpdatable, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
        => GameEventBus.Instance.Publish(GameEventBus.Type.HoverStart, this);

    public void OnPointerExit(PointerEventData eventData)
        => GameEventBus.Instance.Publish(GameEventBus.Type.HoverStop, this);

    public abstract HoverInfo GetHoverInfo();
}
