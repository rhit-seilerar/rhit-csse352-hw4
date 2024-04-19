using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventBus : EventBus<GameEventBus.Type>
{
    public enum Type
    {
        // Lifecycle
        Start,
        Update,
        Stop,
        End,

        // Hovering
        HoverStart, // Hoverable
        HoverStop, // Hoverable

        // Purchasing
        UpgradePurchased, // State.UpgradeInfo
        BuildingPurchased, // State.BuildingInfo
    }
}
