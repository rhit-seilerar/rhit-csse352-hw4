using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : GameUpdatable
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
        text.text = $"<size=36>Money: </size>{GameManager.Instance.GetMoney():c1}";
    }

    protected override void OnStop() { }
}
