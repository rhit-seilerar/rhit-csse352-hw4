using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : Hoverable
{
    public UpgradeInfo info;

    public void OnClick()
        => GameEventBus.Instance.Publish(GameEventBus.Type.UpgradePurchased, info);
    
    protected override void OnUpdate()
    {
        //GetComponent<Button>().enabled = GameManager.Instance.GetMoney() >= info.GetMoneyCost()
        //    && GameManager.Instance.GetObsidian() >= info.GetObsidianCost();
    }

    public override HoverInfo GetHoverInfo() => info;
    
    protected override void OnStart() { }
    protected override void OnStop() { }
}
