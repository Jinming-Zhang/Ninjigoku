using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class LoseCanvas : UIScreen<LoseCanvas>
{
    [SerializeField]
    AudioClip loseAmbientAudio;

    public void Start()
    {
        AudioSystem.Instance.TransitionToBGM(loseAmbientAudio, 2);
    }

    private static LoseCanvas instance;
    public static LoseCanvas Instance
    {
        get
        {
            if (!instance)
            {
                Object go = Instantiate(Resources.Load("LoseCanvas"));
                instance = go.GetComponent<LoseCanvas>();
                instance.gameObject.SetActive(false);
            }
            return instance;
        }
    }
}
