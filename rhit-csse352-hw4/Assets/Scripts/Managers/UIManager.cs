using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] TooltipDisplay tooltipDisplay;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] LoopEndDisplay loopEndDisplay;
    [SerializeField] GameEndDisplay gameEndDisplay;

    protected virtual void Start()
    {
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Subscribe<bool>(GameEventBus.Type.Pause, OnPause);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, OnStop);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.End, OnEnd);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStart, OnHoverStart);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
        GameEventBus.Instance.Subscribe<Hoverable>(GameEventBus.Type.HoverStop, OnHoverStop);
    }

    void Update()
    {
        var state = GameManager.Instance.GetRunningState();
        if (state < GameManager.RunningState.STOPPED && Input.GetKeyDown(KeyCode.Escape))
            GameEventBus.Instance.Publish(GameEventBus.Type.Pause, GameManager.Instance.GetRunningState() != GameManager.RunningState.PAUSED);
    }

    void OnStart()
    {
        loopEndDisplay.gameObject.SetActive(false);
    }

    void OnPause(bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    void OnStop()
    {
        pauseScreen.gameObject.SetActive(false);
        if (GameManager.Instance.GetRunningState() != GameManager.RunningState.ENDED)
            loopEndDisplay.gameObject.SetActive(true);
    }

    void OnEnd()
    {
        gameEndDisplay.gameObject.SetActive(true);
    }

    void OnHoverStart(Hoverable hoverable)
    {
        tooltipDisplay.OnHoverStart(hoverable);
    }

    void OnHoverStop(Hoverable hoverable)
    {
        tooltipDisplay.OnHoverEnd(hoverable);
    }
}
