public class InstantObsidianModifier : IGameModifier
{
    public void Apply(ModifierInfo info)
    {
        info.bonusObsidian += 1000000000;
    }

    public override string ToString()
    {
        return $"<color={GameManager.OBSIDIAN_COLOR}>+{1000000000:n0}pc</color>";
    }
}
