using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInfo
{
    string title;
    string text;

    public HoverInfo(string title, string text)
    {
        this.title = title;
        this.text = text;
    }

    public virtual string GetTitle() => title;
    public virtual string GetText() => text;
}
