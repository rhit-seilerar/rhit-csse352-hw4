public class MiningModifier : IGameModifier
{
    readonly float multiplier;

    public MiningModifier(float multiplier)
    {
        this.multiplier = multiplier;
    }

    public void Apply(ModifierInfo info)
    {
        info.obsidianMultiplier += multiplier;
    }

    public override string ToString()
    {
        return $"<color={GameManager.HAPPY_COLOR}>+{multiplier * 100:n1}% Obsidian Yield</color>";
    }
}
