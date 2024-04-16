using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventPublisher : MonoBehaviour
{
    [SerializeField] UIEventBus.Type type;

    public void Publish()
        => UIEventBus.Instance.Publish(type);
}
