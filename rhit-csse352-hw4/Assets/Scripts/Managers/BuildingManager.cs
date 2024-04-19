using System.Collections.Generic;

public class BuildingManager : PurchasableManager<BuildingDisplay, BuildingInfo>
{
    private static readonly ICollection<BuildingInfo> infos = new List<BuildingInfo>()
    {
        new BuildingInfo("Collectible Rocks",
                "You found some cat-shaped pumice. Or should I say, <i>paw</i>-mice.\n"
                + $"<color={GameManager.DANGER_COLOR}>Does not yield obsidian.</color>",
                new PurchaseInfo(1, 0, 1.05f, 0f), new List<IGameModifier>{ new IncomeModifier(0.1f) }, 0f),
        new BuildingInfo("Lava Tours",            "<i>Only 3 casualties per week!</i>",
                new PurchaseInfo(20, 0, 1.05f, 0f), new List<IGameModifier>{ new IncomeModifier(0.5f) }, 0.2f),
        new BuildingInfo("Basaltic Sculptures",   "The number of poses is innumerable.",
                new PurchaseInfo(80, 0, 1.1f, 0f), new List<IGameModifier>{ new IncomeModifier(2f) }, 1f),
        new BuildingInfo("Geothermal Generators", "Gotta keep the lights on somehow.",
                new PurchaseInfo(100, 1, 1.1f, 0f), new List<IGameModifier>{ new IncomeModifier(20f) }, 1f),
        new BuildingInfo("Mineral Extractors",    "<i>Shiny!</i>",
                new PurchaseInfo(500, 20, 1.5f, 10f), new List<IGameModifier>{ new ObsidianModifier(1f) }, 10f),
    };

    protected override ICollection<BuildingInfo> GetInfos() => infos;
    protected override string GetName(int index) => $"Building{index}";
}
