using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : GameUpdatable
{
    private static readonly List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>
    {
        new UpgradeInfo(
            1, 1,
            "Upgrade 0",
            "This is an upgrade!",
            new List<GameModifier>
            {
            }),
    };

    [SerializeField] GameObject upgradePrefab;
    List<GameObject> upgrades;

    protected override void Start()
    {
        base.Start();
        upgrades = new List<GameObject>();
    }

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

            var info = upgradeInfos[i];
            var image = upgrade.GetComponent<Image>();
            upgrade.GetComponent<UpgradeDisplay>().info = info;
            image.sprite = Sprite.Create(Resources.Load<Texture2D>(upgrade.name), image.sprite.rect, image.sprite.pivot, image.sprite.pixelsPerUnit);
        }
    }

    protected override void OnStop() { }
    protected override void OnUpdate() { }
}
