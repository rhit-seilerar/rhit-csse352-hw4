using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : GameUpdatable
{
    private static readonly List<BuildingInfo> buildingInfos = new List<BuildingInfo>()
    {
        new BuildingInfo("Building 0", "This is a building!", new PurchaseInfo(0, 0), new List<GameModifier>{ }),
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
