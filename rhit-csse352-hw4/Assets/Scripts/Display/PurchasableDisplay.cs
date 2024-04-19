using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PurchasableDisplay<T> : Hoverable where T : ModifierPurchaseInfo
{
    [SerializeField] protected TMP_Text title;
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected TMP_Text count;
    [SerializeField] protected Image image;
    protected T info;

    public void Init(T info, string textureName)
    {
        this.info = info;
        title.text = info.GetTitle();
        image.sprite = Sprite.Create(Resources.Load<Texture2D>(textureName), image.sprite.rect, image.sprite.pivot, image.sprite.pixelsPerUnit);
    }

    public override HoverInfo GetHoverInfo() => info;
    protected override void OnStart() { }
    protected override void OnStop() { }
}
