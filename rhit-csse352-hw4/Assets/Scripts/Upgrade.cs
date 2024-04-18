using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Hoverable
{
    public UpgradeInfo info;

    public void OnClick()
        => UIEventBus.Instance.Publish(UIEventBus.Type.UpgradePurchased, info);

    public override HoverInfo GetHoverInfo() => info;
    protected override void OnStart() { }
    protected override void OnStop() { }
    protected override void OnUpdate() { }
}
