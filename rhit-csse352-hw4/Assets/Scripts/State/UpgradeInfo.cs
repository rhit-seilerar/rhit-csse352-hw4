using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : HoverInfo
{
    float moneyCost;
    int obsidianCost;
    List<GameModifier> modifiers;

    public UpgradeInfo(float moneyCost, int obsidianCost, string title, string text, List<GameModifier> modifiers) : base(title, text)
    {
        this.moneyCost = moneyCost;
        this.obsidianCost = obsidianCost;
        this.modifiers = modifiers;
    }

    public float GetMoneyCost() => moneyCost;
    public int GetObsidianCost() => obsidianCost;

    public override string GetText()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.GetText());
        if (moneyCost != 0 || obsidianCost != 0)
            builder.Append("Cost: ");
        if (moneyCost != 0)
            builder.AppendFormat("<color=#28FFD3>${0}</color>{1}", moneyCost, obsidianCost != 0 ? " and " : "");
        if (obsidianCost != 0)
            builder.AppendFormat("<color=#372648>{0}pc</color>", obsidianCost);
        foreach (var modifier in modifiers)
            builder.AppendLine(modifier.ToString());
        return builder.ToString();
    }
}
