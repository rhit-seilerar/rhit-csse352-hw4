using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class FadingDisplay : MonoBehaviour
{
    [SerializeField] protected CanvasGroup content;
    Image image;
    float fadeSpeed;
    bool fading;

    public FadingDisplay(float fadeSpeed) : base()
    {
        this.fadeSpeed = fadeSpeed;
    }

    void OnEnable()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        image.canvasRenderer.SetAlpha(0);
        content.alpha = 0;
        content.interactable = false;
        fading = false;
        image.CrossFadeAlpha(1f, fadeSpeed, false);
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
            OnFade();
            content.alpha += Time.deltaTime * fadeSpeed;
            content.interactable = content.alpha >= 0.1;
            yield return new WaitForEndOfFrame();
        }
    }

    protected abstract void OnFade();
}
