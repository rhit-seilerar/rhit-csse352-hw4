using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoopEndDisplay : FadingDisplay
{
    [SerializeField] protected TMP_Text text;
    protected override void OnFade()
    {
        text.text = $"You earned <color={GameManager.OBSIDIAN_COLOR}>{GameManager.Instance.GetObsidianEarned()}pc</color> of <color={GameManager.OBSIDIAN_COLOR}>Obsidian</color>.";
    }
}
