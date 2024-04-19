using UnityEngine;
using UnityEngine.UI;

// Adapted from https://gist.github.com/almirage/e9e4f447190371ee6ce9

public class ImageAnimator : MonoBehaviour
{
	[SerializeField] Sprite[] sprites;
	[SerializeField] float maxSecondsPerFrame = 0.8f;
	[SerializeField] float minSecondsPerFrame = 0.1f;

	Image image;
	float frame;
	int index;
	bool paused = false;

	void Start()
	{
		image = GetComponent<Image>();
		GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
		GameEventBus.Instance.Subscribe<bool>(GameEventBus.Type.Pause, OnPause);
		OnStart();
	}

	void OnStart()
    {
		index = 0;
		frame = 0;
    }

	void OnPause(bool paused)
    {
		this.paused = paused;
    }

	void Update()
	{
		if (paused) return;

		var percentTime = GameManager.Instance.GetPercentTimeRemaining();
		var secondsPerFrame = Mathf.Lerp(minSecondsPerFrame, maxSecondsPerFrame, percentTime);
		frame += Time.deltaTime;
		if (frame < secondsPerFrame) return;
		if (percentTime > 0)
			index = (index + 1) % sprites.Length;
		else
			index = sprites.Length - 1;
		image.sprite = sprites[index];
		frame = 0;
	}
}
