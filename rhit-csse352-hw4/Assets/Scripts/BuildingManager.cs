using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : GameUpdatable
{
    private static readonly List<BuildingInfo> buildingInfos = new List<BuildingInfo>()
    {
        new BuildingInfo("Collectible Rocks",
                "You found some cat-shaped pumice. Or should I say, <i>paw</i>-mice.",
                new PurchaseInfo(1, 0), new List<IGameModifier>{ new IncomeModifier(0.1f) }),
        new BuildingInfo("Lava Tours",            "<i>Only 3 casualties per week!</i>",
                new PurchaseInfo(5, 0), new List<IGameModifier>{ new IncomeModifier(0.5f) }),
        new BuildingInfo("Basaltic Sculptures",   "The number of poses is innumerable.",
                new PurchaseInfo(10, 0), new List<IGameModifier>{ new IncomeModifier(1.5f) }),
        new BuildingInfo("Geothermal Generators", "Gotta keep the lights on somehow.",
                new PurchaseInfo(20, 1), new List<IGameModifier>{ new IncomeModifier(10f) }),
        new BuildingInfo("Mineral Extractors",    "<i>Shiny!</i>",
                new PurchaseInfo(100, 20), new List<IGameModifier>{ new ObsidianModifier(1f) }),
    };

    [SerializeField] GameObject buildingPrefab;
    List<GameObject> buildings = new List<GameObject>();

    protected override void OnStart()
    {
        foreach (var building in buildings)
            Destroy(building);
        buildings.Clear();
        for (int i = 0; i < buildingInfos.Count; i++)
        {
            GameObject building = Instantiate(buildingPrefab);
            buildings.Add(building);
            building.name = $"Building{i}";
            building.transform.SetParent(transform);
            building.GetComponent<BuildingDisplay>().Init(buildingInfos[i], building.name);
        }
    }

    protected override void OnStop() { }
    protected override void OnUpdate() { }
}
