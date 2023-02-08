using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField]
    GameStatus gameStatus;
    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        dialogue = FindObjectOfType<Dialogue>();
        director.played += DisablePlayerControl;
        director.stopped += EnablePlayerControl;
    }
    void Start()
    {
        Slider.SetActive(false);
        dialogue = FindObjectOfType<Dialogue>();
        player = FindObjectOfType<PlayerCollision>();
    }
    private void Update()
    {
        if (!cutsceneisEnded && Input.GetKeyUp(KeyCode.Escape))
        {
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
        player.isDead = true;
        StartCoroutine(ChangeCameraSettings());
        dialogue.canClick = false;
        cutsceneisEnded = false;
    }

    void EnablePlayerControl(PlayableDirector p)
    {
        dialogue.canClick = true;
        Slider.SetActive(true);
        gameStatus.shouldCount = true;
    }

    IEnumerator ChangeCameraSettings()
    {
        yield return new WaitForSeconds(2);
        onEnd.Invoke();
    }
}
