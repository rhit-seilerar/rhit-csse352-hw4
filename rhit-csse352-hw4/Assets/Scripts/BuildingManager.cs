using System.Collections.Generic;

public class BuildingManager : PurchasableManager<BuildingDisplay, BuildingInfo>
{
    private static readonly ICollection<BuildingInfo> infos = new List<BuildingInfo>()
    {
        new BuildingInfo("Collectible Rocks",
                "You found some cat-shaped pumice. Or should I say, <i>paw</i>-mice.",
                new PurchaseInfo(1, 0, 1.01f, 0f), new List<IGameModifier>{ new IncomeModifier(0.1f) }),
        new BuildingInfo("Lava Tours",            "<i>Only 3 casualties per week!</i>",
                new PurchaseInfo(5, 0, 1.02f, 0f), new List<IGameModifier>{ new IncomeModifier(0.5f) }),
        new BuildingInfo("Basaltic Sculptures",   "The number of poses is innumerable.",
                new PurchaseInfo(10, 0, 1.1f, 0f), new List<IGameModifier>{ new IncomeModifier(1.5f) }),
        new BuildingInfo("Geothermal Generators", "Gotta keep the lights on somehow.",
                new PurchaseInfo(20, 1, 1.1f, 1f), new List<IGameModifier>{ new IncomeModifier(10f) }),
        new BuildingInfo("Mineral Extractors",    "<i>Shiny!</i>",
                new PurchaseInfo(100, 20, 1.1f, 5f), new List<IGameModifier>{ new ObsidianModifier(1f) }),
    };

    protected override ICollection<BuildingInfo> GetInfos() => infos;
    protected override string GetName(int index) => $"Building{index}";
}
