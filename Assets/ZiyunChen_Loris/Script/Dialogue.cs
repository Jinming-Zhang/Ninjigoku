using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public int index;
    public bool canClick = true;
    PlayableDirector playableDirector;
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
            gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
         playableDirector = FindObjectOfType<PlayableDirector>();
    }
    void Start()
    {  
        textComponent.text = string.Empty;
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
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void EnableClick(PlayableDirector pd) { 
        canClick = true;
    }

    public void DisableClick(PlayableDirector pd)
    {
        canClick= false;
    }

    private void OnEnable()
    {
        playableDirector.played += DisableClick;
        playableDirector.stopped += EnableClick;
    }
    private void OnDisable()
    {
        playableDirector.played -= DisableClick;
        playableDirector.stopped-= EnableClick;
    }
}
