public class DrillingModifier : IGameModifier
{
    readonly float multiplier;

    public DrillingModifier(float multiplier)
    {
        this.multiplier = multiplier;
    }

    public void Apply(ModifierInfo info)
    {
        info.extractionMultiplier += multiplier;
    }

    public override string ToString()
    {
        return $"<color={GameManager.HAPPY_COLOR}>+{multiplier * 100:n1}% Obsidian Yield</color>";
    }
}
