using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public enum RunningState
    {
        NOT_STARTED,
        STARTING,
        UPDATING,
        STOPPED,
        ENDED,
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
        GameEventBus.Instance.Subscribe(GameEventBus.Type.End, OnEnd);
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
        purchasedUpgrades.Clear();
        purchasedBuildings.Clear();
        modifierInfo = new ModifierInfo();
        state = RunningState.UPDATING;
    }

    void OnStop()
    {
        state = RunningState.STOPPED;
        loops++;
    }

    void OnEnd()
    {
        state = RunningState.ENDED;
        GameEventBus.Instance.Publish(GameEventBus.Type.Stop);
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
        money -= info.GetPurchaseInfo().GetMoneyCost(GetPurchaseCount(info));
        obsidian -= info.GetPurchaseInfo().GetObsidianCost(GetPurchaseCount(info));
        purchasedBuildings[info] = GetPurchaseCount(info) + 1;
        info.GetPurchaseInfo().UpdateText(GetPurchaseCount(info));
        foreach (var modifier in info.GetModifiers())
            modifier.Apply(modifierInfo);
    }

    public int GetObsidianEarned()
    {
        return (int) (money / 1);
    }

    public RunningState GetRunningState() => state;
    public int GetLoops() => loops;
    public float GetMoney() => money;
    public int GetObsidian() => (int) Mathf.Floor(obsidian);
    public bool IsPurchased(UpgradeInfo info) => purchasedUpgrades.Contains(info);
    public int GetPurchaseCount(BuildingInfo info)
    {
        if (!purchasedBuildings.ContainsKey(info))
            purchasedBuildings[info] = 0;
        return purchasedBuildings[info];
    }
}
