using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    AudioClip clip1;
    [SerializeField]
    AudioClip clip2;
    AudioClip current;

    [SerializeField]
    PlayerCameraControll cameraControll;
    private void Start()
    {
        current = clip1;
    }
    [ContextMenu("Loop Clip")]
    public void IterateClip()
    {
        if (current == clip1)
        {
            AudioSystem.Instance.TransitionToBGM(clip2, 2f);
            current = clip2;
        }
        else
        {
            AudioSystem.Instance.TransitionToBGM(clip1, 2f);
            current = clip1;
        }
    }
    [ContextMenu("Test Shake")]
    public void Shake()
    {
        cameraControll.ShakeCamera(1f);
    }

    [ContextMenu("Show Intro Canvas")]
    public void ShowIntroCanvas()
    {
        IntroCanvas.Instance.Show();
    }
    [ContextMenu("Hide Intro Canvas")]
    public void HideIntroCanvas()
    {
        IntroCanvas.Instance.Shutdown();
    }
    [ContextMenu("Show Lose Canvas")]
    public void ShowLoseCanvas()
    {
        LoseCanvas.Instance.Show();
    }
    [ContextMenu("Hide Intro Canvas")]
    public void HideLoseCanvas()
    {
        LoseCanvas.Instance.Shutdown();
    }

}
