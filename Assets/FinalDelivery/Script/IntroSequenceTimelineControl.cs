using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Playables;
using UnityEngine.Playables;
[RequireComponent(typeof(PlayableDirector))]
public class IntroSequenceTimelineControl : MonoBehaviour
{
    PlayableDirector director;
    PlayerCollision player;
    Dialogue dialogue;
    // Start is called before the first frame update
    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        dialogue= FindObjectOfType<Dialogue>();
        director.played += DisablePlayerControl;
        director.stopped += EnablePlayerControl;
    }
    void Start()
    {
        StartCoroutine(StartCutScence());
        player = FindObjectOfType<PlayerCollision>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            director.Stop();
        }
    }
    void DisablePlayerControl(PlayableDirector p)
    {
        Debug.LogWarning("start playing");
        //var player = FindObjectOfType<PlayerCollision>();
        player.isDead = true;
        dialogue.canClick = false;
    }
    void EnablePlayerControl(PlayableDirector p) {
       
        //var player = FindObjectOfType<PlayerCollision>();
        player.isDead = false;
        dialogue.canClick = true;
    }

    IEnumerator StartCutScence() {
        yield return new WaitForSeconds(1);
        director.Play();
    }
}
