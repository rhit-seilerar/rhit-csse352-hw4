using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    enum RunningState
    {
        NOT_STARTED,
        STARTING,
        UPDATING,
        STOPPED,
    }

    RunningState state = RunningState.NOT_STARTED;
    ICollection<UpgradeInfo> purchasedUpgrades = new HashSet<UpgradeInfo>();
    IDictionary<BuildingInfo, int> purchasedBuildings = new Dictionary<BuildingInfo, int>();
    ModifierInfo modifierInfo = new ModifierInfo();
    int loops = 0;
    float money = 0;
    float obsidian = 0f;

    void Start()
    {
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, OnStop);
        GameEventBus.Instance.Subscribe<UpgradeInfo>(GameEventBus.Type.UpgradePurchased, OnUpgradePurchased);
        GameEventBus.Instance.Subscribe<BuildingInfo>(GameEventBus.Type.BuildingPurchased, OnBuildingPurchased);
    }

    void Update()
    {
        if (state == RunningState.NOT_STARTED)
        {
            state = RunningState.STARTING;
            GameEventBus.Instance.Publish(GameEventBus.Type.Start);
        }
        
        if (state == RunningState.UPDATING)
        {
            GameEventBus.Instance.Publish(GameEventBus.Type.Update);
            obsidian += Time.deltaTime * modifierInfo.obsidianRate;
            money += Time.deltaTime * modifierInfo.passiveIncome * modifierInfo.productionMultiplier;
        }
    }

    void OnStart()
    {
        obsidian += GetObsidianEarned();
        money = 0;
        state = RunningState.UPDATING;
    }

    void OnStop()
    {
        state = RunningState.STOPPED;
        loops++;
    }

    void OnUpgradePurchased(UpgradeInfo info)
    {
        if (!purchasedUpgrades.Contains(info))
        {
            purchasedUpgrades.Add(info);
            money -= info.GetPurchaseInfo().GetMoneyCost();
            obsidian -= info.GetPurchaseInfo().GetObsidianCost();
            foreach (var modifier in info.GetModifiers())
                modifier.Apply(modifierInfo);
        }
    }

    void OnBuildingPurchased(BuildingInfo info)
    {
        purchasedBuildings.Add(info, GetPurchaseCount(info) + 1);

        money -= info.GetPurchaseInfo().GetMoneyCost();
        obsidian -= info.GetPurchaseInfo().GetObsidianCost();
        foreach (var modifier in info.GetModifiers())
            modifier.Apply(modifierInfo);
    }

    public int GetObsidianEarned()
    {
        return (int) (money / 1);
    }

    public int GetLoops() => loops;
    public float GetMoney() => money;
    public int GetObsidian() => (int) Mathf.Floor(obsidian);
    public bool IsPurchased(UpgradeInfo info) => purchasedUpgrades.Contains(info);
    public int GetPurchaseCount(BuildingInfo info)
    {
        int numPurchased;
        purchasedBuildings.TryGetValue(info, out numPurchased);
        return numPurchased;
    }
}
