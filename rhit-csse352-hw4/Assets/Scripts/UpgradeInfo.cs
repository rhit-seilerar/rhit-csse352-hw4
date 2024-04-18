using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : HoverInfo
{
    float moneyCost;
    int obsidianCost;
    string textureName;
    List<GameModifier> modifiers;

    public UpgradeInfo(float moneyCost, int obsidianCost, string title, string text, string textureName, List<GameModifier> modifiers) : base(title, text)
    {
        this.moneyCost = moneyCost;
        this.obsidianCost = obsidianCost;
        this.textureName = textureName;
        this.modifiers = modifiers;
    }

    public Texture2D GetTexture()
    {
        return Resources.Load<Texture2D>(textureName);
    }

    public override string GetText()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.GetText());
        foreach (var modifier in modifiers)
            builder.AppendLine(modifier.ToString());
        return builder.ToString();
    }
}
