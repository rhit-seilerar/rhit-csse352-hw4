using System.Collections.Generic;

public class UpgradeManager : PurchasableManager<UpgradeDisplay, UpgradeInfo>
{
    private static readonly ICollection<UpgradeInfo> infos = new List<UpgradeInfo>
    {
        new UpgradeInfo("Side Business",
            "What the IRS don't know won't hurt them...",
            new PurchaseInfo(0, 1), new List<IGameModifier>{ new IncomeModifier(5f) }),
        new UpgradeInfo("Reinforced Safes",
            "Advanced technology to withstand the lava... Once. Not human-rated.",
            new PurchaseInfo(50, 1), new List<IGameModifier>{ new RetentionModifier(100f) }),
        new UpgradeInfo("Streamlined Operations",
            "Grease in the wheels of commerce.",
            new PurchaseInfo(50, 3), new List<IGameModifier>{ new MoneyModifier(0.25f) }),
        new UpgradeInfo("Hardened Drills",
            "You get what you pay for.",
            new PurchaseInfo(1000, 0), new List<IGameModifier>{ new MiningModifier(0.5f)}),
        new UpgradeInfo("The Glass Floor [DEBUG]",
            $"Seal the volcano with a layer of obsidian.\n<color={GameManager.DANGER_COLOR}><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(0, 0), new List<IGameModifier>{ new GameEndModifier() }),
        new UpgradeInfo("The Glass Floor",
            $"Seal the volcano with a layer of obsidian.\n<color={GameManager.DANGER_COLOR}><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(10000, 1000), new List<IGameModifier>{ new GameEndModifier() }),
    };

    protected override ICollection<UpgradeInfo> GetInfos() => infos;

    protected override string GetName(int index) => $"Upgrade{index}";
}
