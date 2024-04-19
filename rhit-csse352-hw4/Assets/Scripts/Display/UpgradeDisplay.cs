using UnityEngine.UI;

public class UpgradeDisplay : PurchasableDisplay<UpgradeInfo>
{
    protected override void OnUpdate()
    {
        GetComponent<Button>().interactable = !GameManager.Instance.IsPurchased(info)
            && GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost()
            && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost();
    }

    public void OnClick() => GameEventBus.Instance.Publish(GameEventBus.Type.UpgradePurchased, info);
}
