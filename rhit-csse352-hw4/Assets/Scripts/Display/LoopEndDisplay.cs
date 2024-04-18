using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoopEndDisplay : MonoBehaviour
{
    [SerializeField] CanvasGroup content;
    Image image;
    bool fading;

    void OnEnable()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        image.canvasRenderer.SetAlpha(0);
        content.alpha = 0;
        content.interactable = false;
        fading = false;
        image.CrossFadeAlpha(1f, 1f, false);
        StartCoroutine("FadeContent");
    }

    void OnDisable()
    {
        fading = false;
    }

    IEnumerator FadeContent()
    {
        fading = true;
        while (fading && content.alpha < 1)
        {
            content.alpha += Time.deltaTime * 1f;
            content.interactable = content.alpha >= 0.1;
            yield return new WaitForEndOfFrame();
        }
    }
}
