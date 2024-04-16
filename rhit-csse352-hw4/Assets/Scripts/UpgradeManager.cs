using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : UIUpdatable
{
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
