using System.Collections.Generic;

public class UpgradeManager : PurchasableManager<UpgradeDisplay, UpgradeInfo>
{
    private static readonly ICollection<UpgradeInfo> infos = new List<UpgradeInfo>
    {
        new UpgradeInfo("Side Business",
            "What the IRS don't know won't hurt them...",
            new PurchaseInfo(0, 1), new List<IGameModifier>{ new IncomeModifier(5f) }),
        new UpgradeInfo("Streamlined Operations",
            "Grease in the wheels of commerce.",
            new PurchaseInfo(50, 3), new List<IGameModifier>{ new MoneyModifier(0.25f) }),
        new UpgradeInfo("Reinforced Safes",
            "Advanced technology to withstand the lava... Once. Not human-rated.",
            new PurchaseInfo(100, 1), new List<IGameModifier>{ new RetentionModifier(100f) }),
        new UpgradeInfo("Hardened Drills",
            "You get what you pay for.",
            new PurchaseInfo(1000, 0), new List<IGameModifier>{ new MiningModifier(0.5f)}),
        new UpgradeInfo("Chemical Etching",
            "More extraction with advanced chemical processes. Don't forget your HAZMAT suit.",
            new PurchaseInfo(2000, 10), new List<IGameModifier>{ new DrillingModifier(0.5f)}),
        new UpgradeInfo("Extended Safes",
            "Even more gifts for your future self.",
            new PurchaseInfo(1000, 20), new List<IGameModifier>{ new RetentionModifier(500f)}),
        new UpgradeInfo("Investment Portfolio",
            "More dollars for your dollar.",
            new PurchaseInfo(1000, 50), new List<IGameModifier>{ new MoneyModifier(1.0f)}),
        new UpgradeInfo("Advanced Mining Techniques",
            "Please don't ask what it's doing to the local ecology.",
            new PurchaseInfo(2000, 100), new List<IGameModifier>{ new MiningModifier(1f)}),
        new UpgradeInfo("Optimized Processing Lines",
            "The factory must grow!",
            new PurchaseInfo(4000, 200), new List<IGameModifier>{
                new MoneyModifier(0.75f),
                new MiningModifier(1f)
            }),
        new UpgradeInfo("The Glass Floor",
            $"Seal the volcano with a layer of obsidian.\n<color={GameManager.DANGER_COLOR}><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(10000, 1000), new List<IGameModifier>{ new GameEndModifier() }),
        new UpgradeInfo("The Glass Floor [DEBUG]",
            $"Seal the volcano with a layer of obsidian.\n<color={GameManager.DANGER_COLOR}><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(0, 0), new List<IGameModifier>{ new GameEndModifier() }),
    };

    protected override ICollection<UpgradeInfo> GetInfos() => infos;

    protected override string GetName(int index) => $"Upgrade{index}";
}
