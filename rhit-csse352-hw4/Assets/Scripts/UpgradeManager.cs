using System.Collections.Generic;

public class UpgradeManager : PurchasableManager<UpgradeDisplay, UpgradeInfo>
{
    private static readonly ICollection<UpgradeInfo> infos = new List<UpgradeInfo>
    {
        new UpgradeInfo("Streamlined Operations",
            $"Produce more money from all sources",
            new PurchaseInfo(0, 1), new List<IGameModifier>{ new MoneyModifier(0.5f)}),
        new UpgradeInfo("The Glass Floor",
            $"Seal the volcano with a layer of obsidian.\n<color={GameManager.DANGER_COLOR}><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(0, 0), new List<IGameModifier>{ new GameEndModifier() }),
    };

    protected override ICollection<UpgradeInfo> GetInfos() => infos;

    protected override string GetName(int index) => $"Upgrade{index}";
}
