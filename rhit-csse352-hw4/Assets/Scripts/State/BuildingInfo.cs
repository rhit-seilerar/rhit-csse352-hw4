using System.Collections.Generic;
using System.Text;

public class BuildingInfo : HoverInfo
{
    readonly PurchaseInfo purchaseInfo;
    readonly List<GameModifier> modifiers;

    public BuildingInfo(string title, string text, PurchaseInfo purchaseInfo, List<GameModifier> modifiers) : base(title, text)
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
        builder.Append(purchaseInfo.ToString());
        foreach (var modifier in modifiers)
            builder.AppendLine(modifier.ToString());
        return builder.ToString();
    }
}
