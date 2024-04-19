public class InstantMoneyModifier : IGameModifier
{
    public void Apply(ModifierInfo info)
    {
        info.bonusMoney += 1000000000f;
    }

    public override string ToString()
    {
        return $"<color={GameManager.MONEY_COLOR}>+${1000000000f:n1}</color>";
    }
}
