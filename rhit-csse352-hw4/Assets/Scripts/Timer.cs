using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : UIUpdatable
{
    TMP_Text text;
    float time;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        SubscribeToUpdates();
    }

    protected override void OnStart()
    {
        time = 60;
        text.text = $"Time: {time:F1}s";
    }


    protected override void OnUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
            time = 0;
        text.text = $"Time: {time:F1}s";
        if (time <= 0)
            UIEventBus.Instance.Publish(UIEventBus.Type.Stop);
    }

    protected override void OnStop() { }
}
