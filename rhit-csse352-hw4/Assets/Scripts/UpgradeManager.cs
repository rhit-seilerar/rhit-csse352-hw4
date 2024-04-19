using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : GameUpdatable
{
    private static readonly List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>
    {
        new UpgradeInfo("The Glass Floor",
            "Seal the volcano with a layer of obsidian.\n<color=red><b>Warning: This will end the game.</b></color>",
            new PurchaseInfo(0, 0), new List<IGameModifier>{ new GameEndModifier() }),
    };

    [SerializeField] GameObject upgradePrefab;
    List<GameObject> upgrades = new List<GameObject>();

    protected override void OnStart()
    {
        foreach (var upgrade in upgrades)
            Destroy(upgrade);
        upgrades.Clear();
        for (int i = 0; i < upgradeInfos.Count; i++)
        {
            GameObject upgrade = Instantiate(upgradePrefab);
            upgrades.Add(upgrade);
            upgrade.name = $"Upgrade{i}";
            upgrade.transform.SetParent(transform);
            upgrade.GetComponent<UpgradeDisplay>().Init(upgradeInfos[i], upgrade.name);
        }
    }

    protected override void OnStop() { }
    protected override void OnUpdate() { }
}
