using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObsidianDisplay : GameUpdatable
{
    TMP_Text text;
    int obsidian;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
        obsidian = 0;
    }

    protected override void OnStart() { }

    protected override void OnUpdate()
    {
        text.text = $"Obsidian: {obsidian}pc";
    }

    protected override void OnStop() { }
}
