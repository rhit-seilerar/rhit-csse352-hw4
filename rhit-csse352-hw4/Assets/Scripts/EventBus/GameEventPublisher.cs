using UnityEngine;

public class GameEventPublisher : MonoBehaviour
{
    [SerializeField] GameEventBus.Type type;
    public void Publish() => GameEventBus.Instance.Publish(type);
}
