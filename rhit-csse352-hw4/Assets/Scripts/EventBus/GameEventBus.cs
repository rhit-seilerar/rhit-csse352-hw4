public class GameEventBus : EventBus<GameEventBus.Type>
{
    public enum Type
    {
        // Lifecycle
        Start,
        Update,
        Pause, // bool
        Stop,
        End,

        // Hovering
        HoverStart, // Hoverable
        HoverStop, // Hoverable

        // Purchasing
        UpgradePurchased, // State.UpgradeInfo
        BuildingPurchased, // State.BuildingInfo
    }
}
