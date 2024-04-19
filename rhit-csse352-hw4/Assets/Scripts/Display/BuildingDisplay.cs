using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingDisplay : PurchasableDisplay<BuildingInfo>, IPointerDownHandler
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

    public void OnClick() => Purchase(1);

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            Purchase(10);
    }

    void Purchase(int count)
    {
        var purchaseCount = GameManager.Instance.GetPurchaseCount(info);
        for (int i = 0; i < count; i++)
        {
            if (purchaseCount + i < 9999
                && GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost(purchaseCount + i)
                && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost(purchaseCount + i))
                GameEventBus.Instance.Publish(GameEventBus.Type.BuildingPurchased, info);
        }
    }
}
