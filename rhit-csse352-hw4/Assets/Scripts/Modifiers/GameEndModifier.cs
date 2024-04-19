public class GameEndModifier : IGameModifier
{
    public void Apply(ModifierInfo info)
    {
        GameEventBus.Instance.Publish(GameEventBus.Type.End);
    }

    public override string ToString()
    {
        return $"<color={GameManager.LAVA_COLOR}>+1 Credits Sequence</color>";
    }
}
