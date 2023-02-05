using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Playables;
using UnityEngine.Playables;
[RequireComponent(typeof(PlayableDirector))]
public class IntroSequenceTimelineControl : MonoBehaviour
{
    PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.played += DisablePlayerControl;
        director.stopped += EnablePlayerControl;
    }
    void DisablePlayerControl(PlayableDirector p)
    {
        var player = FindObjectOfType<PlayerCollision>();
        player.isDead = true;
    }
    void EnablePlayerControl(PlayableDirector p) {
        var player = FindObjectOfType<PlayerCollision>();
        player.isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
