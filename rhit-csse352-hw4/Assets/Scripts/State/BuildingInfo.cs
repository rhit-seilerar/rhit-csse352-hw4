using System.Collections.Generic;

public class BuildingInfo : ModifierPurchaseInfo
{
    public BuildingInfo(string title, string text, PurchaseInfo purchaseInfo, ICollection<IGameModifier> modifiers) : base(title, text, purchaseInfo, modifiers) { }
}
