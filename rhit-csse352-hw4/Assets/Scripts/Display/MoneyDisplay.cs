using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : GameUpdatable
{
    TMP_Text text;
    float money;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
        money = 0;
    }

    protected override void OnStart() { }

    protected override void OnUpdate()
    {
        text.text = $"Money: {money:c1}";
    }

    protected override void OnStop() { }
}
