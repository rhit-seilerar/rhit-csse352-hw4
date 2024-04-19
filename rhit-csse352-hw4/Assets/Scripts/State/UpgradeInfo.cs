using System.Collections.Generic;
using System.Text;

public class UpgradeInfo : HoverInfo
{
    readonly PurchaseInfo purchaseInfo;
    readonly List<GameModifier> modifiers;

    public UpgradeInfo(string title, string text, PurchaseInfo purchaseInfo, List<GameModifier> modifiers) : base(title, text)
    {
        this.purchaseInfo = purchaseInfo;
        this.modifiers = modifiers;
    }

    public PurchaseInfo GetPurchaseInfo() => purchaseInfo;

    public override string GetText()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.GetText());
        builder.Append("Cost: ");
        builder.AppendLine(purchaseInfo.ToString());
        foreach (var modifier in modifiers)
            builder.AppendLine(modifier.ToString());
        return builder.ToString();
    }
}
