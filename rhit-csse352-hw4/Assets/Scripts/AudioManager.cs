using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip volcanoEruption;
    [SerializeField] AudioClip victorySound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameEventBus.Instance.Subscribe<UpgradeInfo>(GameEventBus.Type.UpgradePurchased, PlayClickSound);
        GameEventBus.Instance.Subscribe<BuildingInfo>(GameEventBus.Type.BuildingPurchased, PlayClickSound);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, PlayVolcanoEruption);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.End, PlayVictorySound);
    }

    void PlayClickSound(UpgradeInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }

    void PlayClickSound(BuildingInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }

    void PlayVolcanoEruption()
    {
        if (GameManager.Instance.GetRunningState() != GameManager.RunningState.ENDED)
            audioSource.PlayOneShot(volcanoEruption);
    }

    void PlayVictorySound()
    {
        audioSource.PlayOneShot(victorySound);
    }
}
