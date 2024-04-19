using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] AudioClip clickSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameEventBus.Instance.Subscribe<UpgradeInfo>(GameEventBus.Type.UpgradePurchased, PlayClickSound);
        GameEventBus.Instance.Subscribe<BuildingInfo>(GameEventBus.Type.BuildingPurchased, PlayClickSound);
    }

    void PlayClickSound(UpgradeInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }

    void PlayClickSound(BuildingInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }
}
