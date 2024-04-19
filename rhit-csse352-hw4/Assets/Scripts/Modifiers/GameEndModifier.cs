using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndModifier : IGameModifier
{
    public void Apply(ModifierInfo info)
    {
        GameEventBus.Instance.Publish(GameEventBus.Type.End);
    }
}
