using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsidianModifier : IGameModifier
{
    readonly float obsidian;

    public ObsidianModifier(float obsidian)
    {
        this.obsidian = obsidian;
    }

    public void Apply(ModifierInfo info)
    {
        info.obsidianRate += obsidian;
    }

    public override string ToString()
    {
        return $"<color={GameManager.OBSIDIAN_COLOR}>+{obsidian:n0}pc per Second</color>";
    }
}
