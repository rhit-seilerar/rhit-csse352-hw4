using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : GameUpdatable
{
    [SerializeField] float startTime = 60.0f;
    TMP_Text text;
    float h, s, v;
    float time;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
        Color.RGBToHSV(text.color, out h, out s, out v);
    }

    protected override void OnStart()
    {
        time = startTime;
        text.text = $"Time: {time:F1}s";
    }

    protected override void OnUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
            time = 0;
        text.text = $"Time: {time:F1}s";
        text.color = Color.HSVToRGB(h * time / startTime, s, v, false);
        if (time <= 0)
            GameEventBus.Instance.Publish(GameEventBus.Type.Stop);
    }

    protected override void OnStop() { }
}
