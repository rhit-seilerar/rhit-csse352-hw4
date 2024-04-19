public class RetentionModifier : IGameModifier
{
    readonly float capacity;

    public RetentionModifier(float capacity)
    {
        this.capacity = capacity;
    }

    public void Apply(ModifierInfo info)
    {
        info.retainCapacity += capacity;
    }

    public override string ToString()
    {
        return $"<color={GameManager.MONEY_COLOR}>+${capacity:n1} Retention for Next Loop</color>";
    }
}
