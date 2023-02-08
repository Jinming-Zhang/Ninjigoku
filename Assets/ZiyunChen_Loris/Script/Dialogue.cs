using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> clickAudio;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;
    public int indexForPan;
    public bool canClick;
    public GameObject it_holder;
    IntroSequenceTimelineControl it;
    EnemySpawner enemySpawner;
    PlayableDirector director;
    PlayerCollision player;
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
      if (index == indexForPan) {
            
            Notify();
        }
    }

    void Notify() {
    
        director.Play();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text=string.Empty; 
            StartCoroutine(TypeLine());
        }
        else
        {
            if (index == lines.Length - 1)
            {
                player.isDead = false;
                canClick = true;
                if (!it.cutsceneisEnded) director.Stop();
                enemySpawner.StartTimer();
                gameObject.SetActive(false);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        it = it_holder.GetComponent<IntroSequenceTimelineControl>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        textComponent.text = string.Empty;
        director = it_holder.GetComponent<PlayableDirector>();
        player = FindObjectOfType<PlayerCollision>();
        
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(canClick && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                AudioSystem.Instance.PlaySFX(clickAudio[Random.Range(0, clickAudio.Count)], 0.2f);
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                if(index == indexForPan) Notify();
            }
            
        }
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(it.cutsceneisEnded);
            player.isDead = false;
            canClick = false;
            if (!it.cutsceneisEnded) director.Stop();
            enemySpawner.StartTimer();
            this.gameObject.SetActive(false);

        }
    }

    
}

 
