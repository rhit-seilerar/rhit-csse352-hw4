using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDisplay : Hoverable
{
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text count;
    [SerializeField] Image image;
    BuildingInfo info;

    public void Init(BuildingInfo info, string textureName)
    {
        this.info = info;
        image.sprite = Sprite.Create(Resources.Load<Texture2D>(textureName), image.sprite.rect, image.sprite.pivot, image.sprite.pixelsPerUnit);
    }

    protected override void OnUpdate()
    {
        var purchaseCount = GameManager.Instance.GetPurchaseCount(info);
        count.text = purchaseCount.ToString();
        text.text = $"{info.GetTitle()}\n<size=20>Cost: {info.GetPurchaseInfo()}</size>";
        GetComponent<Button>().interactable = purchaseCount < 9999
            && GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost(purchaseCount)
            && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost(purchaseCount);
    }

    public void OnClick() => GameEventBus.Instance.Publish(GameEventBus.Type.BuildingPurchased, info);
    public override HoverInfo GetHoverInfo() => info;
    protected override void OnStart() { }
    protected override void OnStop() { }

}
