using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Playables;
using UnityEngine.Playables;
using Cinemachine;
using System;
using UnityEngine.Rendering;
using Unity.VisualScripting;

[RequireComponent(typeof(PlayableDirector))]
public class IntroSequenceTimelineControl : MonoBehaviour
{   
    public static event Action onEnd; 
    PlayableDirector director;
    PlayerCollision player;
    Dialogue dialogue;
    public bool cutsceneisEnded = false;
    public GameObject Slider;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
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
        Slider.SetActive(false);
        //StartCoroutine(StartCutScence());
        dialogue = FindObjectOfType<Dialogue>();
        player = FindObjectOfType<PlayerCollision>();
    }
    private void Update()
    {
        if (!cutsceneisEnded && Input.GetKeyUp(KeyCode.Escape)) {
            player.isDead = false;
            director.Stop();
            virtualCamera.Priority = 10;
            StartCoroutine(ChangeCameraSettings());
            Slider.SetActive(true);
            cutsceneisEnded = true;
        }
    }
    void DisablePlayerControl(PlayableDirector p)
    {
        
        Debug.LogWarning("start playing");
        //var player = FindObjectOfType<PlayerCollision>();
        player.isDead = true;
        StartCoroutine(ChangeCameraSettings());
        dialogue.canClick = false;
        cutsceneisEnded = false;

    }
    void EnablePlayerControl(PlayableDirector p) {
  
        //var player = FindObjectOfType<PlayerCollision>();
        //player.isDead = false;
        dialogue.canClick = true;
    }

    IEnumerator ChangeCameraSettings() {
        yield return new WaitForSeconds(2);
        onEnd.Invoke();
        
    }
}
