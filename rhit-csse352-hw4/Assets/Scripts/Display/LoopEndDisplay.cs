using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoopEndDisplay : MonoBehaviour
{
    [SerializeField] CanvasGroup content;
    [SerializeField] TMP_Text text;
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
            text.text = $"You earned <color=#372648>{GameManager.Instance.GetObsidianEarned()}pc</color> of <color=#372648>Obsidian</color>.";
            content.alpha += Time.deltaTime * 1f;
            content.interactable = content.alpha >= 0.1;
            yield return new WaitForEndOfFrame();
        }
    }
}
