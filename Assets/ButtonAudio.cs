using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip buttonClickSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButtonAudio()
    {
        AudioSystem.Instance.PlaySFX(buttonClickSFX);
    }
}
