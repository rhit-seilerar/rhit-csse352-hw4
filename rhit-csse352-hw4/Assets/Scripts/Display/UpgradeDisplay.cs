using UnityEngine.UI;

public class UpgradeDisplay : PurchasableDisplay<UpgradeInfo>
{
    protected override void OnUpdate()
    {
        text.text = info.GetPurchaseInfo().ToString();
        GetComponent<Button>().interactable = !GameManager.Instance.IsPurchased(info)
            && GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost()
            && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost();
    }

    public void OnClick() => GameEventBus.Instance.Publish(GameEventBus.Type.UpgradePurchased, info);
}
