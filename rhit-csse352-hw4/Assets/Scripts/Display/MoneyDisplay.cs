using TMPro;

public class MoneyDisplay : GameUpdatable
{
    TMP_Text text;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
        GameEventBus.Instance.Subscribe<BuildingInfo>(GameEventBus.Type.BuildingPurchased, OnBuildingPurchased);
        GameEventBus.Instance.Subscribe<UpgradeInfo>(GameEventBus.Type.UpgradePurchased, OnUpgradePurchased);
    }

    void OnBuildingPurchased(BuildingInfo info) => OnUpdate();
    void OnUpgradePurchased(UpgradeInfo info) => OnUpdate();

    protected override void OnStart() { }

    protected override void OnUpdate()
    {
        text.text = $"<size=36>Money: </size>{GameManager.Instance.GetMoney():c1}";
    }

    protected override void OnStop() { }
}
