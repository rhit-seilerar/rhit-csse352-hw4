using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip volcanoEruption;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameEventBus.Instance.Subscribe<UpgradeInfo>(GameEventBus.Type.UpgradePurchased, PlayClickSound);
        GameEventBus.Instance.Subscribe<BuildingInfo>(GameEventBus.Type.BuildingPurchased, PlayClickSound);
        GameEventBus.Instance.Subscribe(GameEventBus.Type.Stop, PlayVolcanoEruption);
    }

    private void PlayClickSound(UpgradeInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }

    private void PlayClickSound(BuildingInfo info)
    {
        audioSource.PlayOneShot(clickSound);
    }

    private void PlayVolcanoEruption()
    {
        audioSource.PlayOneShot(volcanoEruption);
    }
}
