using System.Collections.Generic;

public class UpgradeInfo : ModifierPurchaseInfo
{
    public UpgradeInfo(string title, string text, PurchaseInfo purchaseInfo, ICollection<IGameModifier> modifiers) : base(title, text, purchaseInfo, modifiers) { }
}
