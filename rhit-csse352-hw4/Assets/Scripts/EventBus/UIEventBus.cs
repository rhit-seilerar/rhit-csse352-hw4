using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventBus : EventBus<UIEventBus.Type>
{
    public enum Type
    {
        Start = 0,
        Update = 1,
        Stop = 2,

        HoverStart = 3,
        HoverStop = 4
    }
}
