using TMPro;
using UnityEngine;

public class LoopEndDisplay : FadingDisplay
{
    [SerializeField] protected TMP_Text text;

    public LoopEndDisplay() : base(1f) { }

    protected override void OnFade()
    {
        text.text = $"You earned <color={GameManager.OBSIDIAN_COLOR}>{GameManager.Instance.GetObsidianEarned()}pc</color> of <color={GameManager.OBSIDIAN_COLOR}>Obsidian</color>.";
    }
}
