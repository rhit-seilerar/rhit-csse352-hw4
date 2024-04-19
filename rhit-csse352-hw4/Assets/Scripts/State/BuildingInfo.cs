using System.Collections.Generic;

public class BuildingInfo : ModifierPurchaseInfo
{
    public readonly float obsidian;
    public BuildingInfo(string title, string text, PurchaseInfo purchaseInfo, ICollection<IGameModifier> modifiers, float obsidian) : base(title, text, purchaseInfo, modifiers) {
        this.obsidian = obsidian;
    }
}
