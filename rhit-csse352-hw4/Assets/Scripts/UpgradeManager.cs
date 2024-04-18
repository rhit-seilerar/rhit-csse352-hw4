using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : UIUpdatable
{
    private static readonly List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>
    {
        new UpgradeInfo(
            0, 0,
            "Upgrade 0",
            "This is an upgrade!",
            "TempTexture",
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
        upgrades.Clear();
        for (int i = 0; i < 40; i++)
        {
            GameObject upgrade = Instantiate(upgradePrefab);
            upgrades.Add(upgrade);
            var info = upgradeInfos[0];
            var image = upgrade.GetComponent<Image>();
            //upgrade.GetComponent<Button>().onClick = ;
            upgrade.GetComponent<Upgrade>().info = info;
            image.sprite = Sprite.Create(info.GetTexture(), image.sprite.rect, image.sprite.pivot, image.sprite.pixelsPerUnit);
            upgrade.transform.SetParent(transform);
        }
    }

    protected override void OnStop()
    {
    }

    protected override void OnUpdate()
    {
    }
}
