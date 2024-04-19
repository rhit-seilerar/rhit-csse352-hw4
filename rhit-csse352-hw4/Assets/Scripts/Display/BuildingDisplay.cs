using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDisplay : PurchasableDisplay<BuildingInfo>
{
    [SerializeField] TMP_Text count;

    protected override void OnUpdate()
    {
        var purchaseCount = GameManager.Instance.GetPurchaseCount(info);
        count.text = purchaseCount.ToString();
        text.text = info.GetPurchaseInfo().ToString();
        GetComponent<Button>().interactable = purchaseCount < 9999
            && GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost(purchaseCount)
            && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost(purchaseCount);
    }

    public void OnClick() => GameEventBus.Instance.Publish(GameEventBus.Type.BuildingPurchased, info);
}
