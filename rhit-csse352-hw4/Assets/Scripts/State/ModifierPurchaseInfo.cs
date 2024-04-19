using System.Collections.Generic;
using System.Text;

public class ModifierPurchaseInfo: HoverInfo
{
    readonly PurchaseInfo purchaseInfo;
    readonly ICollection<IGameModifier> modifiers;

    public ModifierPurchaseInfo(string title, string text, PurchaseInfo purchaseInfo, ICollection<IGameModifier> modifiers) : base(title, text)
    {
        this.purchaseInfo = purchaseInfo;
        this.modifiers = modifiers;
    }

    public PurchaseInfo GetPurchaseInfo() => purchaseInfo;
    public ICollection<IGameModifier> GetModifiers() => modifiers;

    public override string GetText()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.GetText());
        builder.Append($"<color={GameManager.DEEMPHASIS_COLOR}>Cost: </color>");
        builder.AppendLine(purchaseInfo.ToString());
        foreach (var modifier in modifiers)
            builder.AppendLine(modifier.ToString());
        return builder.ToString();
    }
}
