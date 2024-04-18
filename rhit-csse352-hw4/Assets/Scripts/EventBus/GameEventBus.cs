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

        HoverStart = 3,
        HoverStop = 4,

        UpgradePurchased = 5,
    }
}
