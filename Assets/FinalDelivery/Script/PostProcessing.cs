using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
public class PostProcessing : MonoBehaviour
{   public Volume mVolume;
    private DepthOfField mDOF;
    PlayableDirector mDirector;
    // Start is called before the first frame update
    void Start()
    {
        mDirector = FindObjectOfType<PlayableDirector>();
        mVolume.sharedProfile.TryGet<DepthOfField>(out mDOF);

    }
    private void OnEnable()
    {
        IntroSequenceTimelineControl.onEnd += ChangeSettings;
    }
    // Update is called once per frame
    void ChangeSettings() { 
        mDOF.active = false;
        IntroSequenceTimelineControl.onEnd -= ChangeSettings;
    }
}
