using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopsDisplay : GameUpdatable
{
    TMP_Text text;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
    }

    protected override void OnStart() { }

    protected override void OnUpdate()
    {
        text.text = $"<size=36>Loops: </size>{GameManager.Instance.GetLoops():n0}";
    }

    protected override void OnStop() { }
}
