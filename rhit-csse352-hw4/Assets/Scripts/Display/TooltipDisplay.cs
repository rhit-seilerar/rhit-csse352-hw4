using TMPro;
using UnityEngine;

public class TooltipDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    Hoverable hovered = null;

    public void Update()
    {
        FocusTooltip(Input.mousePosition);
    }

    public void OnHoverStart(Hoverable hoverable)
    {
        hovered = hoverable;
        var info = hoverable.GetHoverInfo();
        text.text = $"<size=32>{info.GetTitle()}</size>\n<size=20>{info.GetText()}</size>";
        gameObject.SetActive(true);
    }

    public void OnHoverEnd(Hoverable hoverable)
    {
        if (hovered == hoverable)
        {
            hovered = null;
            gameObject.SetActive(false);
        }
    }

    public void FocusTooltip(Vector2 position)
    {
        var tooltipRect = GetComponent<RectTransform>();
        tooltipRect.anchoredPosition = new Vector2(
            position.x - Screen.width / 2,
            position.y - Screen.height / 2);
        tooltipRect.pivot = new Vector2(
            tooltipRect.anchoredPosition.x < 0 ? 0 : 1,
            tooltipRect.anchoredPosition.y < 0 ? 0 : 1);
    }
}
