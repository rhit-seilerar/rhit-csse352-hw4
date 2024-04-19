using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    enum RunningState
    {
        NOT_STARTED,
        STARTING,
        UPDATING,
        STOPPED,
    }

    RunningState state = RunningState.NOT_STARTED;
    int loops = 0;
    float money = 0;
    int obsidian = 0;

    void Start()
    {
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Start, OnStart);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, OnStop);
    }

    void Update()
    {
        if (state == RunningState.NOT_STARTED)
        {
            state = RunningState.STARTING;
            GameEventBus.Instance.Publish(GameEventBus.Type.Start);
        }
        
        if (state == RunningState.UPDATING)
        {
            GameEventBus.Instance.Publish(GameEventBus.Type.Update);
            money += Time.deltaTime;
        }
    }

    void OnStart()
    {
        obsidian += GetObsidianEarned();
        money = 0;
        state = RunningState.UPDATING;
    }

    void OnStop()
    {
        state = RunningState.STOPPED;
        loops++;
    }

    public int GetObsidianEarned()
    {
        return (int) (money / 1);
    }

    public int GetLoops() => loops;
    public float GetMoney() => money;
    public int GetObsidian() => obsidian;
}
