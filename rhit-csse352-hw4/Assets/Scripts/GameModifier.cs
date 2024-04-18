using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameModifier
{
    GameModifier parent;
    float value;

    public GameModifier(float value) : this(null, value) { }
    public GameModifier(GameModifier parent, float value)
    {
        this.parent = parent;
        this.value = value;
    }

    public abstract float GetModifier();
}
