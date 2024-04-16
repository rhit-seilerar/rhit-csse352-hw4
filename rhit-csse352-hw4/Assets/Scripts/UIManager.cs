using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        UIEventBus.Instance.Publish(UIEventBus.Type.Start);
    }

    void Update()
    {
        UIEventBus.Instance.Publish(UIEventBus.Type.Update);
    }
}