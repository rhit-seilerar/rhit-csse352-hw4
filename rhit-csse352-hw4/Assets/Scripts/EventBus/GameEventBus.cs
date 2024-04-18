using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventBus : EventBus<GameEventBus.Type>
{
    public enum Type
    {
        Start = 0,
        Update = 1,
        Stop = 2,

        HoverStart = 3, // Hoverable
        HoverStop = 4, // Hoverable

        UpgradePurchased = 5, // State.UpgradeInfo
        BuildingPurchased = 6, // State.BuildingInfo
    }
}
