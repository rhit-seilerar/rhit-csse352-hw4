using System.Text;
using UnityEngine;

public class PurchaseInfo
{
    private float moneyCost;
    private float obsidianCost;
    private float moneyScaling;
    private float obsidianRamp;
    private string text;


    public void UpdateText(int buyCount = 0) {
        var hasMoneyCost = GetMoneyCost(buyCount) != 0;
        var hasObsidianCost = GetObsidianCost(buyCount) != 0;
        if (!hasMoneyCost && !hasObsidianCost)
        {
            this.text = $"<color={GameManager.HAPPY_COLOR}><i>Free!</i></color>";
        }
        else
        {
            var builder = new StringBuilder();
            if (hasMoneyCost)
            {
                builder.Append($"<color={GameManager.MONEY_COLOR}>${GetMoneyCost(buyCount):n2}</color>");
                if (obsidianCost != 0)
                    builder.Append(", ");
            }
            if (obsidianCost != 0)
                builder.Append($"<color={GameManager.OBSIDIAN_COLOR}>{GetObsidianCost(buyCount):n0}pc</color>");
            this.text = builder.ToString();
        }
    }

    public PurchaseInfo(float moneyCost, int obsidianCost, float moneyScaling = 1f, float obsidianRamp = 0f)
    {
        this.moneyCost = moneyCost;
        this.obsidianCost = obsidianCost;
        this.moneyScaling = moneyScaling;
        this.obsidianRamp = obsidianRamp;
        UpdateText();
    }

    public float GetMoneyCost(int buyCount = 0) => moneyCost * Mathf.Pow(moneyScaling, buyCount);
    public int GetObsidianCost(int buyCount = 0) => (int) Mathf.Floor(obsidianCost + obsidianRamp * buyCount);
    public override string ToString() => text;
}
