using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDisplay : Hoverable
{
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;
    UpgradeInfo info;
    
    public void Init(UpgradeInfo info, string textureName)
    {
        this.info = info;
        text.text = $"{info.GetTitle()}\nCost: {info.GetPurchaseInfo()}";
        image.sprite = Sprite.Create(Resources.Load<Texture2D>(textureName), image.sprite.rect, image.sprite.pivot, image.sprite.pixelsPerUnit);
    }

    protected override void OnUpdate()
    {
        GetComponent<Button>().enabled = GameManager.Instance.GetMoney() >= info.GetPurchaseInfo().GetMoneyCost()
            && GameManager.Instance.GetObsidian() >= info.GetPurchaseInfo().GetObsidianCost();
    }

    public void OnClick() => GameEventBus.Instance.Publish(GameEventBus.Type.UpgradePurchased, info);
    public override HoverInfo GetHoverInfo() => info;
    protected override void OnStart() { }
    protected override void OnStop() { }
}
