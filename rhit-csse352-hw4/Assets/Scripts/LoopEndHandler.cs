using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoopEndHandler : UIUpdatable
{
    [SerializeField] CanvasGroup content;
    Image image;
    bool fading;

    protected override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        image.canvasRenderer.SetAlpha(0);
    }

    protected override void OnStart()
    {
        image.CrossFadeAlpha(0f, 0f, true);
        content.alpha = 0;
        content.interactable = false;
        fading = false;
    }

    protected override void OnUpdate() { }

    protected override void OnStop()
    {
        content.gameObject.SetActive(true);
        image.CrossFadeAlpha(1f, 1f, false);
        StartCoroutine("FadeContent");
    }

    IEnumerator FadeContent()
    {
        fading = true;
        while (fading && content.alpha < 1)
        {
            content.alpha += 0.00001f;
            content.interactable = content.alpha >= 0.1;
            yield return null;
        }
    }

}
