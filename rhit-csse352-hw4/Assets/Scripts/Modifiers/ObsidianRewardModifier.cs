using UnityEngine;

public class ObsidianRewardModifier: IGameModifier
{
    readonly float reward;

    public ObsidianRewardModifier(float reward)
    {
        this.reward = reward;
    }

    public void Apply(ModifierInfo info)
    {
        info.obsidianReward += reward;
    }

    public override string ToString()
    {
        if (reward >= 1)
            return $"<color={GameManager.OBSIDIAN_COLOR}>+{reward:n0}pc on Loop End</color>";
        return $"<color={GameManager.OBSIDIAN_COLOR}>+1pc per {1f / reward:n0} on Loop End</color>";
    }
}
