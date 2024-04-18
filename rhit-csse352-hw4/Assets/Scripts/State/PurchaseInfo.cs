using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PurchaseInfo
{
    readonly float moneyCost;
    readonly int obsidianCost;
    readonly string text;

    public PurchaseInfo(float moneyCost, int obsidianCost)
    {
        this.moneyCost = moneyCost;
        this.obsidianCost = obsidianCost;

        var hasMoneyCost = moneyCost != 0;
        var hasObsidianCost = obsidianCost != 0;
        if (!hasMoneyCost && !hasObsidianCost)
        {
            this.text = "<color=#00FF22><i>Free!</i></color>";
        }
        else
        {
            var builder = new StringBuilder();
            if (hasMoneyCost)
            {
                builder.AppendFormat("<color=#28FFD3>${0}</color>", moneyCost);
                if (obsidianCost != 0)
                    builder.Append(", ");
            }
            if (obsidianCost != 0)
                builder.AppendFormat("<color=#372648>{0}pc</color>", obsidianCost);
            this.text = builder.ToString();
        }
    }

    public float GetMoneyCost() => moneyCost;
    public int GetObsidianCost() => obsidianCost;
    public override string ToString() => text;
}
