using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip ambientSFXs;

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
}
