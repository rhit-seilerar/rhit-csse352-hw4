using TMPro;
using UnityEngine;

public class TimerDisplay : GameUpdatable
{
    TMP_Text text;
    float h, s, v;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
        Color.RGBToHSV(text.color, out h, out s, out v);
    }

    protected override void OnStart()
    {
        text.text = $"Time: {GameManager.Instance.GetTimer():n1}s";
    }

    protected override void OnUpdate()
    {
        text.text = $"Time: {GameManager.Instance.GetTimer():n1}s";
        text.color = Color.HSVToRGB(h * GameManager.Instance.GetPercentTimeRemaining(), s, v, false);
    }

    protected override void OnStop() { }
}
