using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip ambientSFXs;

    [SerializeField]
    List<AudioClip> stepsAudio;
    [SerializeField]
    float footStepCooldown;
    [SerializeField]
    float footStepVolume;

    float footStepTimer;

    [SerializeField]
    List<AudioClip> randomEnemySFXs;
    [SerializeField]
    float enemySFXCD;

    // Start is called before the first frame update
    void Start()
    {
        AudioSystem.Instance.TransitionToBGM(ambientSFXs, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySFXCD < 0)
        {
            AudioSystem.Instance.PlaySFX(randomEnemySFXs[Random.Range(0, randomEnemySFXs.Count)]);
        }
    }

    public void playFootStepsAudio()
    {
        if (footStepTimer >= footStepCooldown)
        {
            AudioSystem.Instance.PlaySFX(stepsAudio[Random.Range(0, stepsAudio.Count)], 0.2f);
            footStepTimer = 0;
        }
        footStepTimer += Time.fixedDeltaTime;
    }
}
