public class MoneyModifier : IGameModifier
{
    readonly float multiplier;

    public MoneyModifier(float multiplier)
    {
        this.multiplier = multiplier;
    }

    public void Apply(ModifierInfo info)
    {
        info.productionMultiplier += multiplier;
    }

    public override string ToString()
    {
        return $"<color={GameManager.HAPPY_COLOR}>+{multiplier * 100:n1}% Money Production</color>";
    }
}
