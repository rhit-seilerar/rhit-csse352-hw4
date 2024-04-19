using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyModifier : IGameModifier
{
    readonly float multiplier;

    public MoneyModifier(float multiplier)
    {
        this.multiplier = multiplier;
    }

    public void Apply(ModifierInfo info)
    {
        info.productionMultiplier *= multiplier;
    }
}