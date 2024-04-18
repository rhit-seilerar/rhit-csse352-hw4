using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text text;

    public void SetInfo(HoverInfo info)
    {
        title.text = info.GetTitle();
        text.text = info.GetText();
    }
}
