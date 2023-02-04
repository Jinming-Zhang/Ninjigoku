using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Features: 
/// Globally accessed, Scene Independent, Destroyed with scene, Auto initialized
/// BGM Music Transition
/// Play SFX
/// </summary>
public class AudioSystem : MonoBehaviour
{
    private static AudioSystem instance;
    public static AudioSystem Instance
    {
        get
        {
            if (!instance)
            {
                string resourcePath = "AudioSystem";
                Object go = Instantiate(Resources.Load(resourcePath));

                instance = go.GetComponent<AudioSystem>();
            }
            return instance;
        }
    }

    [SerializeField]
    List<AudioSource> bgmTracks;
    int currentBGMTrackInd;
    [SerializeField]
    AudioSource sfxTrack;

    Coroutine transitionCoroutine;

    bool isTransitioning;
    private void OnDestroy()
    {
        instance = null;
    }

    private void Awake()
    {
        currentBGMTrackInd = 0;
    }

    public void TransitionToBGM(AudioClip clip, float duration, float volumn = 1f)
    {
        if (transitionCoroutine != null)
        {
            return;
        }

        AudioSource current = bgmTracks[currentBGMTrackInd];
        if (currentBGMTrackInd + 1 >= bgmTracks.Count)
        {
            currentBGMTrackInd = 0;
        }
        else
        {
            currentBGMTrackInd++;
        }

        AudioSource next = bgmTracks[currentBGMTrackInd];

        transitionCoroutine = StartCoroutine(transitionCR(current, next, clip, volumn, duration));
    }
    public void PlaySFX(AudioClip clip, float volumn = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    IEnumerator transitionCR(AudioSource current, AudioSource next, AudioClip clip, float volumn, float duration)
    {
        float track1Amt = current.volume;
        float track2Amt = volumn;

        float track1Delta = track1Amt / duration;
        float track2Delta = track2Amt / duration;
        next.clip = clip;
        next.loop = true;
        next.Play();
        next.volume = 0;
        while (current.volume > 0 && next.volume < volumn)
        {
            current.volume -= track1Delta * Time.deltaTime;
            if (current.volume < 0)
            {
                current.volume = 0;
            }
            next.volume += track2Delta * Time.deltaTime;
            if (next.volume > volumn)
            {
                next.volume = volumn;
            }
            yield return new WaitForEndOfFrame();
        }
        transitionCoroutine = null;
    }
}
