using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : GameUpdatable
{
    private static readonly List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>
    {
        new UpgradeInfo("Upgrade 0", "This is an upgrade!", new PurchaseInfo(1, 0), new List<IGameModifier>{ new MoneyModifier(1.05f) }),
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
