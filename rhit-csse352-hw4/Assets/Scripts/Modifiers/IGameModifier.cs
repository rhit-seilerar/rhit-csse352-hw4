using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModifier
{
    void Apply(ModifierInfo info);
}
